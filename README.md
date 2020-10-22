# Apple Store #


### Reference Documentation ###
- [C-Sharp](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [PostgreSQL 12.4](https://www.postgresql.org/docs/)


### Setup Development Enviroments (Linux) ###
- [SDK Installation](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-)
- [Runtime Installation](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-)
- Support Enviroments:

```
sudo apt install nodejs
sudo apt install npm
```

- PostgreSQL Installation:
```
sudo sh -c 'echo "deb http://apt.postgresql.org/pub/repos/apt $(lsb_release -cs)-pgdg main" > /etc/apt/sources.list.d/pgdg.list'
wget --quiet -O - https://www.postgresql.org/media/keys/ACCC4CF8.asc | sudo apt-key add -
sudo apt-get update
sudo apt-get -y install postgresql
```

- DBeaver - Database Management Tools Installation:
```
wget -O - https://dbeaver.io/debs/dbeaver.gpg.key | sudo apt-key add -
echo "deb https://dbeaver.io/debs/dbeaver-ce /" | sudo tee /etc/apt/sources.list.d/dbeaver.list
sudo apt-get update && sudo apt-get install dbeaver-ce
```


### Package Installation ###
```
cd applestore_dotnet_core/WebApp
```

* Entity Framework:
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.Extensions.Configuration.FileExtensions
dotnet add package Microsoft.Extensions.Configuration.Json
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
dotnet add package Microsoft.AspNetCore.Hosting
dotnet add package Microsoft.AspNetCore.Http
```

* EF Core Tools: `Installation`
```
dotnet tool install --global dotnet-ef
```

* EF Core Tools: `Update`
```
dotnet tool update --global dotnet-ef
```


### Migrations Database ###
- Adding a migration:
```
dotnet ef migrations add <migration_name> -o "Data/Migrations"
```

- Update database:
```
dotnet ef database update
```

- Remove migration:
```
dotnet ef migrations remove
```


### Push a commit code to source code management ###
```
git add .
git commit -m "<commit_message>"
git push -u origin master (push to Github)
git push -u Main master (push to Gitlab)
```

### Project Start ###
```
dotnet watch run
```


### Participants ###
- [Duong Bac Dong](https://github.com/Bacdong)
- [Bui Trung Hau](https://github.com/BuiTrungHau1312)
- [Luu Duc Hoa](https://github.com/Luuduchoa2504)
- [Le Nguyen Anh Duc](https://github.com/)
- [Pham Dang Hoang](https://github.com/PhamDangHoang1211)
