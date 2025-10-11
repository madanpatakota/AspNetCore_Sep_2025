using Introduction.DTOs;

namespace Introduction.Services
{
    public interface ICustomerService
    {
       Task<IEnumerable<CustomerDTO>>  GetAllCustomersAsync();
    }
}
