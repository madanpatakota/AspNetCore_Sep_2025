using Introduction.Models;
using Microsoft.EntityFrameworkCore;
using TestApp.API.Models;

namespace Introduction.Data
{
    public class BankDataDBContext :DbContext
    {

        //options  contains the Connection related details
        public BankDataDBContext(DbContextOptions<BankDataDBContext> options):base(options)
        {

        }

        //models ---> go as tables into the database 

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankTransaction>  Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Branch> Branchs { get; set; }

        //public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
