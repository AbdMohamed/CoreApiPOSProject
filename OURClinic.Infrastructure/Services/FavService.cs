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
    public class FavService : BaseRepository<Favourites>, IFavouriteService
    {
        public FavService(OurCartDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<OperationResponse<Favourites>> AddItemToFAV(FavSendModel itemToAdd)
        {
            try
            {
                var isAlreadyAdded = await _dbContext.Favourites.Where(i => i.FkItemID == itemToAdd.FkItemId && i.FkItemPackageId == itemToAdd.FkItemPackageId && i.FkDeliveryClientId == itemToAdd.FkDeliveryClientId).AnyAsync();
                if (!isAlreadyAdded)
                {
                    var item = new Favourites()
                    {
                        FkDeliveryClientId = itemToAdd.FkDeliveryClientId,
                        FkItemID = itemToAdd.FkItemId,
                        FkItemPackageId = itemToAdd.FkItemPackageId,
                        InsDateTime = DateTimeUtility.getFormatFromDateTime(DateTime.Now),
                    };
                    var result = await _dbContext.Favourites.AddAsync(item);
                    var rowsEffected = _dbContext.SaveChanges();
                    if (rowsEffected > 0)
                    {
                        return new OperationResponse<Favourites>
                         ()
                        {
                            Data = item
                        };
                    }
                }
                else
                    return new OperationResponse<Favourites>
                   ()
                    {
                        HasErrors = true,
                        Message = "this item is already added before in your Favourite items"
                    };
            }
            catch (Exception ex)
            {
                return new OperationResponse<Favourites>
                    ()
                {
                    HasErrors = true,
                    Message = ex.Message
                };
            }

            return new OperationResponse<Favourites>
                   ()
            {
                HasErrors = true,
                Message = " item not added, try again"
            };
        }

        public async Task<OperationResponse<bool>> getItemStatusInFav(FavSendModel favItem)
        {
            try
            {
                var response = await _dbContext.Favourites.Where(i => i.FkItemID == favItem.FkItemId && i.FkItemPackageId == favItem.FkItemPackageId && i.FkDeliveryClientId == favItem.FkDeliveryClientId).AnyAsync();
                return new OperationResponse<bool>()
                {
                    Data = response
                };
            }
            catch (Exception ex)
            {
                return new OperationResponse<bool>()
                {
                    HasErrors = true,
                    Message = ex.Message
                };
            }

        }

        // get all fav items with specific user
        //public async Task<OperationResponse<IEnumerable<Favourites>>> getUserFAV(decimal userID)
        //{

        //    try
        //    {
        //        var response =await _dbContext.Favourites
        //            .Where(i => i.FkDeliveryClientId == userID).Include(a=>a.Item)
        //            .ToListAsync();
   

        //        return new OperationResponse<IEnumerable<Favourites>>()
        //        {
        //            Data = response,
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new OperationResponse<IEnumerable<Favourites>>()
        //        {
        //            HasErrors = true,
        //            Message = ex.Message
        //        };
        //    }
        //}


        public async Task<OperationResponse<List<CategoryItem>>> getUserFAV(decimal userID)
        {
            OperationResponse<List<CategoryItem>> or = new OperationResponse<List<CategoryItem>>();
            try
            {
                //  parameters --> category id to filter with, all items count to skip , all items that will return

                var allItmesFav= await _dbContext.CategorItem.AsNoTracking().FromSql($"getUserFAV {userID}").ToListAsync();
                if (allItmesFav != null)
                    or.Data =   allItmesFav ;
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
        public async Task<OperationResponse<bool>> RemoveItemFromFAVAsync(FavSendModel deleteFavObj)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();
            try
            {
                var response = await _dbContext.Favourites.Where(i => i.FkItemID == deleteFavObj.FkItemId && i.FkItemPackageId == deleteFavObj.FkItemPackageId && i.FkDeliveryClientId == deleteFavObj.FkDeliveryClientId).ToListAsync();
                _dbContext.Favourites.RemoveRange(response);
                var rowsEffected = _dbContext.SaveChanges();
                if (rowsEffected > 0)
                    or.Data = true;
                else
                    or.Message = "not Deleted from fav please make sure that item is already in user Favourites List";
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                or.Message = msg;
                or.HasErrors = true;
            }
            return or;

        }
    }
}