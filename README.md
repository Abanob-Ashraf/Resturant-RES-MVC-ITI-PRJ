# Resturant-RES-MVC-ITI-PRJ

Restaurant Reservation

## About the application

This simple MVC Core web app allows users to order meals online. The user can also view all orders made by the clients and modify them

Admin User Name = zmanrest@gmail.com
Admin Password = Admin$123

## How to build and start the application

- Make sure from the configuration in the **AppSettings.json** file that meets the application features (**Google** for External Login, **Stripe** for online payment & **Email** Configuration Service)

### Email Configuration Section

```json
"EmailConfiguration": {
    "From": "",
    "SmtpServer": "",
    "Port": "",
    "Username": "",
    "Password": ""
  }
```

### Google Configuration Section

```json
"Authentication": {
    "Google": {
      "ClientId": "",
      "ClientSecret": ""
    }
  }
```

### Stripe Configuration Section

```json
 "Stripe": {
    "PublicKey": "",
    "SecretKey": ""
  }
```

- in **Package Manager Console** make Db migration using command

```cmd
add-migration init
```

- Write another command to update the database

```cmd
update-database
```

- Change the connection string (SQL Server, username & password )

```json
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=[Server Name];Initial Catalog=ResturantReservationProject;User ID=[Sql server Username]];Password=[Sql server Password];Connect Timeout=30 Encrypt=False;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
```

- database with name **ResturantReservationProject** should be created in your SqlServer
- Run the application through Visual Studio

the application will run on route 'https://localhost:7014'

#### Application Features

- 2 UIs Created one for the Client and Admin panel
- Applied Design patterns (Dependency Injection, Repository)
- Applied All DataAnnotations (Custom DataAnnotations)
- Enabled Validation (Both: Client-Side & Server-Side)
- Identity has been implemented in ASP.Net Core (Users, Roles, Confirm Email, forgot password)
- Use External-Logins in your project
- online payment using "Stripe
- Email Service Configured to send an email on registration
- You can pay in 2 ways in cash or online
- Registered clients can Submit their own feedback
- Cart view to checkout the order

#### Refrences

- [ASP .NET CORE MVC](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0).
  


