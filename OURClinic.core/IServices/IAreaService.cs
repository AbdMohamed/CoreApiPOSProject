using OurCart.DataModel;
using OURCart.DataModel.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface IAreaService
    {
        Task<OperationResponse<IEnumerable<Area>>> getAllAreas();
    }
}
