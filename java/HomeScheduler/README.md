# HomeScheduler (java)
## Introduction
HomeScheduler is a sample Java/Spring API. HomeScheduler is a checkin/checkout application for people in a share home, think roommates. Using HomeScheduler, users toggle their status from at home or NOT at home. This allows other users to determine who is in the shared home without wandering around the shared home to investigate or messaging others in the shared home.

## Entities
* User
  * https://github.com/frebrezo/homescheduler/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/data/entity/User.java
  * Application user/roommate.
* Availability
  * https://github.com/frebrezo/homescheduler/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/data/entity/Availability.java
  * State of the user. TRUE if the user AT HOME. FALSE if the user is NOT at home.

## API endpoints
* GET /api/user
  * https://github.com/frebrezo/homescheduler/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/controller/UserController.java
  * Returns ALL users/roommates in the shared home.
* GET /api/user/{id}
* PUT /api/{id}/availability
  * Toggles availablity for user. If availability is TRUE, returns FALSE. Otherwise returns TRUE. If available record does not exists, creates and returns availability record where availabilty is FALSE.
* POST /api/user
* PUT /api/user/{id}
* GET /api/availability
  * https://github.com/frebrezo/homescheduler/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/controller/AvailabilityController.java
  * Returns list of availabilities for users. Availability is TRUE if user is AT HOME, or FALSE if NOT at home. By default, a user's availability record does not exist. The absence of an availability record means the user is available.
* GET /api/availability/{id}
  * Returns availability by AvailabilityId.

## Configuration
* https://docs.spring.io/spring-boot/docs/current/reference/html/application-properties.html
* https://github.com/ava-innersource/PacWestSWE/blob/main/java/HomeScheduler/src/main/resources/application.properties
* spring.datasource.url
  * Database connection string.
* spring.datasource.username
  * Database user name.
  * If using SQL Server, Windows Authentication CANNOT be used to login to SQL Server
* spring.datasource.password
  * Database user password.
* spring.jpa.properties.hibernate.dialect
* spring.jpa.hibernate.ddl-auto
  * https://docs.spring.io/spring-boot/docs/1.1.0.M1/reference/html/howto-database-initialization.html
  * none - Database first
* spring.jpa.hibernate.naming.implicit-strategy
  * By default, Spring Data JPA uses "-" as a name seperator.
  * Use org.hibernate.boot.model.naming.ImplicitNamingStrategyLegacyJpaImpl to use the name specified in @Table and in @Column.
* spring.jpa.hibernate.naming.physical-strategy
  * By default, Spring Data JPA uses "-" as a name seperator.
  * Use org.hibernate.boot.model.naming.PhysicalNamingStrategyStandardImpl to use the name specified in @Table and in @Column.

## Database
* SQL Server Configuration
  * Enable TCP/IP protocol
    * https://littlekendra.com/2021/05/05/how-to-enable-tcpip-in-sql-server-even-if-configuration-manager-is-missing/
  * Java CANNOT use Integrated Windows Authentication to login into SQL Server. Create a SQL Server login to access the database.
    * https://www.guru99.com/sql-server-create-user.html
    * For simplicity, add login to sysadmin server role. DO NOT DO THIS on real project. IT IS NOT a security best practice.
* Database
  * https://github.com/frebrezo/homescheduler/tree/main/sql
  * Create database HomeScheduler in SQL Server.
  * Execute the SQL scripts in the following order
    * dbo.User.Table.sql
    * dbo.Availability.Table.sql

## References
* Spring Framework
  * Entity - https://www.baeldung.com/jpa-entities
  * JPA Repository - https://www.baeldung.com/the-persistence-layer-with-spring-data-jpa
  * Rest Controller - https://spring.io/guides/tutorials/rest/
    * Request mapping (URL) - https://www.baeldung.com/spring-requestmapping
    * URL path variable - https://www.baeldung.com/spring-pathvariable
    * URL request parameter (query string parameter) - https://www.baeldung.com/spring-requestparam-vs-pathvariable
    * Request body - https://www.baeldung.com/spring-request-response-body
* Patterns
  * Repository - https://java-design-patterns.com/patterns/repository/
  * Service layer - https://java-design-patterns.com/patterns/service-layer/
  * DTO (data transfer object) - https://java-design-patterns.com/patterns/data-transfer-object/
* Gang of Four Design Patterns
  * https://springframework.guru/gang-of-four-design-patterns/
