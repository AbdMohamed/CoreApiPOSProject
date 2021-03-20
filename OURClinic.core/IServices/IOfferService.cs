using OurCart.DataModel;
using OURCart.DataModel.DTO.LocalModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface IOfferService
    {
        Task<OperationResponse<IEnumerable<CategoryItem>>> getOffers(int pageNum, int ItemsPerPage);
    }
}
