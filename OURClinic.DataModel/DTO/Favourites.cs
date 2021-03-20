using System.ComponentModel.DataAnnotations.Schema;

namespace OURCart.DataModel.DTO
{
    public partial class Favourites
    {
        public int Id { get; set; }
        public decimal FkItemID { get; set; }

        public decimal FkItemPackageId { get; set; }
        public decimal FkDeliveryClientId { get; set; }
        public string InsDateTime { get; set; }
        [ForeignKey("FkItemID")]

        public virtual Items Item { get; set; }

    }
}
