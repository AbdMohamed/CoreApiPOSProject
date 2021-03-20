using Microsoft.AspNetCore.Mvc;
using OurCart.DataModel;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO.LocalModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurCart.Controllers
{
    [Produces("application/json")]
    [Route("api/Offers")]
    public class OffersController : Controller
    {
        IOfferService _offerService;
        public OffersController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        [HttpGet]
        public async Task<IActionResult> getAllOffers([FromQuery]int pageNum, [FromQuery]int itemsPerPage)
        {
            OperationResponse<IEnumerable<CategoryItem>> result = new OperationResponse<IEnumerable<CategoryItem>>();
            try
            {
                result = await _offerService.getOffers(pageNum, itemsPerPage);
                if (!result.HasErrors)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                result.HasErrors = true;
                result.Message = ex.Message;
            }
            return BadRequest(result);
        }

        
    }
}