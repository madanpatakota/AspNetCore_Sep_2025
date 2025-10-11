using Introduction.DTOs;
using Introduction.Repositories;

namespace Introduction.Services
{
    public class CustomerService : ICustomerService
    {


        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo) {
             _repo = repo;
        }


        //public int Id { get; set; }
        //public string CustomerName { get; set; }

        //public string CustomerAddress { get; set; }

        public async Task<IEnumerable<CustomerDTO>> GetAllCustomersAsync()
        {

            var customersList = await _repo.GetAllCustomers();    // Customrs from  DB 

            var customersDTOList = customersList.Select(cus => new CustomerDTO()
            {
                Id = cus.Id,
                CustomerName = cus.Name,
                CustomerAddress  = cus.Address
            });                                                  // Cusomers ---> CustomerDTO

            return customersDTOList;



            //focus on the reutrn type


            //return await _repo.GetAllCustomers();
            //throw new NotImplementedException();
        }
    }
}
