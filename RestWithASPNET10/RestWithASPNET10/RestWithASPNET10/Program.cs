using RestWithASPNET10.Configurations;
using RestWithASPNET10.Repositories;
using RestWithASPNET10.Repositories.Interface;
using RestWithASPNET10.Service.Person.Interface;
using RestWithASPNET10.Services.Book;
using RestWithASPNET10.Services.Book.Interface;
using RestWithASPNET10.Services.Person;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();

builder.Services.AddControllers();

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
