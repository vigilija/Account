using Account.API.Models;

namespace Account.API
{
    public class CustomersDataStore
    {
        public List<CustomerDto> Customers { get; set; }

        public static CustomersDataStore Instance { get; set; } = new CustomersDataStore();

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
    }
}
