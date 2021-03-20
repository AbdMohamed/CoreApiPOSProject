using OurCart.DataModel;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURClinic.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface ICategoryService : IRepository<ItemCategory>
    {
        Task<OperationResponse<itemsResponseData>> getAllProductsInCategory(int? catID, int pageNum, int itemsPerPage, int? PriceFilter, int? NameFilter, string SearchText);
        Task<OperationResponse<CategoryItemsDisplayItem>> getProductDataByItemIDandPAckagedID(int itemID, decimal? itemPackageID);
        Task<OperationResponse<offersResponseData>> getAllOffersInCategory(int catID, int pageNum, int itemsPerPage);
        Task<OperationResponse<IEnumerable<CategoryModel>>> GetCategories(int? parentCatID, int pageNum, int itemsPerPage, decimal? userId, string GcmToken);
        Task<OperationResponse<IEnumerable<Items>>> SearchByItemBarcode(string SearchText);
        Task<OperationResponse<IEnumerable<Items>>> SearchByItemName(string Name);

    }
}
