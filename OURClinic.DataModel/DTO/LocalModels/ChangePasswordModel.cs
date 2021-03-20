using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.DataModel.DTO.LocalModels
{
    public class ChangePasswordModel
    {
        public decimal userID { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

    }
}
