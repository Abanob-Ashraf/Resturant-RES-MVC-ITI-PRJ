# Resturant-RES-MVC-ITI-PRJ

Resturant Reservation

## About the application

This is a simple MVC Core web app that allows users to order meals online. The user can also view all oredrs made by the clients and and modify them

## How to build and start the application

- Make sure from the configuration in appsettings file that met the application features (**Google** for External Login , **Stripe** for online payment & **Email** Configuration Service)

### Email Configuration Section

```json
EmailConfiguration": {
    "From": "",
    "SmtpServer": "",
    "Port": ,
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

- write another command to update database

```cmd
update-database
```

- Change the connection string (Sql Server, username & password )

```json
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=[Server Name];Initial Catalog=ResturantReservationProject;User ID=[Sql server Username]];Password=[Sql server Password];Connect Timeout=30 Encrypt=False;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
  }
```

- database with name **ResturantReservationProject** should be created in your SqlServer
- run the application through Visual Studio

the application will run on route 'https://localhost:7014'

#### Applictation Featues

- 2 UIs Created one for Client and Admin panal
- Applied Design patterns (Dependecy Injection, Repository)
- Applied All DataAnnotations (Custom DataAnnotations)
- Enabled Validation (Both: Client-Side & Server-Side)
- Identity has been implemented in ASP.Net Core (Users, Roles, Confirm Email, ForgetPassword)
- Use External-Logins in your project
- online payment using "Stripe
- Email Service Configured to send an email on registration
- you can pay in 2 ways in cash or online
- regeistered client can Submit his own feedback
- Cart view to checkout the order

#### Refrences

- [ASP .NET CORE MVC](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0).
- 


