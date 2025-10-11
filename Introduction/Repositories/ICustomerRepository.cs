using Introduction.Models;

namespace Introduction.Repositories
{
    public interface ICustomerRepository
    {


        Task<IEnumerable<Customer>> GetAllCustomers();
        //Task<List<Customer>> GetAll();


        //IEnumerable is the interface which is parent of the List is the class


    }
}
