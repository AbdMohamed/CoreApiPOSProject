using OurCart.Infrastructure.Services;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.Infrastructure.Util;

namespace OURCart.Infrastructure.Services
{
    public class CurrentDailyTransfterDetailsService : BaseRepository<PoscurrentDailyTransDetails>, ICurrentDailyTransfterDetailsService
    {
        public CurrentDailyTransfterDetailsService(OurCartDBContext dbContext) : base(dbContext)
        {
        }
    }
}
