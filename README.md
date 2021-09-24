# banking.operation-client-api

Banking Operation Solution - Client Api

[![.NET](https://github.com/EdsonCaliman/banking.operation-client-api/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/EdsonCaliman/banking.operation-client-api/actions/workflows/dotnet.yml)
[![Coverage Status](https://coveralls.io/repos/github/EdsonCaliman/banking.operation-client-api/badge.svg?branch=main)](https://coveralls.io/github/EdsonCaliman/banking.operation-client-api?branch=main)

This project is a part of a Banking Operation solution, with DDD and microservices architecture, using .Net Core.

![BankingOperations (1)](https://user-images.githubusercontent.com/19686147/133843637-85277ee1-9748-4456-befa-4b2265e3ebec.jpg)

Using a docker-compose configuration the components will be connected so that together they work as a solution.

This component will be responsible for register the clients, attending the crud operations. It uses a mysql database to register the data.

![image](https://user-images.githubusercontent.com/19686147/133844360-8e1a84c3-d07d-41df-8863-18d0fe2ad144.png)

# Bussiness Rules

 - A client needs to have a name and email.
 - The name must have a maximum of 150 characters and is mandatory.
 - The email should be valid and is mandatory.
 - The same email is not allowed for different customers.
 - The client needs to have an Id for identification, which should be generated automatically.
 - The client needs to have an account number, which should be generated automatically and cannot repeat.


# How to run

With a docker already installed run:

docker-compose up -d

For swagger open the URL: http://localhost:8000/swagger

![image](https://user-images.githubusercontent.com/19686147/133844735-b71e05ac-d65a-4199-b35b-edcb4f97ed70.png)
