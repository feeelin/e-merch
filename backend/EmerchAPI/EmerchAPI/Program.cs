using EmerchAPI.Models.Dtos;
using EmerchAPI.Services;
using EmerchAPI.Services.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IYooMoneyService, YooMoneyService>();

builder.Services
    .AddHttpClient<IProductService, ProductService>(c =>
    {
        c.BaseAddress = new System.Uri("https://pocketbase.nakodeelee.ru/api/collections/products/");
    });
builder.Services
    .AddHttpClient<ICustomerService, CustomerService>(c =>
    {
        c.BaseAddress = new System.Uri("https://pocketbase.nakodeelee.ru/api/collections/customers/");
    });
builder.Services
    .AddHttpClient<IYooMoneyService, YooMoneyService>(c =>
    {
        c.BaseAddress = new System.Uri("https://yoomoney.ru/api/");
    });

var app = builder.Build();

app.UseSwagger(c => { c.RouteTemplate = "api/swagger/{documentName}/swagger.json"; });

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Emerch API V1");
    c.RoutePrefix = "api/swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();