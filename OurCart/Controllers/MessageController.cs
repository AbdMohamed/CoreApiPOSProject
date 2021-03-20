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
    [Route("api/Messages")]


    public class MessageController : BaseController<CartProducts>
    {
        IAppMessagesService _appMessagesService;
        public MessageController(OurCartDBContext _dbContext, IAppMessagesService appMessagesService) : base(_dbContext)
        {

            _appMessagesService = appMessagesService;
        }

        [HttpGet("getMessages")]
        public async Task<IActionResult> getMessages([FromQuery] decimal? clientID)
        {
            var result = await _appMessagesService.getMessages(clientID);
            return resultWithStatus(result);
        }
       

    }
}