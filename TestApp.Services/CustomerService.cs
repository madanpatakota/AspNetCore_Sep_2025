using Introduction.DTOs;
using Introduction.Models;
using Introduction.Repositories;
using Microsoft.JSInterop.Infrastructure;

namespace Introduction.Services
{
    public class CustomerService : ICustomerService
    {


        private readonly ICustomerRepository _repo;

        public CustomerService(ICustomerRepository repo) {
             _repo = repo;
        }


        public async Task<CustomerReadDTO> CreateCustomer(CustomerCreateDTO dto)
        {

            var entity = new Customer();


            //Lets convert the DTO into the Entity
            entity.Address = dto.CustomerAddress;
            entity.City    = dto.CustomerCity;
            entity.Name    = dto.CustomerName;


            await _repo.CreateCustomerAsync(entity);


            return new CustomerReadDTO
            {
                Id = entity.Id,
                CustomerName    = dto.CustomerName,
                CustomerAddress = dto.CustomerAddress,
                CustomerCity    = dto.CustomerCity
            };

        }

        public async Task<bool> DeleteAsync(int id)
        {

            var entity = await _repo.GetCustomerAsyncById(id);

            if (entity == null) {
                return false;
            }


            await _repo.DeleteCustomerAsync(entity);
            return true;

            //throw new NotImplementedException();
        }


        /// <summary>
        /// Single Customer not List of Customes
        /// </summary>
        /// <param name="id">Example : MID1234</param>
        /// <returns>Single CustomerDTO</returns>

        public async Task<CustomerReadDTO> GetCustomerByIdAsync(int id)
        {
            //throw new NotImplementedException();
            var data = await _repo.GetCustomerAsyncById(id);   // Single customer


            var output = new CustomerReadDTO
            {
                Id = data.Id,
                CustomerName = data.Name,
                CustomerAddress = data.Address,
                CustomerCity = data.City
            };

            return output;

        }



        /// <summary>
        ///  Example : INcase id is 6 then here Robert
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCustomer(CustomerUpdateDTO dto , int id)
        {
            // throw new NotImplementedException();
            var entity = await _repo.GetCustomerAsyncById(id); //Check the record with the ID incase of 100000

            if (entity == null) {
                return false;
            }

            //var upatedEntity = new Customer();
            entity.Address = dto.CustomerAddress;
            entity.City = dto.CustomerCity;

            await _repo.UpdateCustomerAsync(entity);
            return true;

        }

        public async Task<IEnumerable<CustomerReadDTO>> GetAllCustomersAsync()
        {
             var data = await _repo.GetAllCustomersAsync();   // List of Customer

            //     public int Id { get; set; }
            //public string CustomerName { get; set; }

            //public string CustomerAddress { get; set; }

            //public string CustomerCity { get; set; }


           var output = data.Select(customer => new CustomerReadDTO
            {

                  Id               = customer.Id,
                  CustomerName     = customer.Name,
                  //CustomerAddress  = customer.Address,
                  //CustomerCity     = customer.City
            });


            return output;




             //return type is CustomerReadDTO
            //throw new NotImplementedException();
        }
    }
}
