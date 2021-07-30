# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

https://www.nuget.org/packages/BitzArt.Pagination/

Supports EF and EF Core. To use with your version of EF, add appropriate nuget package to your project.

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
