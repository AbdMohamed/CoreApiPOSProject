      using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurCart.DataModel;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System.Threading.Tasks;

namespace OurCart.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        OurCartDBContext _ourERPClinicContext;
        IOrderService _orderService;
        public OrdersController(OurCartDBContext ourERPClinicContext, IOrderService orderService)
        {
            _ourERPClinicContext = ourERPClinicContext;
            _orderService = orderService;
        }

        [HttpGet("checkout")]
        public async Task<IActionResult> CheckOutUSerCart([FromQuery] decimal deliveryClientID, string Notes)
        {
            var result =  await _orderService.checkoutUserOrder(deliveryClientID, Notes);
            return  Ok(result);


        }

        [HttpGet("GetSalesRepOrders")]
        public async Task<IActionResult> getsalesRepOrders([FromQuery] string SalesRepId, string GcmToken)
        {
            var result =  _orderService.getsalesRepOrders(SalesRepId, GcmToken);
            return resultWithStatus(result);


        }

        
       [HttpPost("UpdateOrderStatus")]
        public IActionResult UpdateOrderStatus([FromBody]  orderStatusModel orderStatusModel)
        {
            var res = _orderService.UpdateOrderStatus(orderStatusModel);
            return resultWithStatus(res);
        }

        [HttpGet("history")]
        public  IActionResult GetHistoryOrders([FromQuery] decimal deliveryClientID)
        {
            var res = _orderService.GetHistoryOrders(deliveryClientID);
            return resultWithStatus(res);
        }

        [HttpDelete("DeleteHistoryOrder")]
        public IActionResult DeleteHistoryOrder(decimal UserId,decimal HeaderId)
        {
            var res = _orderService.DeleteHistoryOrder(UserId,HeaderId);
            return resultWithStatus(res);

        }

        [HttpGet("Current")]
        public IActionResult GetCurrentOrders( decimal deliveryClientID)
        {
          var res =  _orderService.GetCurrentOrders(deliveryClientID);
            if (!res.HasErrors)
                return Ok (res);
            return BadRequest(res);
        }

        [HttpGet("reorder")]
        public async Task<IActionResult> Reorder([FromQuery] decimal deliveryClientID, [FromQuery]decimal HeaderID,int clearCart)
        {
            var res = await _orderService.reorder(deliveryClientID, HeaderID, clearCart);
            if (!res.HasErrors)
                return Ok(res);
            return BadRequest(res);
        }

        protected IActionResult resultWithStatus(dynamic result)
        {
            if (!result.HasErrors)
                return Ok(result);
            return BadRequest(result);
        }

    }
}