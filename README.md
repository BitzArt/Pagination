# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

# Use with IEnumerable

You can use this library on IEnumerable interface. Just add this nuget package

https://www.nuget.org/packages/BitzArt.Pagination

Call .ToPage() method on an enumerable to get a PageResult.

# Use with Entity Framework

Supports EF and EF Core. To use with your version of EF, add appropriate nuget package to your project.

https://www.nuget.org/packages/BitzArt.Pagination.EntityFrameworkCore/
https://www.nuget.org/packages/BitzArt.Pagination.EntityFramework/

Assuming that you have a DbContext with some entity like

    DbSet<SomeEntity> Items { get; set; }

Example of creating paged result:

    var result = await dbContext.Items.ToPageAsync(0, 10);
    
Or (obviously):

    var result = await dbContext.Set<SomeEntity>().ToPageAsync(0, 10);
    
Result will be the same as:

    var data = await dbContext.Items.Skip(0).Take(10).ToListAsync();
    var total = dbContext.Items.Count();
    var result = new PageResult(data, request, total);
