
using Introduction.Data;
using Introduction.Models;
using Microsoft.EntityFrameworkCore;

namespace Introduction.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {


        private readonly BankDataDBContext _bankDataDBContext;


        //Repositoryies always works with DBContext 

        public CustomerRepository(BankDataDBContext bankDataDBContext)
        {
            _bankDataDBContext = bankDataDBContext;
        }



        /// <summary>
        /// CreateCustomerAsync  which is for add new customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateCustomerAsync(Customer entity)
        {
           await _bankDataDBContext.Customers.AddAsync(entity);   // Add
           await _bankDataDBContext.SaveChangesAsync();
            //throw new NotImplementedException();
        }


        /// <summary>
        ///  prepare the method for delete customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task DeleteCustomerAsync(Customer entity)
        {
                  _bankDataDBContext.Customers.Remove(entity);
            await _bankDataDBContext.SaveChangesAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _bankDataDBContext.Customers.ToListAsync();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Cusomer</returns>
        public async Task<Customer> GetCustomerAsyncById(int ID)
        {
            //Find method  -sync
            return await _bankDataDBContext.Customers.FindAsync(ID);
            //throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync(Customer entity)
        {
             _bankDataDBContext.Customers.Update(entity);   // Add
             await _bankDataDBContext.SaveChangesAsync();
            //throw new NotImplementedException();
        }
    }
}
