using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OurCart.Infrastructure.Services;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static OURCart.Infrastructure.Util.Enums;


namespace OURCart.Infrastructure.Services
{
    public class AppMessagesService : BaseRepository<AppMessages>, IAppMessagesService
    {

        public AppMessagesService(OurCartDBContext _dbContext) : base(_dbContext)
        {

        }

        

        public async Task<OperationResponse<IEnumerable<AppMessages>>> getMessages(decimal? clientID)
        {
            OperationResponse<IEnumerable<AppMessages>> or = new OperationResponse<IEnumerable<AppMessages>>();
            try
            {
                var ItemList = await _dbContext.AppMessages.Where(i =>
                 i.fkDelClientID == clientID

                 || clientID==null).ToListAsync();

                or.Data = ItemList;
                or.HasErrors = false;
                or.StatusCode = "200";
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                or.HasErrors = true;
                or.Message = msg;
            }
            return or;

        }
    }
}