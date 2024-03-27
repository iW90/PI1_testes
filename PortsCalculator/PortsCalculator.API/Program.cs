using PortsCalculator.Infra.Database;
using Microsoft.EntityFrameworkCore;
using PortsCalculator.App.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the DbContext.
var conectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));

// Configure AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
