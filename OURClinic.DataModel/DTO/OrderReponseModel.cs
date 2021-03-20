using System.Collections.Generic;

namespace OURCart.DataModel.DTO
{
    public class OrderReponseModel
    {
        public PoscurrentDailyTransHeader header { get; set; }
        public List<PoscurrentDailyTransDetails> details { get; set; }

    }
}
