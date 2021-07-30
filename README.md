# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

BitzArt.Pagination nuget package

https://www.nuget.org/packages/BitzArt.Pagination/

Example of creating paged result:

    var result = await dbContext.Set<SomeEntity>().ToPageAsync(0, 10);
    
Result will be the same as:

    var data = await dbContext.Set<SomeEntity>().Skip(0).Take(10).ToListAsync();
    var total = dbContext.Set<SomeEntity>().Count();
    var result = new PageResult(data, request, total);
    
