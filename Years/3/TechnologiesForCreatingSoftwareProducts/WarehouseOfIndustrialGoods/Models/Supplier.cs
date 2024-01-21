using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Supplier
    {
        #region Properties

        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public string Name { get; set; }

        public ICollection<Supply> Supplies { get; set; }

        #endregion Properties

        #region Constructors

        public Supplier()
        {
            Supplies = new List<Supply>();
        }

        #endregion Constructors
    }
}