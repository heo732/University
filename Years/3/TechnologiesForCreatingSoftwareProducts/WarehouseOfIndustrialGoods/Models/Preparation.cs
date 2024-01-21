using System;
using System.ComponentModel.DataAnnotations;

namespace WarehouseOfIndustrialGoods.Models
{
    public class Preparation
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
        public DateTime DateTimeStart { get; set; }

        [ConcurrencyCheck]
        public DateTime DateTimeEnd { get; set; }

        [ConcurrencyCheck]
        [Required]
        public int PlaceId { get; set; }

        public WarehousePlace Place { get; set; }

        #endregion Properties
    }
}