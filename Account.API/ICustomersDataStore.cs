using Account.API.Models;

namespace Account.API
{
    public interface ICustomersDataStore
    {
        public List<CustomerDto> GetAllCustomers();
    }
}