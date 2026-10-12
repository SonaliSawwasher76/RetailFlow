# RetailFlow — Inventory Management (In Progress)

RetailFlow is a portfolio project built with **C#, ASP.NET Core MVC, Entity Framework Core, and SQL Server**. This starter implements a product inventory workflow.

> **Status:** In progress. The current scope is product inventory CRUD and summary calculations; it is not a production-ready retail or ERP system.

## Features
- Create, view, edit and delete products
- Search by product name/category and filter by category
- Product count, total quantity and calculated stock value
- Server-side validation with Data Annotations
- SQL Server persistence through Entity Framework Core
- Responsive monochrome interface

## Stack
C# · .NET 8 · ASP.NET Core MVC · Entity Framework Core 8 · SQL Server · Razor · HTML/CSS

## Requirements
- .NET 8 SDK
- SQL Server LocalDB or another SQL Server instance
- EF Core CLI (`dotnet tool install --global dotnet-ef`)

## Run locally
Run these commands from the folder containing `RetailFlow.csproj`:

```bash
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

Open the local URL printed by the terminal. The default connection string uses LocalDB. Change `ConnectionStrings:RetailFlowConnection` in `appsettings.json` if needed. Never commit production passwords or secrets.

## Future improvements
Sales and purchase records, suppliers/customers, stock movement history, low-stock alerts, authentication/authorization, tests, paging and audit logging.

## Portfolio note
Run and test the project locally before presenting it as a working application. Keep the repository marked **in progress** until you have verified the CRUD workflows and can explain the code in an interview.
