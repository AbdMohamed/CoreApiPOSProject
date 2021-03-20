using OurCart.DataModel;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURClinic.Core.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OURCart.Core.IServices
{
    public interface ICartService : IRepository<CartProducts>
    {
        Task<OperationResponse<cartItemsWithFees>> getAllCartProductsByUserID(decimal userID);

        //abdelrhman mohamed start 15-1-2021
        Task<OperationResponse<Object>> AddItemToUserCart(CartProducts item);
        //abdelrhman mohamed end 15-1-2021
        Task<OperationResponse<decimal>> getTotalPrice(decimal userID);
        Task<OperationResponse<bool>> ClearUserCart(decimal userID);
        Task<OperationResponse<bool>> DeleteItemFromUSerCart(CartProducts item);
        Task<OperationResponse<bool>> UpdateItemInCart(CartProducts cartItem);
    }
}
