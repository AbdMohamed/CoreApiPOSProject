using Microsoft.AspNetCore.Mvc;
using OurCart.DataModel;
using OurCart.Utils;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurCart.Controllers
{
    [Produces("application/json")]
    [Route("api/Favourites")]
    public class FavouritesController : BaseController<Favourites>
    {
        IFavouriteService _favService;
        public FavouritesController(OurCartDBContext _dbContext, IFavouriteService favouriteService) : base(_dbContext)
        {
            _favService = favouriteService;
        }

        //add item to user fav
        [HttpPost("create")]
        [ModelStateValidation]
        public async Task<IActionResult> addItemToFav([FromBody]FavSendModel favModel)
        {
            OperationResponse<Favourites> response = new OperationResponse<Favourites>();
            if (ModelState.IsValid)
            {
                response = await _favService.AddItemToFAV(favModel);
            }
            else
            {
                response.HasErrors = true;
                response.Message = ModelStateUtil.GETModelStateErrorMSG(ModelState);
            }
            return resultWithStatus(response);
        }


        //add item to user Fav
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllFav([FromQuery]decimal userID)
        {
            OperationResponse<List<CategoryItem>>  response = new OperationResponse<List<CategoryItem>>();
            if (ModelState.IsValid)
            {
                response = await _favService.getUserFAV(userID);
            }
            else
            {
                response.HasErrors = true;
                response.Message = ModelStateUtil.GETModelStateErrorMSG(ModelState);
            }
            return resultWithStatus(response);
        }

        //get item status if it in fav or not
        [HttpPost("getItemStatus")]
        public async Task<IActionResult> getItemStatus([FromBody]FavSendModel favModel)
        {

            var response = await _favService.getItemStatusInFav(favModel);
            return resultWithStatus(response);

        }

        //remove item from fav
        [HttpDelete("remove")]
        public async Task<IActionResult> deleteItemFromFav([FromQuery] FavSendModel favModel)
        {

            var response = await _favService.RemoveItemFromFAVAsync(favModel);
            return resultWithStatus(response);

        }



    }
}