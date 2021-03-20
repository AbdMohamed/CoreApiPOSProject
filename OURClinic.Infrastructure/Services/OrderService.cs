using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
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
    public class OrderService :IOrderService
    {
        ICartService _cartService;
        OurCartDBContext context;
        ICurrentDailyTransfterHeaderService _currentDailyTransfterHeaderService;
        ICurrentDailyTransfterDetailsService _currentDailyTransfterDetailsService;
        public OrderService(ICartService cartService, ICurrentDailyTransfterHeaderService currentDailyTransfterHeaderService, ICurrentDailyTransfterDetailsService currentDailyTransfterDetailsService, OurCartDBContext dBContext)
        {
            context = dBContext;
            _cartService = cartService;
            _currentDailyTransfterDetailsService = currentDailyTransfterDetailsService;
            _currentDailyTransfterHeaderService = currentDailyTransfterHeaderService;
        }



        //public async Task<OperationResponse<IEnumerable<userCartItem>>> checkoutUserOrder(decimal delivertClientID)
        //{
        //    OperationResponse<IEnumerable<userCartItem>> or = new OperationResponse<IEnumerable<userCartItem>>();
        //    ///get all user cart items
        //    ///and insert master and details data in POSCurrentDailyTransferHeaders, POSCurrentDailyTransferDetails
        //    /// clear user cart from db
        //    /// 

        //    try {
        //        #region Try Body
        //        context.ChangeTracker.AutoDetectChangesEnabled = false;
        //        var StockNoItems = new List<userCartItem>();

        //        var userCartProducts = await context.userCartItem.FromSql($"GetCurrentDeliveryClientCertProducst {delivertClientID}").ToListAsync();
        //        // var cartResult = await _cartService.getAllCartProductsByUserID(delivertClientID);
        //        if (userCartProducts == null)
        //            throw new Exception("No Items In cart ");

        //        #region check Cart Item Quantity in Stock 
        //        foreach (var item in userCartProducts)
        //        {
        //            var ItemStockQuantity = context.Items.FirstOrDefault(i => i.ItemId == item.ItemId && i.FkCategoryId == item.fkCategoryId).MaxStockQuantity;
        //            if ((item.quantity > ItemStockQuantity) || (ItemStockQuantity == 0) || (ItemStockQuantity == null))
        //            {
        //                StockNoItems.Add(item);
        //            }
        //        }

        //        if (StockNoItems.Count > 0)
        //        {
        //            or.HasErrors = false;
        //            or.Data = StockNoItems;

        //        }
        //        #endregion
        //        else
        //        {
        //            #region Add Order
        //            // add order
        //            var counter = 0;
        //            decimal id = getNextHeaderID();
        //            //System.Guid guid = System.Guid.NewGuid();
        //            //String id = guid.ToString();
        //            var PoscurrentDailyTransHeader = 
        //                                 new PoscurrentDailyTransHeader()
        //                                 {
        //                                     Total = (decimal?)(await _cartService.getTotalPrice(delivertClientID)).Data,
        //                                     FkTransTypeId = 1,
        //                                     FkBrId = 1,
        //                                     ClientId = delivertClientID,
        //                                     InsDate = DateTime.Now,
        //                                     TransDate = DateTimeUtility.getFormatFromDateTime(DateTime.Now),
        //                                     FkClientTypeId = 1,// عميل
        //                                     CashierName = "",
        //                                     FkInvoiceStatusId = 4// old//,,
        //                                    ,PoscurrentDailyTransDetails = userCartProducts.Select(

        //                                        item => new PoscurrentDailyTransDetails()
        //                                        {
        //                                            FkBrId = 1,
        //                                            DetailId = _currentDailyTransfterDetailsService.GetAll().Data.Max(d => d.HeaderId) + ++counter,
        //                                            HeaderId = id,
        //                                            InsDate = DateTime.Now,
        //                                            CustPrice = (decimal)item.CustomerPrice,
        //                                            SalePrice = (decimal)item.ItemCost,
        //                                            FkItemBarcodeId = (decimal)item.fk_itemBarCodeID,
        //                                            FktransTypeId = 0,
        //                                            ItemId = (decimal)item.ItemId,
        //                                            ItemName = item.ItemName,
        //                                            PackageName = item.PackageName,
        //                                            Barcode = item.BarCode,
        //                                            TransDate = DateTimeUtility.getFormatFromDateTime(DateTime.Now),


        //                                        }).ToList()



        //                                 };

        //            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT POSCurrentDailyTransHeader ON");
        //            var addedItem = context.PoscurrentDailyTransHeader.Add(PoscurrentDailyTransHeader);
        //            var rowsEffected = context.SaveChanges();
        //            #endregion

        //            #region update Stock Quantity
        //            if (rowsEffected > 0)
        //            {
        //                foreach (var item in userCartProducts)
        //                {
        //                    foreach (var StockItem in context.Items)
        //                    {
        //                        StockItem.MaxStockQuantity = StockItem.MaxStockQuantity - item.quantity;
        //                    }

        //                }
        //            }
        //            #endregion
        //            #region Delete Cart
        //            var InsertedRows = 0;
        //            if (userCartProducts.Count > 0)
        //            {
        //                var CartId = userCartProducts.FirstOrDefault().Id;
        //                var res = context.CartProducts.Find(CartId);
        //                context.CartProducts.Remove(res);
        //                 InsertedRows = context.SaveChanges();
        //            }
                   

        //            #endregion
        //            #region save changes
        //            //context.ChangeTracker.AutoDetectChangesEnabled = true;
        //            //var InsertedRows = context.SaveChanges();
        //            if (InsertedRows > 0)
        //            {
        //                or.Data = userCartProducts;
        //                or.HasErrors = false;
        //                or.Message = "Order Added Successfully";
        //                or.StatusCode = "200";

        //            }
        //            else
        //            {
        //                or.Data = null;
        //                or.HasErrors = true;
        //                or.Message = "Order Added Already";
        //            }

        //            #endregion




        //            #endregion


        //        }
        //        return or;
        //    }

           

        //    catch (Exception ex)
        //    {
              
        //        or.HasErrors = true;
        //        or.Data = null;
        //        or.Message = ex.Message;
        //    }
          
        //    return or;
        //}

        public async Task<OperationResponse<IEnumerable<CategoryItemWithQnty>>> checkoutUserOrder(decimal delivertClientID,string Notes)
        {
            OperationResponse<IEnumerable<CategoryItemWithQnty>> or = new OperationResponse<IEnumerable<CategoryItemWithQnty>>();
            ///get all user cart items
            ///and insert master and details data in POSCurrentDailyTransferHeaders, POSCurrentDailyTransferDetails
            /// clear user cart from db
            /// 

            try
            {
                #region Try Body
                //context.ChangeTracker.AutoDetectChangesEnabled = false;
                var StockNoItems = new List<CategoryItemWithQnty>();

                var userCartProducts = await context.OrderProducts.FromSql($"GetCurrentDeliveryClientCertProducts {delivertClientID}").ToListAsync();
                // var cartResult = await _cartService.getAllCartProductsByUserID(delivertClientID);
                if (userCartProducts == null)
                    throw new Exception("No Items In cart ");

                #region check Cart Item Quantity in Stock 
                foreach (CategoryItemWithQnty item in userCartProducts)
                {
                    var ItemStockQuantity = context.Items.FirstOrDefault(i => i.ItemId == item.ItemId && i.FkCategoryId == item.fkCategoryId).OnHandQty;
                    if ((item.quantity > ItemStockQuantity) || (ItemStockQuantity == 0) || (ItemStockQuantity == null))
                    {
                        item.ItemStockQuantity = ItemStockQuantity;
                        StockNoItems.Add(item);
                    }
                }

                if (StockNoItems.Count > 0)
                {
                    or.HasErrors = true;
                    or.Data = StockNoItems;
                    or.StatusCode = "200";
                    or.Message = "items quantity greater than stock ";

                }
                else if (userCartProducts.Count == 0)
                {
                    or.HasErrors = true;
                    or.Data = null;
                    or.Message = "Order Added Already";
                }
                #endregion
                else
                {
                    #region Add Order
                    // add order
                    var counter = 0;
                    decimal id = getNextHeaderID();
                    DeliveryClient clientObj = context.DeliveryClient.Where(a => a.DelClientId == delivertClientID).FirstOrDefault();

                    var addedHeader =
                                         new PoscurrentDailyTransHeader()
                                         {
                                             Total = (decimal?)(await _cartService.getTotalPrice(delivertClientID)).Data,
                                             FkTransTypeId = 1,
                                             FkBrId = 1,
                                             ClientId = delivertClientID,
                                             InsDate = DateTime.Now,
                                             TransDate = DateTimeUtility.getFormatFromDateTime(DateTime.Now),
                                             FkClientTypeId = 1,// عميل
                                             CashierName = "",
                                             Notes=Notes,
                                             DeliveryAmount= context.Area.Where(a => a.AreaId == clientObj.FkAreaId).FirstOrDefault().DeliveryAmount,
                                             FkInvoiceStatusId = 4,// old//,
                                             PoscurrentDailyTransDetails = userCartProducts.Select(

                                                 item => new PoscurrentDailyTransDetails()
                                                 {
                                                     FkBrId = 1,
                                                     DetailId = _currentDailyTransfterDetailsService.GetAll().Data.Max(d => d.HeaderId) + ++counter,
                                                     HeaderId = 0,
                                                     InsDate = DateTime.Now,
                                                     CustPrice = (decimal)item.CustomerPrice,
                                                     SalePrice = (decimal)item.ItemCost,
                                                     FkItemBarcodeId = (decimal)item.ItemBarCodeID,
                                                     FktransTypeId = 0,
                                                     ItemId = (decimal)item.ItemId,
                                                     ItemName = item.ItemName,                                     
                                                     PackageName = item.PackageName,
                                                     PackageId = item.ItemPackageID,

                                                     Barcode = item.BarCode,
                                                     Qty= item.quantity,
                                                     TransDate = DateTimeUtility.getFormatFromDateTime(DateTime.Now),


                                                 }).ToList()
                                         };


                                      
                    var addedItem = context.PoscurrentDailyTransHeader.Add(addedHeader);
                    #endregion

                    #region update Stock Quantity
                    foreach (var item in userCartProducts)
                    {
                        foreach (var StockItem in context.Items)
                        {
                            StockItem.OnHandQty = StockItem.OnHandQty - item.quantity;
                        }

                    }
                    #endregion
                    #region Delete Cart

                    //var CartId = userCartProducts.Where(a=>a.)
                    var res = context.CartProducts.Where(a=>a.FkDeliveryClientId== delivertClientID).ToList();
                    context.CartProducts.RemoveRange(res);
                    //context.SaveChanges();
                    #endregion
                    #region save changes
                    context.ChangeTracker.AutoDetectChangesEnabled = true;
                    var InsertedRows = context.SaveChanges();
                    if (InsertedRows > 0)
                    {
                        or.Data = userCartProducts;
                        or.HasErrors = false;
                        or.StatusCode = "200";
                        or.Message = "Order Has Done";
                    }
                    else
                    {
                        or.HasErrors = true;
                        or.Message = "Order Already Added";
                    }

                    #endregion




                    #endregion


            }
                return or;
            }



            catch (Exception ex)
            {

                or.HasErrors = true;
                or.Data = null;
                or.Message = ex.Message;
            }

            return or;
        }

        public OperationResponse<IEnumerable<PoscurrentDailyTransHeader>> GetCurrentOrders(decimal delivertClientID)
        {
            OperationResponse<IEnumerable<PoscurrentDailyTransHeader>> or = new OperationResponse<IEnumerable<PoscurrentDailyTransHeader>>();
            try
            {
                //get headers with client id  and details with headerID
                // get customer headers of orders
                var result =  context.PoscurrentDailyTransHeader.Where(h => h.ClientId == delivertClientID && h.FkInvoiceStatusId == 1 /*new*/).Select(h => new PoscurrentDailyTransHeader() {
                   HeaderId = h.HeaderId,
                   InsDate = h.InsDate,
                   Total = h.Total,
                   SubTotal = h.SubTotal,
                   Discount = h.Discount,
                   DeliveryAmount = h.DeliveryAmount,
                   Notes =h.Notes,
                   ClientId = h.ClientId,
                   FkInvoiceStatusId = h.FkInvoiceStatusId,
                 PoscurrentDailyTransDetails=  h.PoscurrentDailyTransDetails.ToList()
                   


                });
               
               
                or.Data = result;

            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
            }
            return or;
        }
        public OperationResponse<List<ClientOrders>> GetHistoryOrders(decimal delivertClientID)
        {
            OperationResponse<List<ClientOrders>> or = new OperationResponse<List<ClientOrders>>();
            try
            {
                //get headers with client id  and details with headerID
                // get customer headers of orders
                var result =  context.PoscurrentDailyTransHeader.Where(h => h.ClientId == delivertClientID && h.FkInvoiceStatusId == 4 /*old*/).Select(h => new PoscurrentDailyTransHeader() {
                   HeaderId = h.HeaderId,
                   InsDate = h.InsDate,
                   Total = h.Total,
                   SubTotal = h.SubTotal,
                   Discount = h.Discount,
                   DeliveryAmount = h.DeliveryAmount,
                   Notes =h.Notes,
                   ClientId = h.ClientId,
                   SalesRepId = h.SalesRepId,
                   SalesRepName = h.SalesRepName,
                   FkInvoiceStatusId = h.FkInvoiceStatusId,
                   FkDeliveryStatusId = h.FkDeliveryStatusId,

                    PoscurrentDailyTransDetails =  h.PoscurrentDailyTransDetails.ToList()
                }).OrderByDescending(a=>a.InsDate);
                List<ClientOrders> clientOrders = new List<ClientOrders>();
                foreach (var item in result)
                {

                    ClientOrders curOrder = new ClientOrders();
                    curOrder.Total = item.Total+(item.DeliveryAmount==null?0: item.DeliveryAmount);
                    curOrder.DeliveryFees = (item.DeliveryAmount == null ? 0 : item.DeliveryAmount);
                    curOrder.HeaderId = item.HeaderId;
                    curOrder.ClientId = item.ClientId;
                    curOrder.InsDate = item.InsDate;
                    curOrder.SalesRepId = item.SalesRepId;
                    curOrder.SalesRepName = item.SalesRepName;
                    curOrder.FkDeliveryStatusId = item.FkDeliveryStatusId;
                    curOrder.Notes = item.Notes;
                    curOrder.POSCurrentDailyTransDetails = new List<CategoryItemWithQnty>();
                    curOrder.POSCurrentDailyTransDetails =  context.OrderProducts.AsNoTracking().FromSql($"getOrderDetailsByHeaderID {item.HeaderId}").ToList();
                    clientOrders.Add(curOrder);

                }




                or.Data = clientOrders;

            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
            }
            return or;
        }
        public  OperationResponse<bool> DeleteHistoryOrder(decimal UserId, decimal HeaderId)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();

            try
            {
                if (UserId == 0 || HeaderId == 0)
                    throw new Exception("insert UserId Or HeaderId");
                //get headers with client id  and details with headerID
                // get customer headers of orders
                var order = context.PoscurrentDailyTransHeader.FirstOrDefault(i => i.ClientId == UserId && i.HeaderId== HeaderId);
                if (order != null)
                {
                    context.PoscurrentDailyTransHeader.Remove(order);
                    
                    int rowsEffected = context.SaveChanges();
                    or.HasErrors = rowsEffected > 0 ? false : true;
                    or.Data = true;
                }
                else
                {
                    throw new Exception("Order not found");
                }
              
            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
                or.Data = false;
            }
            return or;
        }

        // get salesRep Orders
        public OperationResponse<List<ClientOrdersClient>> getsalesRepOrders(string SalesRepId,string GcmToken)
        {
            if (GcmToken != null)
            {
                SalesRep SalesRepObj = context.SalesRep.Where(d => d.SalesRepId == int.Parse(SalesRepId)).FirstOrDefault();
                SalesRepObj.GcmToken = GcmToken;
                context.SaveChanges();
            }
            OperationResponse<List<ClientOrdersClient>> or = new OperationResponse<List<ClientOrdersClient>>();
            var result = context.PoscurrentDailyTransHeader.Where(h => h.SalesRepId == SalesRepId ).OrderByDescending(a=>a.InsDate).AsNoTracking().Select(h => new PoscurrentDailyTransHeader()
            {
                HeaderId = h.HeaderId,
                InsDate = h.InsDate,
                Total = h.Total,
                SubTotal = h.SubTotal,
                Discount = h.Discount,
                DeliveryAmount = h.DeliveryAmount,
                Notes = h.Notes,
                ClientId = h.ClientId,
                FkInvoiceStatusId = h.FkInvoiceStatusId,
                SalesRepId = h.SalesRepId,
                FkDeliveryStatusId = h.FkDeliveryStatusId,
                PoscurrentDailyTransDetails = h.PoscurrentDailyTransDetails.ToList()
            });
            List<ClientOrdersClient> clientOrders = new List<ClientOrdersClient>();
            foreach (var item in result)
            {
                ClientOrdersClient curOrder = new ClientOrdersClient();
                curOrder.Total = item.Total + (item.DeliveryAmount == null ? 0 : item.DeliveryAmount);
                curOrder.DeliveryFees = (item.DeliveryAmount == null ? 0 : item.DeliveryAmount);
                curOrder.HeaderId = item.HeaderId;
                curOrder.ClientId = item.ClientId;
                curOrder.InsDate = item.InsDate;
                curOrder.SalesRepId = item.SalesRepId;
                curOrder.FkDeliveryStatusId = item.FkDeliveryStatusId;
                curOrder.Notes = item.Notes;
                curOrder.client = context.DeliveryClient.Where(a => a.DelClientId == item.ClientId).FirstOrDefault();
                curOrder.POSCurrentDailyTransDetails = context.OrderProducts.FromSql($"getOrderDetailsByHeaderID {item.HeaderId}").ToList();
                clientOrders.Add(curOrder);

            }




            or.Data = clientOrders;
            return or;
        }

        public OperationResponse<bool> UpdateOrderStatus(orderStatusModel orderStatusModel)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();

            try
            {
                if (orderStatusModel.HeaderId == 0 || orderStatusModel.SalesRepId == "")
                    throw new Exception("insert UserId Or HeaderId");
                //get headers with client id  and details with headerID
                // get customer headers of orders
                var order = context.PoscurrentDailyTransHeader.FirstOrDefault(i => i.HeaderId == orderStatusModel.HeaderId && i.SalesRepId == orderStatusModel.SalesRepId);
                if (order != null)
                {
                    order.FkDeliveryStatusId = orderStatusModel.FkDeliveryStatusId;
                    if (orderStatusModel.FkDeliveryStatusId == 4)
                    {
                        order.InsDeliveryClosed = DateTime.Now.ToString(); 
                    }
                    else
                    {
                        order.InsDeliverySent = DateTime.Now.ToString();

                    }
                    int rowsEffected = context.SaveChanges();
                    or.HasErrors = false ;
                    or.StatusCode = "200";
                    or.Data = true;
                }
                else
                {
                    throw new Exception("Order not found");
                }

            }
            catch (Exception ex)
            {
                or.HasErrors = true;
                or.Message = ex.Message;
                or.Data = false;
            }
            return or;
        }
        //public async Task<OperationResponse<List<OrderReponseModel>>> GetHistoryOrders(decimal delivertClientID)
        //{

        //    OperationResponse<List<OrderReponseModel>> or = new OperationResponse<List<OrderReponseModel>>();
        //    try
        //    {
        //        //get headers with client id  and details with headerID
        //        // get customer headers of orders
        //        var headers = await context.PoscurrentDailyTransHeader.Where(h => h.ClientId == delivertClientID && h.FkInvoiceStatusId == 4 /*Paid*/).ToListAsync();
        //        List<OrderReponseModel> result = new List<OrderReponseModel>();
        //        foreach (var item in headers)
        //        {
        //            var detailsData = await context.PoscurrentDailyTransDetails.Where(d => d.HeaderId == item.HeaderId).ToListAsync();
        //            result.Add(new OrderReponseModel()
        //            {
        //                header = item,
        //                details = detailsData
        //            });
        //        }

        //        or.Data = result;

        //    }
        //    catch (Exception ex)
        //    {
        //        or.HasErrors = true;
        //        or.Message = ex.Message;
        //    }
        //    return or;

        //}

        public async Task<OperationResponse<object>> reorder(decimal deliveryClientID, decimal HeaderID,int clearCart)
        {

            OperationResponse<object> or = new OperationResponse<object>();
            try
            {
                // get headers with client id  and details with headerID
                // get customer headers of orders
                var headerID = getNextHeaderID();
                if (clearCart == 1) {
                    var res = context.CartProducts.Where(a => a.FkDeliveryClientId == deliveryClientID).ToList();
                    context.CartProducts.RemoveRange(res);
                    context.SaveChanges();
                }
                var header = await context.PoscurrentDailyTransHeader.Where(h => h.HeaderId == HeaderID).Include(d=>d.PoscurrentDailyTransDetails).FirstOrDefaultAsync();
                foreach (var item in header.PoscurrentDailyTransDetails)
                {


                    //abdelrhman mohamed start 15-1-2021
                    bool isItemExist = await context.CartProducts.Where(i => i.FkDeliveryClientId == deliveryClientID
                     && i.FkItemId == item.ItemId).AnyAsync();
                    //abdelrhman mohamed end 15-1-2021

                    if (isItemExist)
                    {
                        var cartProItem = await context.CartProducts.Where(i => i.FkDeliveryClientId == deliveryClientID
                     && i.FkItemId == item.ItemId).FirstAsync();
                        var returnItem = await context.OrderProducts.FromSql("getCartItemsByItemIDAndUserID @p0,@p1", cartProItem.FkDeliveryClientId, cartProItem.FkItemId).FirstAsync();

                        if ((cartProItem.quantity + item.Qty) >= returnItem.MaxOrderQuantity)
                        {
                            return returnStatus(((decimal)returnItem.MaxOrderQuantity - cartProItem.quantity) + 1);

                        }
                        else
                        {
                            cartProItem.quantity = cartProItem.quantity + item.Qty;
                            var addedItem = context.CartProducts.Update(cartProItem);
                            var rowsEffected = context.SaveChanges();
                            if (rowsEffected > 0)
                            {
                               // returnItem.quantity = cartProItem.quantity;
                                //abdelrhman mohamed start 15-1-2021
                                or.Data = true;
                                or.StatusCode = "200";
                                or.Message = "Success";
                                //abdelrhman mohamed end 15-1-2021

                            }
                        }

                    }
                    else
                    {
                        CartProducts cartObj = new CartProducts();
                        cartObj.FkDeliveryClientId = deliveryClientID;
                        cartObj.quantity = item.Qty;
                        cartObj.FkItemId = item.ItemId;
                        cartObj.fkPackageID = item.PackageId;
                        cartObj.fk_itemBarCodeID = item.FkItemBarcodeId;
                        cartObj.InsertDateTime = DateTime.Now;
                        var addedItem = context.CartProducts.Add(cartObj);
                       
                        var rowsEffected = context.SaveChanges();
                     
                        if (rowsEffected > 0)
                        {

                            //abdelrhman mohamed start 15-1-2021
                            or.Data = true;
                            or.StatusCode = "200";
                            or.Message = "Success";
                            //abdelrhman mohamed end 15-1-2021

                        }
                    }
                }
                //await CartService.AddItemToUserCart()
                header.FkInvoiceStatusId = 4;//old;
                context.SaveChanges();
                or.Data = true;
            }
            catch (Exception ex)
            {
                or.Data = false;
                or.HasErrors = true;
                or.Message = ex.Message;
            }
            return or;
        }

        private decimal getNextHeaderID()
        {
            return _currentDailyTransfterHeaderService.GetAll().Data.Max(h => h.HeaderId) + 1;
        }
        public OperationResponse<object> returnStatus(decimal qnt)
        {
            OperationResponse<object> or = new OperationResponse<object>();

            or.Data = qnt;
            or.StatusCode = "200";
            or.Message = "Success";
            return or;
        }

    }
}