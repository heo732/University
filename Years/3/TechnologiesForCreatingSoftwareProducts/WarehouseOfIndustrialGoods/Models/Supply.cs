using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Supply
    {
        #region Properties

        [Key]
        [ForeignKey("ProductMoving")]
        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        public ProductMoving ProductMoving { get; set; }

        #endregion Properties
    }
}