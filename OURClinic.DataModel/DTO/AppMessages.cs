using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OURCart.DataModel.DTO
{
    public partial class AppMessages
    {
        [Key]
        public decimal AppMessageID { get; set; }
        public decimal fkAreaID { get; set; }
        public decimal fkDelClientID { get; set; }
        public string MSGTitle { get; set; }
        public string MSGContents { get; set; }


        public string MSGTitleEn { get; set; }
        public string MSGContentsEn { get; set; }
        public bool MSGSent { get; set; }

        public string insDate { get; set; }
        public string sentDate { get; set; }




    }
}
