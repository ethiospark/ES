using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EthioSpark.Entities;
using EthioSpark.Entities.Profile;

namespace EthioSpark.DataAccess
{
    public class EthioSparkContext : DbContext
    {
        public EthioSparkContext():base("name=EthioSparkConnectionString")
        {}

      
        public DbSet<CodeSet> CodeSets { get; set; }
        public DbSet<CodeValue> CodeValues { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        //Profile
        public DbSet<PrflAttr> PrflAttrs { get; set; }
        public DbSet<PrflAttrGrp> PrflAttrGrps { get; set; }
        public DbSet<PrflAttrValue> PrflAttrValues { get; set; }
        public DbSet<PrflCtx> PrflCtxs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention
            // so that the generated tables would not have pluralized names.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Turn off lazy loading(for performance).
            Configuration.LazyLoadingEnabled = false;

            modelBuilder.Entity<PrflAttr>()
            .Map<PrflListAttr>(m => m.Requires("AttrType").HasValue(0))
            .Map<PrflTxtAttr>(m => m.Requires("AttrType").HasValue(1));
        }

    }
}