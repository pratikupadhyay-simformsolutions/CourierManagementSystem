# .NET Core - Courier Management
- In the courier management, user can manage the courier, user, track, payment.

**Prerequisite**
- Visual Studio 2022
- .Net 5

## Dependencies

**Nuget Packages**
- Microsoft.AspNetCore.Identity(2.2.0)
- Microsoft.AspNetCore.Identity.EntityFramworkCore(5.0.16)
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation(5.0.16)
- Microsoft.EntityFramworkCore(5.0.16)
- Microsoft.EntityFramworkCore.Sqlite(5.0.16)
- Microsoft.EntityFramworkCore.SqlServer(5.0.16)
- Microsoft.EntityFramworkCore.Tools(5.0.16)
- Microsoft.VisualStudio.Web.CodeGeneration.Design(5.0.16)
- System.Configuration.ConfigurationManager(5.0.0)
- xunit(2.4.1)

**Database**
- Database Server: SQL Server 2018
- Dtabase Name: CourierManagement

## Project Architecture
- CourierManagement.Database(Conatins database model)
- CourierManagement.Entities(Contains view model of request and response)
- CourierManagement.Repository(Contains repositories of all the entities)
- CourierManagement.Services(Contains business logic)
- CourierManagement.Web (Contains UserInterface)
- CourierManagement.Test(Contains all the test methods)

## Running the tests
- In this project used XUnit, You can run all the tests from the Test Explorer. If Test Explorer is not visible, choose Test on the Visual Studio menu -> choose Windows -> Test Explorer. All the unit tests will be listed so choose the test you want to run. You can also run alto tests by selecteing "Run All" option.
