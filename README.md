# API for opening account of already existing customer
ASP.NET Core 8 Web API to create account for existing customers. 
This project is developed using Visual Studio 2022 and requires the installation of C# 10 and .NET 8.

## Customer.API
Has endpoints to get information about Custommer and creat Account.  
* GET /api/customers - returns information about customers (customer information, account information and transactions).
* GET /api/customers/{id} - returns information about customer with given id.
* GET /api/customers/{customerId}/account - returns information about customer accounts and transactions
* POST /api/customers/{customerId}/account - creates an account for the customer. The initial credit should be sent as a parameter (Balance) in JSON format. If the balance is greater than 0, a transaction is created automatically.

## Customer.FE
Frontend project: To create an account for a customer, select 'Customers' from the menu and then click on 'Add Account'.

## Account.Test
Test project to test Account and Customers controllers

# Documentation
Swagger documentation is available at https://localhost:{port}/swagger
