# EntityFrameworkWebAPTemplate
EntityFramework Core example for ASP.NET Core

## 範例講解

本範例會簡單示範 EntityFramework 的寫法。

<a href="https://github.com/sholfen/EntityFrameworkWebAPTemplate" target="_blank">範例下載</a>

從資料庫建 DB Model 的指令(以北風資料庫為範例)：
`dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models/DBModels`

SQLite 指令：
`dotnet ef dbcontext scaffold "Data Source=.\DataFile\sample.sqlite;Cache=Shared" Microsoft.EntityFrameworkCore.Sqlite --output-dir Models/DBModels/SQLiteModels`

一開始先在 Startup.cs 設定 DbContext：
~~~csharp
public void ConfigureServices(IServiceCollection services)
{
    //DB setup
    services.AddEntityFrameworkSqlServer();
    services.AddDbContext<NorthwindContext>(options =>
    {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    });
    _ = services.AddScoped<DbContext, NorthwindContext>();
    services.AddScoped<IEmployeesRepository, EmployeesRepository>();
    services.AddScoped<ICustomersRepository, CustomersRepository>();

    //services setup
    services.AddScoped<IEmployeesService, EmployeesService>();
    services.AddScoped<ICustomersService, CustomersService>();

    services.AddControllersWithViews();
}
~~~

在 Controller 上的使用：

~~~csharp
[HttpGet]
public IActionResult TestCustomers()
{
    var result = _customersService.GetAll();
    return new JsonResult(result);
}

[HttpGet]
public IActionResult TestCustomer()
{
    Customers customer = _customersService.GetCustomerByID("ANATR");
    return new JsonResult(customer);
}
~~~

**參考資料**

- <a href="https://docs.microsoft.com/zh-tw/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli" target="_blank">反向工程-EF Core</a>
- <a href="https://dotblogs.com.tw/yc421206/2015/05/03/151200" target="_blank">[C#.NET][Entity Framework] 幾個提升 EF 效能的方法</a>
- <a href="https://stackoverflow.com/questions/31505384/asp-net-entityframework-get-database-name" target="_blank">ASP.NET EntityFramework get database name
</a>