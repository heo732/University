using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseOfIndustrialGoods.Models
{
    public class WarehousePlace
    {
        #region Properties

        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public string Name { get; set; }

        [InverseProperty("SourcePlace")]
        public ICollection<ProductMoving> ProductMovingsSource { get; set; }

        [InverseProperty("TargetPlace")]
        public ICollection<ProductMoving> ProductMovingsTarget { get; set; }

        public ICollection<Preparation> Preparations { get; set; }

        #endregion Properties

        #region Constructors

        public WarehousePlace()
        {
            ProductMovingsSource = new List<ProductMoving>();
            ProductMovingsTarget = new List<ProductMoving>();
            Preparations = new List<Preparation>();
        }

        #endregion Constructors
    }
}