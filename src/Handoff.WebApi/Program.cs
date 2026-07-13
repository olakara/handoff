using Handoff.WebApi.Features.Employees.CreateEmployee;
using Handoff.WebApi.Features.Employees.GetEmployeeList;
using Handoff.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapCreateEmployee();
app.MapGetEmployeeList();

app.Run();

public partial class Program;
