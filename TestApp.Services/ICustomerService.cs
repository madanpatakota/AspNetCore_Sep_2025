using Introduction.DTOs;
using Introduction.Models;

namespace Introduction.Services
{
    public interface ICustomerService
    {
       Task<IEnumerable<CustomerReadDTO>>  GetAllCustomersAsync();

       Task<CustomerReadDTO> GetCustomerByIdAsync(int id);

       Task<CustomerReadDTO> CreateCustomer(CustomerCreateDTO dto);

       Task<bool> UpdateCustomer(CustomerUpdateDTO dto , int id);

       Task<bool> DeleteAsync(int id);


    }
}
