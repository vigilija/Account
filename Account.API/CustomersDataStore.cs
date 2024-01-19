using Account.API.Models;

namespace Account.API
{
    public class CustomersDataStore : ICustomersDataStore
    {
        private List<CustomerDto> Customers { get; set; }

        public CustomersDataStore()
        {
            Customers = new List<CustomerDto>()
            {
                new CustomerDto
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Thomas",
                    Surname = "Smith",
                },
                new CustomerDto
                {
                    Id= Guid.NewGuid().ToString(),
                    Name = "James",
                    Surname = "Lee",
                }
            };
        }

        public List<CustomerDto> GetAllCustomers()
        {
            return Customers;
        }
    }
}
