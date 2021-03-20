using OurCart.DataModel;
using OURCart.DataModel.DTO;
using OURClinic.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface IAppMessagesService : IRepository<AppMessages>
    {
        Task<OperationResponse<IEnumerable<AppMessages>>> getMessages(decimal? clientID);

    }
}
