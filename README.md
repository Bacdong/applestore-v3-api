# Apple Store #


### Reference Documentation ###
- [C-Sharp](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
- [ASP.NET Core 5.0](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
- [PostgreSQL 12.4](https://www.postgresql.org/docs/)


### Setup Development Enviroments (Linux) ###
- [SDK Installation 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-)
- [Runtime Installation 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-)
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

### ASP.NET Core Update Latest Version ###
- [ASP.NET Core 5.0](https://docs.microsoft.com/vi-vn/dotnet/core/install/linux-alpine)
- [dotnet-install.sh](https://dot.net/v1/dotnet-install.sh.)
```
chmod +x ./dotnet-install.sh
./dotnet-install.sh -c Current
./dotnet-install.sh -c Current --runtime aspnetcore
./dotnet-install.sh -c 5.0
```


### ASP.NET Core Update Latest Version ###
- [ASP.NET Core 5.0](https://docs.microsoft.com/vi-vn/dotnet/core/install/linux-alpine)
- [dotnet-install.sh](https://dot.net/v1/dotnet-install.sh.)
```
chmod +x ./dotnet-install.sh
./dotnet-install.sh -c Current
./dotnet-install.sh -c Current --runtime aspnetcore
./dotnet-install.sh -c 5.0
```


### Package Installation ###
```
cd applestore_dotnet_core
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
dotnet add package Swashbuckle.AspNetCore
```

* EF Core Tools: `Installation`
```
dotnet tool install --global dotnet-ef
```

* EF Core Tools: `Update`
```
dotnet tool update --global dotnet-ef
```

* Troubleshoot .NET Core tool: `dotnet-ef does not exist`
```
export PATH=$HOME/.dotnet/tools:$PATH"
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


### Setup The Trust HTTPs Certificate for Linux ###
- Read more at here >
[Trust HTTPs Certificate](https://andrewlock.net/creating-and-trusting-a-self-signed-certificate-on-linux-for-use-in-kestrel-and-asp-net-core/)

- Setup Certificate on Local Machine
```
cd OpenSSL
sudo apt install libnss3-tools
pk12util -d sql:$HOME/.pki/nssdb -i localhost.pfx
certutil -d sql:$HOME/.pki/nssdb -A -t "P,," -n 'dev cert' -i localhost.crt
```

- Creating a basic certificate using OpenSSL
```
openssl req -new -x509 -newkey rsa:2048 -keyout localhost.key -out localhost.cer -days 365 -subj /CN=localhost
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.cer
openssl req -config localhost.conf -new -x509 -sha256 -newkey rsa:2048 -nodes \
    -keyout localhost.key -days 3650 -out localhost.crt
openssl pkcs12 -export -out localhost.pfx -inkey localhost.key -in localhost.crt
```


### Project Start ###
```
dotnet watch run
```


### Template ###
* [Apple Store Templete](https://github.com/BuiTrungHau1312/applestore_template)


### Participants ###
- [Duong Bac Dong](https://github.com/Bacdong)
- [Bui Trung Hau](https://github.com/BuiTrungHau1312)
- [Luu Duc Hoa](https://github.com/Luuduchoa2504)
- [Le Nguyen Anh Duc](https://github.com/anhducjav)
- [Pham Dang Hoang](https://github.com/PhamDangHoang1211)
