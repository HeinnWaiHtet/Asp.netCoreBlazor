using EmployeeManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
/** Configure For SQL Server Database Connection */
services.AddDbContextPool<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
});

/** add dependency injection for employee and department */
services.AddScoped<IEmployeeRepository, EmployeeRepository>();
services.AddScoped<IDepartmentRepository, DepartmentRepository>();

services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
