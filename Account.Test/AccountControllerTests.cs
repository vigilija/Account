using Account.API.Controllers;
using Account.API.Models;
using Account.API;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Account.Test
{
    public class AccountControllerTests
    {
        private readonly AccountController _internalAccountController;
        // private readonly AccountController _accountController;
        private readonly string _customerIdToTest = 123.ToString();

        public AccountControllerTests()
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
            _internalAccountController = new AccountController(customersDataStoreMock.Object);
        }

        [Fact]
        public void PostAccountShouldReturnCreatedAtRoutejectResult()
        {
            //Arrange
            var accountForCreation = new AccountForCreationDto();

            //Act            
            var result = _internalAccountController.CreateAccount(_customerIdToTest, accountForCreation);

            //Assert
            var actualResult = Assert
                .IsType<ActionResult<AccountDto>>(result);

            Assert.IsType<CreatedAtRouteResult>(actualResult.Result);
        }

        [Fact]
        public void PostAccountWithBalance0ShouldCreateAccountNoTransaction()
        {
            //Arrange
            var accountForCreation = new AccountForCreationDto() { Balance = 0 };
            var account = new AccountDto() { Balance = 0 };

            //Act
            var result = _internalAccountController.CreateAccount(_customerIdToTest, accountForCreation);
            var resultResult = (CreatedAtRouteResult)result.Result;
            var resultResultValue = (AccountDto)resultResult.Value;

            //Assert
            Assert.Equal(account.Balance, resultResultValue.Balance);
            Assert.Equal(account.Transactions.Count, resultResultValue.Transactions.Count);
        }

        [Fact]
        public void PostAccountWithBalance10ShouldCreateAccountAndTransactionWithBalance10()
        {
            //Arrange
            var accountForCreation = new AccountForCreationDto() { Balance = 10 };
            var transaction = new TransactionDto() { Amount = 10 };
            var account = new AccountDto()
            {
                Balance = 10,
                Transactions = new List<TransactionDto>()
            };
            account.Transactions.Add(transaction);

            //Act
            var result = _internalAccountController.CreateAccount(_customerIdToTest, accountForCreation);
            var resultResult = (CreatedAtRouteResult)result.Result;
            var resultResultValue = (AccountDto)resultResult.Value;

            //Assert
            Assert.Equal(account.Balance, resultResultValue.Balance);
            Assert.Equal(account.Transactions.Count, resultResultValue.Transactions.Count);
            Assert.Equal(account.Transactions.First().Amount, resultResultValue.Transactions.First().Amount);
        }
    }
}
