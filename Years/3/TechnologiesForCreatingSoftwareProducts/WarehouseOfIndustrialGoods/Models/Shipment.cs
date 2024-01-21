using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Shipment
    {
        #region Properties

        [Key]
        [ForeignKey("ProductMoving")]
        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int ConsumerId { get; set; }

        public Consumer Consumer { get; set; }

        public ProductMoving ProductMoving { get; set; }

        #endregion Properties
    }
}