using OurCart.DataModel;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURClinic.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface IFavouriteService : IRepository<Favourites>
    {
        // get all favourites
        Task<OperationResponse<List<CategoryItem>>> getUserFAV(decimal userID);
        // add item to fav
        // remove item from fav 
        Task<OperationResponse<Favourites>> AddItemToFAV(FavSendModel itemToAdd);
        Task<OperationResponse<bool>> RemoveItemFromFAVAsync(FavSendModel itemToAdd);

        //get status of item in fav
        Task<OperationResponse<bool>> getItemStatusInFav(FavSendModel itemToAdd);

    }
}
