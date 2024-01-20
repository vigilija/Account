using Account.API;
using Moq;
using Account.API.Models;
using Account.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Account.Test
{
    public class CustomersControllerTests
    {
        private readonly CustomersController _internalCustomersController;

        public CustomersControllerTests()
        {
            var customersDataStoreMock = new Mock<ICustomersDataStore>();
            customersDataStoreMock
                .Setup(m => m.GetAllCustomers())
                .Returns(
                new List<CustomerDto>() {
                    new CustomerDto
                    {
                        Id = 123.ToString(),
                        Name = "NameTest",
                        Surname = "SurnameTest",
                    },
                    new CustomerDto
                    {
                        Id = 124.ToString(),
                        Name = "NameTest2",
                        Surname = "SurnameTest2",
                    }
                });
            _internalCustomersController = new CustomersController(customersDataStoreMock.Object);
        }

        [Fact]
        public void GetCustomerShouldReturnOkObjectResult()
        {
            //Act
            var result = _internalCustomersController.GetCustomers();

            //Assert
            var actualResult = Assert
                .IsType<ActionResult<IEnumerable<CustomerDto>>>(result);

            Assert.IsType<OkObjectResult>(actualResult.Result);
        }

        [Fact]
        public void GetCustomersShouldReturnCorrectCustomers()
        {
            //Arrange
            var customerList = new List<CustomerDto>() {
                    new CustomerDto
                    {
                        Id = 123.ToString(),
                        Name = "NameTest",
                        Surname = "SurnameTest",
                    },
                    new CustomerDto
                    {
                        Id = 124.ToString(),
                        Name = "NameTest2",
                        Surname = "SurnameTest2",
                    }
                };

            //Act
            var resultCustomers = _internalCustomersController.GetCustomers();
            var resultResult = (OkObjectResult)resultCustomers.Result;
            var resultResultValue = (IEnumerable<CustomerDto>)resultResult.Value;

            //Assert
            Assert.Equal(customerList.First().Name, resultResultValue.First().Name);
            Assert.Equal(customerList.First().Surname, resultResultValue.First().Surname);
            Assert.Equal(customerList.First().Id, resultResultValue.First().Id);

            Assert.Equal(customerList.Last().Id, resultResultValue.Last().Id);
            Assert.Equal(customerList.Last().Name, resultResultValue.Last().Name);
            Assert.Equal(customerList.Last().Surname, resultResultValue.Last().Surname);
        }

        [Fact]
        public void GetCustomerByIdShouldReturnOneCorrectCustomer()
        {
            //Arrange
            var customerList = new List<CustomerDto>() {
                    new CustomerDto
                    {
                        Id = 123.ToString(),
                        Name = "NameTest",
                        Surname = "SurnameTest",
                    },
                    new CustomerDto
                    {
                        Id = 124.ToString(),
                        Name = "NameTest2",
                        Surname = "SurnameTest2",
                    }
                };

            //Act
            var resultCustomers = _internalCustomersController.GetCustomer(customerList.First().Id);
            var resultResult = (OkObjectResult)resultCustomers.Result;
            var resultResultValue = (CustomerDto)resultResult.Value;

            //Assert
            Assert.Equal(customerList.First().Id, resultResultValue.Id);
            Assert.Equal(customerList.First().Name, resultResultValue.Name);
            Assert.Equal(customerList.First().Surname, resultResultValue.Surname);

        }
    }
}