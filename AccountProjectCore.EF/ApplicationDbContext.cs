using AccountProjectCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountProjectCore.EF
{
    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Holder> Holders { get; set; }
        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(@"Data Source=EVI\\SQLEXPRESS; Initial Catalog=AccountProjectDB; Integrated Security=True; MultipleActiveResultSets=True");
                optionsBuilder.UseSqlServer("Server=Evi\\SQLEXPRESS;Database=AccountProject2DB;Trusted_Connection=True;MultipleActiveResultSets=true");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountHolder>()
                .HasKey(a => new { a.AccountId, a.HolderId });

            base.OnModelCreating(modelBuilder); // to evala giati sto add-migration evgaze The entity type 'IdentityUserLogin<int>' requires a primary key to be defined.
        }

    }
    public class AccountDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //            optionsBuilder.UseSqlServer(@"Server=THALES\\SQLSRV2017;Database=ShipMgmt;Trusted_Connection=True;");
            // optionsBuilder.UseSqlServer(@"Data Source=EVI\SQLEXPRESS; Initial Catalog=AccountProjectDB; Integrated Security=True; MultipleActiveResultSets=True;");
            //   optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=AccountProjectDB; Trusted_Connection=True;");
            optionsBuilder.UseSqlServer("Server=Evi\\SQLEXPRESS;Database=AccountProject2DB;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
        //}
    }
}
