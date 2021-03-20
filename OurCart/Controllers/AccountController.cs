using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OurCart.DataModel;
using OurCart.Utils;
using OURCart.Core.IServices;
using OURCart.DataModel.DTO;
using OURCart.DataModel.DTO.LocalModels;
using OURCart.Infrastructure.Util;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OurCart.Controllers
{

    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : BaseController<DeliveryClient>
    {
        private IConfiguration _config;
        IAccountService _accountService;
        public AccountController(IAccountService accountService, OurCartDBContext _OurERPClinicContext, IConfiguration config) : base(_OurERPClinicContext)
        {
            _accountService = accountService;
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            OperationResponse<dynamic> or = new OperationResponse<dynamic>();
            try
            {
                var result = await _accountService.Login(loginModel);
                var result2 = await _accountService.salesLogin(loginModel);

                if (result.HasErrors == false)
                {
                    string token = GenerateJSONWebToken(result.Data.DelClientId.ToString());
                    or.Data = new { userData = result.Data, token = token };
                }
                else if (result2.HasErrors == false)
                {
                    string token = GenerateJSONWebToken(result2.Data.UserID.ToString());
                    or.Data = new { userData = result2.Data, token = token };
                }
                else
                {
                    or.HasErrors = result.HasErrors;
                    or.Message = result.Message;
                }
                return resultWithStatus(or);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                or.Message = ex.Message;
                or.HasErrors = true;
            }
            return BadRequest(or);
        }
        [HttpGet("GetUserData")]
        public async Task<IActionResult> GetUserData([FromQuery] decimal UserId)
        {
            OperationResponse<dynamic> or = new OperationResponse<dynamic>();

            var result = await _accountService.GetUserData(UserId);

            return resultWithStatus(result);

        }
        [HttpPut("UpdateUserData")]
      

        public IActionResult UpdateUserData([FromBody]DeliveryClient User)
        {
            OperationResponse<bool> or = new OperationResponse<bool>();

            var result =  _accountService.UpdateUserData(User);

            return resultWithStatus(result);

        }
        private string GenerateJSONWebToken(string EmpID)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"], claims: new Claim[] { new Claim("EmpID", EmpID) }
              ,
              expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:ExpireMin"])),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost("create")]
        [ModelStateValidation]

        public async Task<IActionResult> Register([FromBody]DeliveryClient registerModel)
        {

            OperationResponse<dynamic> response = new OperationResponse<dynamic>();
            if (ModelState.IsValid)
            {
                registerModel.InsDate = DateTime.Now;
                var result = await _accountService.createAccount(registerModel);
                if (!result.HasErrors)
                {
                    string token = GenerateJSONWebToken(result.Data.DelClientId.ToString());
                    response.Data = new { userData = result.Data, token = token };
                }
                else
                {
                    response.HasErrors = result.HasErrors;
                    response.Message = result.Message;
                }
            }
            else
            {
                response.HasErrors = true;
                response.Message = ModelStateUtil.GETModelStateErrorMSG(ModelState);
            }
            return resultWithStatus(response);
        }


        [HttpPut("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordModel changePasswordModel)
        {
            var result = await _accountService.changePassword(changePasswordModel);
            return resultWithStatus(result);
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult>  forgotPassword([FromBody] forgetPassword Email)
        {
            var result = await _accountService.forgotPassword(Email);
            return resultWithStatus(result);
        }


    }
}