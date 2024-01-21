using System.Data.Entity;
using WarehouseOfIndustrialGoods.Models;

namespace WarehouseOfIndustrialGoods
{
    public class WarehouseOfIndustrialGoodsContext : DbContext
    {
        #region Properties

        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Consumer> Consumers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        public DbSet<Preparation> Preparations { get; set; }

        public DbSet<WarehousePlace> WarehousePlaces { get; set; }

        public DbSet<ProductMoving> ProductMovings { get; set; }

        #endregion Properties

        #region Constructors

        public WarehouseOfIndustrialGoodsContext() : base("DBConnection")
        { }

        #endregion Constructors
    }
}