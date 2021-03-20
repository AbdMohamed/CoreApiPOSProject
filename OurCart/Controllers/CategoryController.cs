using Microsoft.AspNetCore.Mvc;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.Infrastructure.Util;
using System.Threading.Tasks;

namespace OurCart.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : BaseController<ItemCategory>
    {
        ICategoryService _catService;
        public CategoryController(OurCartDBContext _dbcontext, ICategoryService catService) : base(_dbcontext)
        {
            _catService = catService;
        }

        [HttpGet("getItems")]
        public async Task<IActionResult> getAllProductsInCategory(int? catID, int pageNum, int itemsPerPage, int? PriceFilter, int? NameFilter, string SearchText)
        {
            var result = await _catService.getAllProductsInCategory(catID, pageNum, itemsPerPage, PriceFilter, NameFilter,SearchText);
            return resultWithStatus(result);
        }

        [HttpGet("SearchItem")]
        public async Task<IActionResult> SearchByItemBarcode(string SearchText)
        {
            var result = await _catService.SearchByItemBarcode(SearchText);
            return resultWithStatus(result);
        }

        //[HttpGet("SearchByItem")]
        //public async Task<IActionResult> SearchByItemName(string Name)
        //{
        //    var result = await _catService.SearchByItemName(Name);
        //    return resultWithStatus(result);
        //}
        [HttpGet("getItemsWithOffers")]
        public async Task<IActionResult> GetAllItemsInCategoryWithOffers([FromQuery]int catId, [FromQuery]int pageNum, [FromQuery]int itemsPerPage)
        {
            var result = await _catService.getAllOffersInCategory(catId, pageNum, itemsPerPage);
            return resultWithStatus(result);
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery]int? parentCatID,int pageNum, int itemsPerPage, decimal? userId, string GcmToken)
        {
            var result = await _catService.GetCategories(parentCatID,  pageNum,  itemsPerPage, userId, GcmToken);
            return resultWithStatus(result);
        }


    }
}