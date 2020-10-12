## Apple Store ##

### Reference Documentation ###
- [C-Sharp](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [PostgreSQL 12.4](https://www.postgresql.org/docs/)

### Package Installation ###

` 
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
`

`
dotnet add package Microsoft.EntityFrameworkCore.Design
`

`
dotnet add package Microsoft.EntityFrameworkCore.Tools
`

`
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
`

`
dotnet add package Microsoft.Extensions.Configuration.Json
`

`
dotnet tool install --global dotnet-ef
`

### Migrations Database ###

- Adding a migration:

`
dotnet ef migrations add <migration_name> -o "Data/Migrations"
`

- Migrations all:

`
dotnet ef migrations add . -o "Data/Migrations"
`

### Update Database ###

`
dotnet ef database update
`
