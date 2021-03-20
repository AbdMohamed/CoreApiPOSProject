using OurCart.DataModel;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface IOrderService
    {
        // convert currnt items in cart to order
        Task<OperationResponse<IEnumerable<CategoryItemWithQnty>>> checkoutUserOrder(decimal delivertClientID,string Notes);
        //get all old orders of user as header data and details with all items data 
        OperationResponse<List<ClientOrders>> GetHistoryOrders(decimal delivertClientID);
        OperationResponse<List<ClientOrdersClient>> getsalesRepOrders(string SalesRepId,string GcmToken);
        Task<OperationResponse<object>> reorder(decimal deliveryClientID, decimal HeaderID, int clearCart);
       OperationResponse<IEnumerable<PoscurrentDailyTransHeader>> GetCurrentOrders(decimal delivertClientID);
        OperationResponse<bool> DeleteHistoryOrder(decimal UserId, decimal HeaderId);
        OperationResponse<bool> UpdateOrderStatus(orderStatusModel orderStatusModel);


    }
}
