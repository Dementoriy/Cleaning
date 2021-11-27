using Microsoft.EntityFrameworkCore;

namespace CleaningDLL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Address> Address { get; set; }
        public DbSet<Application> Application { get; set; }
        public DbSet<Brigade> Brigade { get; set; }
        public DbSet<Client> CLient { get; set; }
        public DbSet<Consumable> Consumable { get; set; }
        public DbSet<Consumption_Rate> Consumption_Rate { get; set; }
        public DbSet<Contract> Contract { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Delivery_Content> Delivery_Content { get; set; }
        public DbSet<Delivery_Contract> Delivery_Contract { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Inventory_Type> Inventory_Type { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<Provided_Service> Provided_Service { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<PurchaseRequisition> PurchaseRequisition { get; set; }
        public DbSet<ReferenceUnitsOfMeasurement> ReferenceUnitsOfMeasurement { get; set; }
        public DbSet<RequisitionContent> RequisitionContent { get; set; }
        public DbSet<Service> Service { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=;Port=;Database=;Username=;Password=");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasIndex(s => s.EmployeeTelefonNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(s => s.PassportData).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(s => s.ClientTelefonNumber).IsUnique();
            modelBuilder.Entity<Client>().HasIndex(s => s.ClientTelefonNumber).IsUnique();
            modelBuilder.Entity<Provider>().HasIndex(s => s.CompanyName).IsUnique();
            modelBuilder.Entity<Provider>().HasIndex(s => s.ProviderTelefonNumber).IsUnique();
            modelBuilder.Entity<ReferenceUnitsOfMeasurement>().HasIndex(s => s.Unit).IsUnique();
            modelBuilder.Entity<Consumable>().HasIndex(s => s.Consumable_Name).IsUnique();
        }
    }
}
