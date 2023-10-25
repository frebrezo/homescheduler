FROM eclipse-temurin:17-jdk-alpine as base
WORKDIR /app
EXPOSE 8080

FROM base as final
WORKDIR /app
COPY target/*.jar /app/publish/
#RUN ls -la /app/publish/
ENTRYPOINT ["java","-jar","/app/publish/HomeScheduler-0.0.1-SNAPSHOT.jar"]
