# Pagination

![Tests](https://github.com/BitzArt/Pagination/actions/workflows/Tests.yml/badge.svg)

BitzArt.Pagination nuget package

https://www.nuget.org/packages/BitzArt.Pagination/

Example of creating paged result:

    var result = await dbContext.Users.ToPageAsync(request);
    
Result will be the same as:

    var data = await dbContext.Users.Skip(skip).Take(take).ToListAsync();
    var total = dbContext.Users.Count();
    var result = new PageResult<User>(data, request, total);
    
