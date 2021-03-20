using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OurCart.DataModel;
using OurCart.Infrastructure.Services;
using OURCart.Core.IServices;
using OURCart.Core.Util;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMatrix.WebData;

namespace OURCart.Infrastructure.Services
{
    public class AccountService : BaseRepository<DeliveryClient>,IAccountService
    {
        public AccountService(OurCartDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<OperationResponse<bool>> changePassword(ChangePasswordModel changePasswordModel)
        {
            OperationResponse<bool> response = new OperationResponse<bool>();
            try
            {
                var user = await _dbContext.DeliveryClient.Where(c => c.DelClientId == changePasswordModel.userID && c.Password == HashingUtility.hashPassword(changePasswordModel.oldPassword)).FirstOrDefaultAsync();
                if (user != null)
                {
                    user.Password = HashingUtility.hashPassword(changePasswordModel.newPassword);

                }
                var rowsAffectred = _dbContext.SaveChanges();
                if (rowsAffectred > 0)
                    response.Data = true;
                else
                {
                    response.HasErrors = true;
                    response.Message = "Error in Creating User";
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                response.HasErrors = true;
                response.Message = msg;
            }
            return response;
        }

        public async Task<OperationResponse<DeliveryClient>> createAccount(DeliveryClient registerModel)
        {
            OperationResponse<DeliveryClient> response = new OperationResponse<DeliveryClient>();
            try
            {
                if (_dbContext.DeliveryClient.Where(c => c.Email == registerModel.Email).Any())
                    throw new Exception("user email exists before");
                 if (_dbContext.DeliveryClient.Where(c => c.Phone1 == registerModel.Phone1).Any())
                    throw new Exception("phone number exists before");
                registerModel.Password = HashingUtility.hashPassword(registerModel.Password);
                _dbContext.DeliveryClient.Add(registerModel);
                var rowsAffectred = _dbContext.SaveChanges();
               
                if (rowsAffectred > 0)
                    response.Data = registerModel;
                else
                {
                    response.HasErrors = true;
                    response.Message = "Error in Creating User";
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                response.HasErrors = true;
                response.Message = msg;
            }
            if (response.Data != null)
                response.Data.Password = "";
            return response;
        }

        public async Task<OperationResponse<DeliveryClient>> Login(LoginModel loginModel)
        {
            OperationResponse<DeliveryClient> or = new OperationResponse<DeliveryClient>();
            try
            {
                var user = await _dbContext.DeliveryClient.Where(c => c.Phone1 == loginModel.PhoneNumber && c.Password == HashingUtility.hashPassword(loginModel.password)).FirstOrDefaultAsync();
               
                if (user != null)
                {
                    if (loginModel.GcmToken != null)
                    {
                        user.GcmToken = loginModel.GcmToken;
                        _dbContext.SaveChanges();
                    }

                    user.Password = null;
                    or.Data = user;
                }
                else
                    throw new Exception("Incorrect phone number or password");


            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }

        public async Task<OperationResponse<SalesRep>> salesLogin(LoginModel loginModel)
        {
            OperationResponse<SalesRep> or = new OperationResponse<SalesRep>();
            try
            {
                var user = await _dbContext.SalesRep.Where(c => c.Phone == loginModel.PhoneNumber && c.Password == HashingUtility.hashPassword(loginModel.password)).FirstOrDefaultAsync();

                if (user != null)
                {
                    if (loginModel.GcmToken != null)
                    {
                        user.GcmToken = loginModel.GcmToken;
                        _dbContext.SaveChanges();
                    }
                    user.Password = null;
                    or.Data = user;
                }

                else
                    throw new Exception("Incorrect phone number or password");
            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }


        public async Task<OperationResponse<DeliveryClient>> GetUserData(decimal UserId)
        {
            OperationResponse<DeliveryClient> or = new OperationResponse<DeliveryClient>();
            try
            {
                
                if (UserId == 0)
                    throw new Exception("Add user id");
                var user = await _dbContext.DeliveryClient.FindAsync(UserId);
                if (user != null)
                {

                    user.Password = null;
                    or.Data = user;
                }
                else
                    throw new Exception("User not found");
            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }

        public OperationResponse<DeliveryClient> UpdateUserData(DeliveryClient UserU)
        {
            OperationResponse<DeliveryClient> response = new OperationResponse<DeliveryClient>();
            try
            {
                var user =  _dbContext.DeliveryClient.Where(c => c.DelClientId == UserU.DelClientId ).First();
                if (user != null)
                {
                    //user.Password = HashingUtility.hashPassword(changePasswordModel.newPassword);
                    user.ClientName = (UserU.ClientName==null || UserU.ClientName==string.Empty)? user.ClientName: UserU.ClientName;
                    user.ClientNameEn = (UserU.ClientNameEn == null || UserU.ClientNameEn == string.Empty) ? user.ClientNameEn : UserU.ClientNameEn; 

                    user.Phone1 = (UserU.Phone1 == null || UserU.Phone1 == string.Empty) ? user.Phone1 : UserU.Phone1; 
                    user.Address = (UserU.Address == null || UserU.Address == string.Empty) ? user.Address : UserU.Address;
                    user.FkAreaId = (UserU.FkAreaId == null || UserU.FkAreaId == 0) ? user.FkAreaId : UserU.FkAreaId; //


                    user.Floor = (UserU.Floor == null || UserU.Floor == string.Empty) ? user.Floor : UserU.Floor;
                    user.Apartment = (UserU.Apartment == null || UserU.Apartment == string.Empty) ? user.Apartment : UserU.Apartment;
                    user.SpecialMark = (UserU.SpecialMark == null || UserU.SpecialMark == string.Empty) ? user.SpecialMark : UserU.SpecialMark;
                    user.Email = (UserU.Email == null || UserU.Email == string.Empty) ? user.Email : UserU.Email;
                    user.LocationAddress = (UserU.LocationAddress == null || UserU.LocationAddress == string.Empty) ? user.LocationAddress : UserU.LocationAddress;
                    user.HouseNum = (UserU.HouseNum == null || UserU.HouseNum == string.Empty) ? user.HouseNum : UserU.HouseNum;
                    _dbContext.DeliveryClient.Update(user);

                }
                var rowsAffectred = _dbContext.SaveChanges();
                if (rowsAffectred > 0)
                {
                    response.Data = user;
                    response.StatusCode = "200";
                    response.HasErrors = false;
                }
                else
                {
                    response.HasErrors = true;
                    response.Message = "Error in Updating User";
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                response.HasErrors = true;
                response.Message = msg;
            }
            return response;
        }

        public async Task<OperationResponse<object>> forgotPassword(forgetPassword forgetPasswordObj)
        {
            OperationResponse<object> or = new OperationResponse<object>();
            try
            {
                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var tempPass = GenerateRandomPassword();
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress("ashmonyabdo1@gmail.com", "Gelany"),
                    Subject = "New Password",
                    // PlainTextContent = "Hello, Email!",
                    HtmlContent = "<strong> this is New password!    </strong>" + "<h1>" + tempPass.ToString() + "</h1>"
                };
                msg.AddTo(new EmailAddress(forgetPasswordObj.Email, forgetPasswordObj.Email.Split('@')[0].ToString()));
                or.HasErrors = false;
                or.StatusCode = "200";
                or.Data = "true";
                var response = await client.SendEmailAsync(msg);

            }
            catch (Exception ex)
            {
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return or;
        }

        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
    };
            CryptoRandom rand = new CryptoRandom();
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }
    }
}
