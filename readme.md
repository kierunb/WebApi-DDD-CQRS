# Project notes

#### Installed libraries

- ASP.NET Core (for Web Api)
- Entity Framework Core (Sql Server)
- Automapper
- MediatR
- Fluent Validation
- For Unit/Integration testing
  - Moq
  - Fluent Assertions


#### Data Model

- **Book** (Aggregate Root)
  - **Author** (Entity 1..n)
  - **BookShippingDetail** (Entity 1..1)
  - **Price** (Value object)

#### EF Core data conventions used in project

- [Keys](https://docs.microsoft.com/en-us/ef/core/modeling/keys)
- [Ralationships](https://docs.microsoft.com/en-us/ef/core/modeling/relationships)
- [Shadow Properties](https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties)


#### Useful CLI commands

Database must be created manually using CLI commands

```bash
#install dotnet ef global tool (if required)
dotnet tool install --global dotnet-ef

# add migration
dotnet ef migrations add <name>

# update database
dotnet ef database update
```