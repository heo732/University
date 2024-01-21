using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseOfIndustrialGoods.Models
{
    public class ProductMoving
    {
        #region Properties

        public int Id { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int CountOfProduct { get; set; }

        [ConcurrencyCheck]
        [Required]
        public DateTime DateTime { get; set; }

        public int? SourcePlaceId { get; set; }

        [ForeignKey("SourcePlaceId")]
        public WarehousePlace SourcePlace { get; set; }

        public int? TargetPlaceId { get; set; }

        [ForeignKey("TargetPlaceId")]
        public WarehousePlace TargetPlace { get; set; }

        public Supply Supply { get; set; }

        public Shipment Shipment { get; set; }

        #endregion Properties
    }
}