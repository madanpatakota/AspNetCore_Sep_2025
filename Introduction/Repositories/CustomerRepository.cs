
using Introduction.Data;
using Introduction.Models;
using Microsoft.EntityFrameworkCore;

namespace Introduction.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly TestDataDBContext _testDataDBContext;


        

        //Repositoryies always works with DBContext 

        public CustomerRepository(TestDataDBContext testDataDBContext)
        {
            _testDataDBContext = testDataDBContext;
        }



        //.toList--->Sync call
        //.ToListAsync() --> Async call

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {

            return await _testDataDBContext.Customers.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
