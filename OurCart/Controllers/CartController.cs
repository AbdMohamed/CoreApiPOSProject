using Microsoft.AspNetCore.Mvc;
using OurCart.Utils;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.Infrastructure.Util;
using System;
using System.Threading.Tasks;

namespace OurCart.Controllers
{

    [Produces("application/json")]
    [Route("api/Cart")]
    public class CartController : BaseController<CartProducts>
    {
        ICartService _cartService;
        public CartController(OurCartDBContext _dbContext, ICartService cartService) : base(_dbContext)
        {

            _cartService = cartService;
        }

        [HttpGet("getCartItemsByUserID")]
        public async Task<IActionResult> gteAllCartProductsByUserID([FromQuery]decimal userID)
        {
            var result = await _cartService.getAllCartProductsByUserID(userID);
            return resultWithStatus(result);
        }
        [HttpPost("Create")]
        [ModelStateValidation]
      
        public async Task<IActionResult> AddItemToUserCart([FromBody]CartProducts cartItem)
        {
            //abdelrhman mohamed start 15-1-2021
            var result = await _cartService.AddItemToUserCart(cartItem);
            //abdelrhman mohamed end 15-1-2021
            return resultWithStatus(result);
        }
        [HttpPost("DeleteItemFromUserCart")]
        public async Task<IActionResult> DeleteItemFromUserCart([FromBody]CartProducts cartItem)
        {
            var result = await _cartService.DeleteItemFromUSerCart(cartItem);
            return resultWithStatus(result);
        }

        [HttpPost("updateQuantitiy")]
        [ModelStateValidation]
        public async Task<IActionResult> UpdateItemQuantityInCart([FromBody]CartProducts cartItem)
        {
            var result = await _cartService.UpdateItemInCart(cartItem);
            return resultWithStatus(result);
        }

        [HttpPost("ClearUserCart")]
        public async Task<IActionResult> ClearUserCart([FromQuery] decimal userID)
        {
            var result = await _cartService.ClearUserCart(userID);
            return resultWithStatus(result);
        }
    }
}