# ProductsWebApi

Simple Web Api providing all available products and enabling the partial update of one product.

## Prerequisites

Recommended:

* Visual Studio 2019 or Visual Studio Code
* MSSQL when using SQL provider

## Quick start

### Download project

`git clone https://github.com/vojtechrojicek/ProductsWebApi.git`

### Set up your database (optional)

Project use InMemoryProvider as default. That's why quick start does not need database set up.

#### Use SQL provider

* Set `"UseSqlProvider": true` in used `appsettings.*.json`.
* Set correct connection string to `ProductsConnection`.
* Project creates and automigrates your database after start (`context.Database.Migrate();`).
* (If migrations failed, check your connection string and try to create Database by your self. Let EF to create Tables automatically.)

### Build and run project

* Use command `dotnet run` or use your IDE to run `ProductsWebApi.Web` project.
* Swagger documentation is available at `/swagger`
* Endpoins are listening at `/api/v1/products`. (Only v1 is available.)
* Database is automatically seeded with 5 products:

``` C#
new Product
{
    Id = new Guid("d739776c-532f-47b5-a218-ed3b8acad5de"),
    Name = "Acer Aspire 5 Obsidian Black kovový",
    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=NC028h0l6",
    Price = 14990,
    Description = "Notebook - Intel Core i5 8265U Whiskey Lake."
},
new Product
{
    Id = new Guid("462bc310-365e-4793-a9b6-ff0a5af85a48"),
    Name = "HP Pavilion x360 15-dq0002nc Natural Silver Touch",
    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=HPCN1011w5w9",
    Price = 18490,
    Description = "Tablet PC - Intel Core i3+ 8145U Whiskey Lake."
},
new Product
{
    Id = new Guid("9f5d9025-ed47-49ca-9fb2-3b71d897eb6a"),
    Name = "Eternico Essential Wired Keyboard KD100CS",
    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=AET0099b",
    Price = 299,
    Description = "Klávesnice kancelářská, drátová, chiclet klávesy."
},
new Product
{
    Id = new Guid("7b417428-cd89-4ff1-9248-6c2a89e1a3c6"),
    Name = "PlayStation 4 Slim 500 GB",
    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=MSX001sl",
    Price = 7790,
    Description = "Herní konzole - domácí, HDD 500 GB, Blu-ray, 1× herní ovladač, barva černá."
},
new Product
{
    Id = new Guid("8dbc0b73-69b9-480c-98f0-c09bd9db613a"),
    Name = "24' Philips 243V7QJABF",
    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f3&cd=WC118b20c",
    Price = 2390,
    Description = "LCD monitor Full HD 1920×1080, IPS, LED."
}
```

## Unit tests

Solution contain ProductsWebApi.Test project using xUtit as testing tool.  
Unit test coverage:

* `ProductsController` endpoints.
* Data seeding.
* Custom error handling.

You can run tests for example in Visual Studio with [TestExplorer](https://docs.microsoft.com/en-us/visualstudio/test/run-unit-tests-with-test-explorer?view=vs-2019).

## Used nuget packages

* [EntityFrameworkCore](https://github.com/aspnet/EntityFrameworkCore) as ORM mapper.
* [AutoMapper](https://github.com/AutoMapper/AutoMapper) for mapping between database entities and data transfer objects.
* [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) providing tools to generate API documentation.
* [xUnit](https://github.com/xunit/xunit) as testing tool.
* [NSubstitute](https://github.com/nsubstitute/NSubstitute) as mocking library in unit tests.
* [fluentassertions](https://github.com/fluentassertions/fluentassertions) for asserting the results of unit tests.
