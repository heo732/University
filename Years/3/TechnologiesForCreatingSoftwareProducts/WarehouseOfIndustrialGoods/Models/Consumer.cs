using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Consumer
    {
        #region Properties

        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public string Name { get; set; }

        public ICollection<Shipment> Shipments { get; set; }

        #endregion Properties

        #region Constructors

        public Consumer()
        {
            Shipments = new List<Shipment>();
        }

        #endregion Constructors
    }
}