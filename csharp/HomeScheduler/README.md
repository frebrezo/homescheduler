# HomeScheduler (c#)
## Introduction
HomeScheduler is a sample Java/Spring API. HomeScheduler is a checkin/checkout application for people in a share home, think roommates. Using HomeScheduler, users toggle their status from at home or NOT at home. This allows other users to determine who is in the shared home without wandering around the shared home to investigate or messaging others in the shared home.

## Entities
* User
  * https://github.com/ava-innersource/PacWestSWE/blob/main/csharp/HomeScheduler/HomeScheduler.Data/Entity/User.cs
  * Application user/roommate.
* Availability
  * https://github.com/ava-innersource/PacWestSWE/blob/main/csharp/HomeScheduler/HomeScheduler.Data/Entity/Availability.cs
  * State of the user. TRUE if the user AT HOME. FALSE if the user is NOT at home.

## API endpoints
* GET /api/user
  * https://github.com/ava-innersource/PacWestSWE/blob/main/csharp/HomeScheduler/HomeScheduler.Service/Controller/UserController.cs
  * Returns ALL users/roommates in the shared home.
* GET /api/user/{id}
* PUT /api/{id}/availability
  * Toggles availablity for user. If availability is TRUE, returns FALSE. Otherwise returns TRUE. If available record does not exists, creates and returns availability record where availabilty is FALSE.
* POST /api/user
* PUT /api/user/{id}
* GET /api/availability
  * https://github.com/ava-innersource/PacWestSWE/blob/main/csharp/HomeScheduler/HomeScheduler.Service/Controller/AvailabilityController.cs
  * Returns list of availabilities for users. Availability is TRUE if user is AT HOME, or FALSE if NOT at home. By default, a user's availability record does not exist. The absence of an availability record means the user is available.
* GET /api/availability/{id}
  * Returns availability by AvailabilityId.

## Configuration
* https://entityframeworkcore.com/approach-database-first
* Package Manager Console
  * Set Default Project to the project where you want the Entity Framework to add auto-generated files.
  * Run command `Scaffold-DbContext -Provider Microsoft.EntityFrameworkCore.SqlServer -Connection "Server=.;Database=HomeScheduler;User Id=dotnet-app;Password=*****;Encrypt=False;TrustServerCertificate=True;" -OutputDir Entity -Force`
    * If using Windows Authentication, replace `User Id=dotnet-app;Password=*****` with `Integrated Security=True`.

## Database
* https://github.com/ava-innersource/PacWestSWE/tree/main/csharp/HomeScheduler/sql
* Create database HomeScheduler in SQL Server.
* Execute the SQL scripts in the following order
  * dbo.User.Table.sql
  * dbo.Availability.Table.sql

## References
* ASP.NET core Web API
  * ASP.NET core Web API Tutorial - https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio
  * Web API Controller - https://dotnettutorials.net/lesson/adding-controller-in-asp-net-core/
* Patterns
  * Respository (data access layer) - https://dotnettutorials.net/lesson/repository-design-pattern-csharp/
  * Service layer (business logic layer/application layer) - https://learn.microsoft.com/en-us/aspnet/web-forms/overview/data-access/introduction/creating-a-business-logic-layer-cs
  * DTO (data transfer object) - https://www.codeproject.com/articles/1050468/data-transfer-object-design-pattern-in-csharp
* Gang of Four Design Patterns
  * https://dofactory.com/net/design-patterns
