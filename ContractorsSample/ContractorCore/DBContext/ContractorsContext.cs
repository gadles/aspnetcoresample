using ContractorCore.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ContractorCore.DBContext
{
    public class ContractorsContext : DbContext
    {

        public ContractorsContext(DbContextOptions<ContractorsContext> options) : base(options)
        {

        }

        #region DBSets
        public DbSet<oContractor> Contractors { get; set; }
        #endregion

        #region DBCreate
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}
