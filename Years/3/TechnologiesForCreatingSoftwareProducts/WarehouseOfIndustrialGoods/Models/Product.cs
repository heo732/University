using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Product
    {
        #region Properties

        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public string Name { get; set; }

        public ICollection<ProductMoving> ProductMovings { get; set; }

        public ICollection<Preparation> Preparations { get; set; }

        #endregion Properties

        #region Constructors

        public Product()
        {
            ProductMovings = new List<ProductMoving>();
            Preparations = new List<Preparation>();
        }

        #endregion Constructors
    }
}