using Account.API.Models;

namespace Account.API
{
    public interface ICustomersDataStore
    {
        List<CustomerDto> GetAllCustomers();
    }
}