# Gateways Manager

CRUD API for managing gateways - master devices that control multiple peripheral devices. It is storing information about these gateways and their associated devices. This information is stored in the database. 

## Functional Specifications

Input fields are validated. Also, no more that 10 peripheral devices are allowed for a gateway.
The service also offer an operation for displaying information about all stored gateways (and their devices) and an operation for displaying details for a single gateway. It is possible to add and remove a device from a gateway.

Each gateway has:
*	a unique serial number (string) 
*	human-readable name (string)
*	IPv4 address (to be validated)
*	multiple associated peripheral devices 

Each peripheral device has:
*	a UID (number)
*	vendor (string)
*	date created
*	status - online/offline


### Prerequisites
* [Visual Studio](https://visualstudio.microsoft.com/vs/) 2017 or later.
* [Sql Server Express](https://www.microsoft.com/en-us/download/details.aspx?id=55994)

### Setup
- items in the prerequsites section should be installed
- project should be downloaded into your local machine
- to communicate with the database, the connection string should be set in appsettings.json
  - `"ConnectionStrings": {
    "DefaultConnection": "data source=ExampleServerName; initial catalog=GatewaysManager; integrated security=SSPI"
  },` where ExampleServerName is the name of your sql server name
  - to retrieve your sql server name you can write in the command prompt: SQLCMD -L (this can take some time)
 - open Visual Studio and type the following commands into the Package Manager Console:
   - add-migration init
   - update-database
   
 ## Docker automated build
 The docker compose file is located in GatewaysManagerApi folder. <br>
 SQL settings details are located in the Startup.cs file located in the GatewaysManagerApi folder.
   
 ## Project Description
 
 ### Technologies Used
 - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
 - [Auto Mapper](https://automapper.org/)
 - [Fluent Validation](https://fluentvalidation.net/)
 - [Swashbuckle (Swagger)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
 
### Design Patterns Applied
* **Services** - for separation of business logic
* **Repository** - for data-access logic
* **Factory** - for enhancing input data and save it to the database
* **Data mapping** - for populating output data from the database

### Disclaimer
Unit tests are not covering 100% of the code, they are for showcase on the key areas that need to be covered.

