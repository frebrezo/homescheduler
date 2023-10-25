CREATE LOGIN [java-app]	WITH PASSWORD = 'Passw0rd1' 
create user [java-app] for login [java-app] with default_schema=dbo

alter role db_datareader add member [java-app]
alter role db_datawriter add member [java-app]
