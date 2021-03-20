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
    public interface IAccountService : IRepository<DeliveryClient>
    {
        Task<OperationResponse<DeliveryClient>> createAccount(DeliveryClient registerModel);
        Task<OperationResponse<DeliveryClient>> GetUserData(decimal UserId);
        Task<OperationResponse<DeliveryClient>> Login(LoginModel loginModel);
        Task<OperationResponse<SalesRep>> salesLogin(LoginModel loginModel);


        // reset password if old password is correct
        Task<OperationResponse<bool>> changePassword(ChangePasswordModel loginModel);
        Task<OperationResponse<object>> forgotPassword(forgetPassword Email);

        OperationResponse<DeliveryClient> UpdateUserData(DeliveryClient loginModel);




    }
}
