using Airport.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airport
{
    public class Context : DbContext
    {
        public DbSet<PlaneType> PlaneTypes { get; set; }

        public DbSet<FlightType> FlightTypes { get; set; }

        public DbSet<FlightState> FlightStates { get; set; }

        public DbSet<TicketState> TicketStates { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Plane> Planes { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Administration> Administrations { get; set; }

        public DbSet<MedicalExamination> MedicalExaminations { get; set; }

        public DbSet<Inspection> Inspections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(@"User Id=SYS; Password=admin; DBA Privilege=SYSDBA; Data Source=localhost:1521/xe;");
        }
    }
}