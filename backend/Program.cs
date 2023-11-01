using backend.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllersWithViews()
       .AddJsonOptions(options =>
       {
           options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
       });

builder.Services.AddDbContext<DatabaseContext>(options => {
    var connectionString = configuration.GetConnectionString("connec");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy to allow requests from all origins.

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("defaultPolicy", options =>
    {
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.SetIsOriginAllowed((origin) => true);
    });
});

var app = builder.Build();
app.UseCors("defaultPolicy");
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
