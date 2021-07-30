# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

BitzArt.Pagination nuget package

https://www.nuget.org/packages/BitzArt.Pagination/

Assuming that we have a DbContext with some entity like

    DbSet<SomeEntity> Items { get; set; }

Example of creating paged result:

    var result = await dbContext.Items.ToPageAsync(0, 10);
    
Or:

    var result = await dbContext.Set<SomeEntity>().ToPageAsync(0, 10);
    
Result will be the same as:

    var data = await dbContext.Items.Skip(0).Take(10).ToListAsync();
    var total = dbContext.Items.Count();
    var result = new PageResult(data, request, total);
    
