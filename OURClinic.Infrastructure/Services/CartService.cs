using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OurCart.Infrastructure.Services;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OURCart.Infrastructure.Services
{
    public class CartService : BaseRepository<CartProducts>, ICartService
    {
        ICategoryService _catService;

        public CartService(OurCartDBContext dbContext, ICategoryService catService) : base(dbContext)
        {
            _catService = catService;
        }

        public async Task<OperationResponse<Object>> AddItemToUserCart(CartProducts item)
        {
            OperationResponse<Object> or = new OperationResponse<Object>();
            try
            {
                //abdelrhman mohamed start 15-1-2021
                bool isItemExist = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == item.FkDeliveryClientId
                 && i.FkItemId == item.FkItemId && item.IsNew==true).AnyAsync();
                //abdelrhman mohamed end 15-1-2021

                if (isItemExist)
                {
                    var cartProItem = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == item.FkDeliveryClientId
                 && i.FkItemId == item.FkItemId ).FirstAsync();
                    var returnItem = await _dbContext.OrderProducts.FromSql("getCartItemsByItemIDAndUserID @p0,@p1", cartProItem.FkDeliveryClientId, cartProItem.FkItemId).FirstAsync();

                    if ((cartProItem.quantity + item.quantity) >=returnItem.MaxOrderQuantity)
                    {
                        return returnStatus(((decimal)returnItem.MaxOrderQuantity - cartProItem.quantity)+1);
                        
                    }
                    else
                    {
                        cartProItem.quantity = cartProItem.quantity + item.quantity;
                        var addedItem = _dbContext.CartProducts.Update(cartProItem);
                        var rowsEffected = _dbContext.SaveChanges();
                        if (rowsEffected > 0)
                        {
                            returnItem.quantity = cartProItem.quantity;
                            //abdelrhman mohamed start 15-1-2021
                            or.Data = returnItem;
                            or.StatusCode = "200";
                            or.Message = "Success";
                            //abdelrhman mohamed end 15-1-2021

                        }
                    }
                  
                }
                else
                {
                    item.InsertDateTime = DateTime.Now;
                    item.IsNew = true;
                    item.quantity = item.quantity;
                    var addedItem =  _dbContext.CartProducts.Add(item);
                    _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;
                    var rowsEffected = _dbContext.SaveChanges();
                    var cartProItem = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == item.FkDeliveryClientId
                             && i.FkItemId == item.FkItemId && item.IsNew == true).FirstAsync();
                    if (rowsEffected > 0)
                    {
                        var returnItem = await _dbContext.OrderProducts.FromSql("getCartItemsByItemIDAndUserID @p0,@p1", cartProItem.FkDeliveryClientId, cartProItem.FkItemId).FirstAsync();

                        //abdelrhman mohamed start 15-1-2021
                        or.Data = returnItem;
                        or.StatusCode = "200";
                        or.Message = "Success";
                        //abdelrhman mohamed end 15-1-2021

                    }
                }
            }
            catch (Exception e)
            {
                or.HasErrors = true;
                or.Message = e.Message;
            }
            return or;
        }
        public OperationResponse<object> returnStatus(decimal qnt)
        {
            OperationResponse<object> or = new OperationResponse<object>();

            or.Data = qnt;
            or.StatusCode = "200";
            or.Message = "Success";
            return or;
        }

        public async Task<OperationResponse<bool>> ClearUserCart(decimal userID)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();
            try
            {
                var cartItems = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == userID).ToListAsync();
                _dbContext.CartProducts.RemoveRange(cartItems);
                //foreach (var item in cartItems)
                //{
                //    _dbContext.CartProducts.Remove(item);
                //}
                if (cartItems.Count > 0)
                {
                    var rowsEffected = _dbContext.SaveChanges();

                    or.Data = true;
                    or.Message = "user cart deleted successfully";
                    or.StatusCode = "200";
                }
                else
                {
                    or.HasErrors = true;
                    or.Message = "There is no cart for user number";
                    
                }

            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }

        // get cart products for specific ID
        // response will be object with simple data of default item id 
        // CartResponseModel --> item detail data

        //public async Task<OperationResponse<List<OrderReponseModel>>> GetHistoryOrders(decimal delivertClientID)
        //{
        //public async Task<OperationResponse<List<CartProducts>>> getAllCartProductsByUserID(decimal userID)
        //{
        //    OperationResponse<List<CartProducts>> or = new OperationResponse<List<CartProducts>>();
        //    try
        //    {

        //        var cartItems = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == userID).Include(m=>m.item).ToListAsync();
        //        if (cartItems.Count>0)
        //        {
        //            //abdelrhman mohamed start 15-1-2021
        //            or.Data = cartItems;
        //            or.StatusCode = "200";
        //            or.Message = "Success";
        //            //abdelrhman mohamed end 15-1-2021

        //        }
        //        else
        //        {
        //            or.HasErrors = true;
        //            or.Message = "Please Enter Another user";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        or.HasErrors = true;
        //        or.Message = ex.Message;
        //    }
        //    return or;

        //}


        public async Task<OperationResponse<cartItemsWithFees>> getAllCartProductsByUserID(decimal userID)
        {
            OperationResponse<cartItemsWithFees> or = new OperationResponse<cartItemsWithFees>();
            try
            {
                //  parameters --> category id to filter with, all items count to skip , all items that will return
                cartItemsWithFees res = new cartItemsWithFees();
                var allItmesFav = await _dbContext.OrderProducts.FromSql($"getCartItemsByUserID {userID}").ToListAsync();
                DeliveryClient clientObj =  _dbContext.DeliveryClient.Where(a=>a.DelClientId==userID).FirstOrDefault();

                if (allItmesFav != null)
                {
                    res.cartProducts = allItmesFav;
                    
                    res.fees = _dbContext.Area.Where(a=>a.AreaId== clientObj.FkAreaId).FirstOrDefault().DeliveryAmount;
                }
                    or.StatusCode = "200";
                    or.HasErrors =false;
                    or.Data = res;
                // old data
                //var result = await _dbContext.Items.Where(i => i.FkCategoryId == catID).ToListAsync();
                //if (result != null)
                //    or.Data = result;
            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
            }
            return or;
        }
        public async Task<OperationResponse<decimal>> getTotalPrice(decimal userID)
        {
            OperationResponse<decimal> or = new OperationResponse<decimal>();
            try
            {
                var totalPrice = await _dbContext.CartTotalModel.FromSql($"GetSumOfCartPRoducts {userID}").FirstOrDefaultAsync();
                or.Data = totalPrice.total;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                or.HasErrors = true;
                or.Message = msg;
            }
            return or;
        }
       
        public async Task<OperationResponse<bool>> DeleteItemFromUSerCart(CartProducts item)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();
            try
            {
                // get all item form user cart with the same createria (case inserted with worng many times before)
                var itemsWithSameCreateria = await _dbContext.CartProducts.Where(i =>
                i.FkDeliveryClientId == item.FkDeliveryClientId
                
                && i.FkItemId == item.FkItemId).ToListAsync();

                if (itemsWithSameCreateria != null && itemsWithSameCreateria.Count > 0)
                {
                    _dbContext.RemoveRange(itemsWithSameCreateria); // remove Items / Item
                    var rowsEffected = _dbContext.SaveChanges();
                    if (rowsEffected > 0)
                    {
                        or.Data = true;
                        or.Message = "item deleted successfully";
                        or.HasErrors = false;
                        or.StatusCode = "200";

                    }

                }
                if (!or.Data)
                {
                    or.Message = "no item in user cart with sended createria";
                    or.HasErrors = true;
                }
            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }

        public async Task<OperationResponse<bool>> UpdateItemInCart(CartProducts item)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();
            try
            {
                var product = await _dbContext.CartProducts.Where(i => i.FkDeliveryClientId == item.FkDeliveryClientId
                && i.FkItemId == item.FkItemId)
                .FirstOrDefaultAsync();
                if (product != null)
                {
                    product.quantity = item.quantity == 0 ? product.quantity : item.quantity;
                    product.FkItemId = item.FkItemId;
                    product.fk_itemBarCodeID = item.fk_itemBarCodeID;
                    
                }
                else
                    throw new Exception("item not exist in usercart");
                _dbContext.SaveChanges();
                or.Data = true;
                or.HasErrors = false;

            }
            catch (Exception e)
            {
                or.Data = false;
                or.HasErrors = true;
                or.Message = e.Message;
            }
            return or;
        }
    }
}
