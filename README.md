# Introduction 

Knowzy is a webapp that shows how to work using [ASP.NET Core](https://github.com/aspnet/Home). It provides simple CRUD operations, navigation and a responsive way to show the data.

This application is built using:
- ASP.NET MVC Core
- Plain CSS
- Jquery
- Entity Framework Core

## Requirements

[Get Started with .NET Core](https://www.microsoft.com/net/core#windowscmd)

## Build and Deployment

### Using Windows and Visual Studio 2017
- Open the solution file within Visual Studio 2017 (Microsoft.Knowzy.sln)
- Once opened, In the Build menu select Rebuild Solution. All dependences and NuGet packages will be downloaded.

### Configuration
#### Mock data object:

- Included in the source code there is a .json (data.json) file which cotains mock data for the application. This file is located in the folder: "/src/1. WebApp/Microsoft.Knowzy.WebApp/wwwroot/Data". The .json data structure should be as follows:
- Of course, it is possible to change the location where the app looks for the file. To do so, there are two configuration files located in the folder: "/src/1. WebApp/Microsoft.Knowzy.WebApp/" named appsettings.json and appsettings.Development.json where various configuration params can be set. The first one is used to set general configuration and the second is for development configuration only. The order precedure is if the same property is stablished in the development file and the app is running in development mode it will get the property set in the development configuration file. 
In this case, the configuration property is located in the appsettings.json as follows:
```js
  "AppSettings": {
    "JsonPath": "\\Data\\order.json"
  }
```
Updating the JsonPath property, the location where the app looks for the json data will be updated.

#### Database configuration

- For development the functionality is out of the box. The application uses an InMemoryDB that will be initialized automatically when the app starts.
- For production, it is mandatory to set the connection string to an existing DB. To do so, in the appsettings.json it is necessary to set the value for KnowzyContext:

```js
"ConnectionStrings": {
    "KnowzyContext": "Server=.\\SQLEXPRESS;Database=Knowzy;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
```

#### Change data provider from database to REST API  Service (or whatever you want)

- In order to override the existing implementation using a Database (In Memory or SQL Server), users must implement the IOrderQueries and IOrderRepository interfaces whith a custom implementation. Also, CommandsHandlers have to be modified removing the information about Entity Framework context.
- Also you have to change the service configuration in the Startup.cs class adding the new implementation files:

 ```c#
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IOrderQueries, OrderQueriesDatabase>();
```