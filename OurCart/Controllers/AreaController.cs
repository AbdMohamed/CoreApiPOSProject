using Microsoft.AspNetCore.Mvc;
using OURCart.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurCart.Controllers
{
    [Route("api/Area")]
    public class AreaController : Controller
    {
        IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: api/Area
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _areaService.getAllAreas();
            if (!result.HasErrors)
                return Ok(result);
            return BadRequest(result);

        }

    }
}
