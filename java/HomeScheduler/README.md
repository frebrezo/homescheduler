# HomeScheduler (java)
## Introduction
HomeScheduler is a sample Java/Spring API. HomeScheduler is a checkin/checkout application for people in a share home, think roommates. Using HomeScheduler, users toggle their status from at home or NOT at home. This allows other users to determine who is in the shared home without wandering around the shared home to investigate or messaging others in the shared home.

## Entities
* User
  * https://github.com/ava-innersource/PacWestSWE/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/data/entity/User.java
  * Application user/roommate.
* Availability
  * https://github.com/ava-innersource/PacWestSWE/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/data/entity/Availability.java
  * State of the user. TRUE if the user AT HOME. FALSE if the user is NOT at home.

## API endpoints
* /api/user
  * https://github.com/ava-innersource/PacWestSWE/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/controller/UserController.java
  * Returns ALL users/roommates in the shared home.
* /api/user/{id}
* /api/availability
  * https://github.com/ava-innersource/PacWestSWE/blob/main/java/HomeScheduler/src/main/java/org/wonkim/homescheduler/controller/AvailabilityController.java
  * Returns list of availabilities for users. Availability is TRUE if user is AT HOME, or FALSE if NOT at home. By default, a user's availability record does not exist. The absence of an availability record means the user is available.
* /api/availability/{id}
  * Returns availability by AvailabilityId.

## Configuration
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
* spring.jpa.hibernate.naming.physical-strategy

## Database
