# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

# Use with IEnumerable

You can use this library on IEnumerable interface. Just add this nuget package

```
dotnet add package BitzArt.Pagination
```

Getting a page of items:
```csharp
list.ToPage(offset, limit)
```

# Use with EF Core

Add a nuget package to your project:
```
dotnet add package BitzArt.Pagination.EntityFrameworkCore
```

Assuming that you have a DbContext with some entity like

```csharp
DbSet<SomeEntity> Items { get; set; }
```

Example of creating paged result:

```csharp
var result = await dbContext.Items.ToPageAsync(0, 10);
```
