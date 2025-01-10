# HomeScheduler (python)
## Introduction
HomeScheduler is a sample Python/Django API. HomeScheduler is a checkin/checkout application for people in a share home, think roommates. Using HomeScheduler, users toggle their status from at home or NOT at home. This allows other users to determine who is in the shared home without wandering around the shared home to investigate or messaging others in the shared home.

## Notes
* Django is an MVC framework.
* Django DOES NOT support REST out of the box and requires the djangorestframework library to enable REST APIs.
* views.py is NOT used. Use viewsets.py instead.
* `routers` are NOT used. Map your HTTP methods to viewset methods instead.
* serializers.py is NOT used. Serializers are designed to work with the Django entities.
* To use the DTO pattern, you have to convert objects to dictionaries and use JsonResponse.
* Django by default wants to be code first. Use `manage.py inspectdb` to generate entities for database first.
* Django by default wants to expose the database model as the API contracts.
* `request.data` is a dictionary and must be manually converted to an object.
* Generics in Python are WEIRD and it's easy to get lost in the DTO object structure.

## Entities
* User
  * https://github.com/ava-innersource/PacWestSWE/blob/main/pythondjango/HomeScheduler/api/models.py
  * Application user/roommate.
* Availability
  * https://github.com/ava-innersource/PacWestSWE/blob/main/pythondjango/HomeScheduler/api/models.py
  * State of the user. TRUE if the user AT HOME. FALSE if the user is NOT at home.

## API endpoints
* GET /api/user
  * https://github.com/ava-innersource/PacWestSWE/blob/main/pythondjango/HomeScheduler/api/viewsets.py
  * Returns ALL users/roommates in the shared home.
* GET /api/user/{id}
* PUT /api/{id}/availability
  * TBD
  * Toggles availablity for user. If availability is TRUE, returns FALSE. Otherwise returns TRUE. If available record does not exists, creates and returns availability record where availabilty is FALSE.
* POST /api/user
* PUT /api/user/{id}
* GET /api/availability
  * TBD
  * Returns list of availabilities for users. Availability is TRUE if user is AT HOME, or FALSE if NOT at home. By default, a user's availability record does not exist. The absence of an availability record means the user is available.
* GET /api/availability/{id}
  * TBD
  * Returns availability by AvailabilityId.

## Database
* SQL Server Configuration
  * Enable TCP/IP protocol
    * https://littlekendra.com/2021/05/05/how-to-enable-tcpip-in-sql-server-even-if-configuration-manager-is-missing/
  * Python CANNOT use Integrated Windows Authentication to login into SQL Server. Create a SQL Server login to access the database.
    * https://www.guru99.com/sql-server-create-user.html
    * For simplicity, add login to sysadmin server role. DO NOT DO THIS on real project. IT IS NOT a security best practice.
* Database
  * https://github.com/ava-innersource/PacWestSWE/tree/main/pythondjango/HomeScheduler/sql
  * Create database HomeScheduler in SQL Server.
  * Execute the SQL scripts in the following order
    * dbo.User.Table.sql
    * dbo.Availability.Table.sql
* Driver
  * Install SQL Server ODBC Driver
    * https://learn.microsoft.com/en-us/sql/connect/odbc/download-odbc-driver-for-sql-server

## Configuration
* https://docs.djangoproject.com/en/4.2/topics/settings/
* https://github.com/ava-innersource/PacWestSWE/blob/main/pythondjango/HomeScheduler/HomeScheduler/settings.py
* DATABASES
  * https://learn.microsoft.com/en-us/samples/azure-samples/mssql-django-samples/mssql-django-samples/

## References
* Django
  * https://docs.djangoproject.com/en/4.2/intro/tutorial01/
  * Generate model
    * https://stackoverflow.com/questions/1545714/reverse-engineer-mysql-database-to-create-django-app
  * Django REST framework
    * https://www.django-rest-framework.org/tutorial/quickstart/
    * https://www.django-rest-framework.org/api-guide/viewsets/
    * https://www.django-rest-framework.org/tutorial/6-viewsets-and-routers/
  * SQL Server integration
    * https://learn.microsoft.com/en-us/samples/azure-samples/mssql-django-samples/mssql-django-samples/
    * Django only supports ODBC connectivity to SQL Server
* Patterns
  * Repository - https://java-design-patterns.com/patterns/repository/
  * Service layer - https://java-design-patterns.com/patterns/service-layer/
  * DTO (data transfer object) - https://java-design-patterns.com/patterns/data-transfer-object/
* Gang of Four Design Patterns
  * https://springframework.guru/gang-of-four-design-patterns/
