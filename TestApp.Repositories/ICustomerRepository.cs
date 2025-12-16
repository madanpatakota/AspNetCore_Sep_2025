using Introduction.DTOs;
using Introduction.Models;

namespace Introduction.Repositories
{
    public interface ICustomerRepository
    {


        //Task<IEnumerable<Customer>> GetAllCustomers();
        //Task<List<Customer>> GetAll();


        //IEnumerable is the interface which is parent of the List is the class


        Task<IEnumerable<Customer>> GetAllCustomersAsync();

        Task<Customer> GetCustomerAsyncById(int ID);     //MID2013 

        Task CreateCustomerAsync(Customer entity);

        Task UpdateCustomerAsync(Customer entity);

        Task DeleteCustomerAsync(Customer entity);


    }
}
