# c#-api-template

This repo is still a work in progress! This means that some functionalities have not been tested yet, 

#### .NET version
[![.NET](https://img.shields.io/badge/.NET%208.0-blueviolet?logo=dotnet&style=flat)](https://dotnet.microsoft.com)

#### Server and API

#### Databases and connectors
[![Postgres](https://img.shields.io/badge/Postgres-17-%23316192.svg?style=flat&logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![QDrant](https://img.shields.io/badge/Qdrant-1.12.5-red.svg?style=flat&logoColor=white)](https://www.postgresql.org/)
[![MongoDB](https://img.shields.io/badge/MongoDB-6-%234ea94b.svg?logo=mongodb&style=flat&logoColor=white)](https://www.mongodb.com)
[![Redis](https://img.shields.io/badge/Redis-6.2-DC382D?logo=Redis&logoColor=white)](https://redis.io/)
[![Entity Framework](https://img.shields.io/badge/Entity_Framework-9.0.1-000?style=for-the-badge&logo=.net&logoColor=white&color=blue&style=flat)](https://sqlmodel.tiangolo.com/)
[![Beanie](https://img.shields.io/badge/Beanie-1.27.0-red?style=flat&logoColor=white)](https://beanie-odm.dev/)


# Project description

This project is intended to be as a template for an API microservice, with connectors to multiple databases.
Users have the possibility to perform simple CRUD operations on different databases.

The code adopts and implement the following patterns or protocols:

- the code is organized following Clean Architecture principles
- the code implements and use [Result Pattern](https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern) approach
- [Json Patch](https://datatracker.ietf.org/doc/html/rfc6902) standard is adopted for managing PATCH requests
 

## Launching the application

In order to launch the entire application (server, databases), you need to install Docker.
After Docker has been installed and launched, run the following command from project root:

```shell
docker compose up
```

If you want to start the server locally, launch the following command:

```shell
dotnet run API/project.cs
```