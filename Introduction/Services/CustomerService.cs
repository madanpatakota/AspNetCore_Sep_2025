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


       

        public Task<CustomerReadDTO> GetCustomerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCustomer(CustomerUpdateDTO dto , int id)
        {
            // throw new NotImplementedException();
            var entity = await _repo.GetCustomerAsyncById(id);

            if (entity == null) {
                return false;
            }

            var upatedEntity = new Customer();
            upatedEntity.Address = dto.CustomerAddress;
            upatedEntity.City = dto.CustomerCity;
            await _repo.UpdateCustomerAsync(upatedEntity);
            return true;


        }

        Task<IEnumerable<CustomerReadDTO>> ICustomerService.GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
