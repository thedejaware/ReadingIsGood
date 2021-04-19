# ReadingIsGood
ReadingIsGood - Online Books Retail

This is an ASP.NET Core Web API Project including principles of Clean Architecture and Domain Driven Design concepts

#### Technologies 
- ASP.NET Core 5
- Entity Framework Core 5
- CQRS Pattern with MediatR
- AutoMapper
- FluentValidation
- Docker

To run the project, you will need the following tools;
- Visual Studio 2019
- .Net 5.0 or later
- Docker Desktop

To Install the project;
- Clone the repository
- Open Docker for Windows. Go to the Settings > Advanced option, from the Docker icon in the system tray, to configure the minimum amount of memory and CPU like so:
Memory: 4 GB
CPU: 2
- At the root directory of the project which include docker-compose.yml files, run below command:

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

After the microservice, database and portainer are composed you can launch the following services;

- RIG.API = http://localhost:7001/swagger/index.html
- Portainer (Container Management) = http://localhost:9000/
	- Username= admin
	- Password = admin1234
- MSSQL Database
	- Username = sa
	- Password = RiGw12345678

- When the applications starts up, EF Migrations are automatically applied to SQL Server
- In order to use endpoints, first you have to call Authentication endpoint to get JWT token. For this, You can use the following username and password

		 username = "mma"
		 password = "123"
or

you can add a Customer with new username and password. All the endpoints except "Adding Customer Endpoint" have been secured using JWT.


Project consists of Core and Periphery Layers. 
- Core Layers: RIG.Application & RIG.Domain
- Periphery Layers: RIG.API & RIG.Infrastructure

#### RIG.Application Layer
- This layer is about business use case. CQRS Pattern with MediatR has been implemented in this Layer.
- Layer Structure;
	- Behaviours: This folder is used for Validations, Logging and other Cross-Cutting Concerns.
	- Contracts: This folder stores all interfaces for abstracting use case implementations
	- Features: This folder applies  CQRS Design Pattern for handling business use cases


#### RIG.Domain Layer
- This layer includes Customer, Order and OrderDetail Entities

#### RIG.Infrastructure Layer
- This layer includes implementation of abstraction inside the Application Layer. Database operations are being performed in this layer.




