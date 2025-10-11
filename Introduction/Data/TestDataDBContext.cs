using Introduction.Models;
using Microsoft.EntityFrameworkCore;

namespace Introduction.Data
{
    public class TestDataDBContext :DbContext
    {

        //options  contains the Connection related details
        public TestDataDBContext(DbContextOptions<TestDataDBContext> options):base(options)
        {

        }

        //models ---> go as tables into the database 

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
