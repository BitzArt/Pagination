# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

# Overview

This Pagination NuGet package provides efficient pagination capabilities for your C# projects, enabling you to display large data sets conveniently.

# Installation

## Use with IEnumerable

To use this package with **IEnumerable** collections, follow these steps:

<ol>
<li>
Install the package using the .NET CLI:

```
dotnet add package BitzArt.Pagination
```
</li>
<li>
Use it by calling the ToPage method on your collections:

```csharp
var page = yourEnumerable.ToPage(offset, limit);
```
</li>
</ol>

## Use with Entity Framework Core

For Entity Framework Core projects, you can easily integrate the Pagination package:
<ol>
<li>
Install the package:

```
dotnet add package BitzArt.Pagination.EntityFrameworkCore
```
</li>
<li>
Assuming you have a DbContext with a DbSet of your entity type:

```csharp
public class YourDbContext : DbContext
{
    public DbSet<SomeEntity> Items { get; set; }
    // ...
}

```
</li>
<li>
Utilize the ToPageAsync method provided by the package to create paged results:

```csharp
var dbContext = new YourDbContext();
var paginatedResult = await dbContext.Items.ToPageAsync(offset, limit);
```
</li>
</ol>

# Benefits

- Simplifies the process of paginating data in your application.
- Optimized for performance and memory efficiency.
- Compatible with various data sources.
- Ideal for scenarios where you need to display a portion of a large dataset at a time.
