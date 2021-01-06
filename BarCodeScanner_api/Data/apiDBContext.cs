using BarCodeScanner_api.Models;
using Microsoft.EntityFrameworkCore;

namespace BarCodeScanner_api.Data
{
    public class apiDBContext : DbContext
    {

        public DbSet<DeviceSetupModel> SetupModels { get; set; }
        public DbSet<ProductRecords> ProductRecords { get; set; }
        //public DbSet<MasterKeys> FieldMasterKey { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DAVICS\\DAVICSSQL; initial catalog=BarcodeDB;integrated security=SSPI;");

        }

    }
}
