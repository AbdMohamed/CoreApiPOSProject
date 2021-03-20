using OurCart.Infrastructure.Services;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.Infrastructure.Util;

namespace OURCart.Infrastructure.Services
{
    public class CurrentDailyTransfterHeadersService : BaseRepository<PoscurrentDailyTransHeader>, ICurrentDailyTransfterHeaderService
    {
        public CurrentDailyTransfterHeadersService(OurCartDBContext dbContext) : base(dbContext)
        {
        }
    }
}
