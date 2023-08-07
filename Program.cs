using Microsoft.AspNetCore.Identity;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Database;
using IDS_Integrador.Service;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

MariaDbServerVersion version = new(new Version(10, 6, 12));

builder.Services.AddDbContext<IDSBContext>
    (
        contextOptions => contextOptions.UseMySql(builder.Configuration["ConnectionStrings:Default"], version)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
    );


builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();


builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<IDSBContext>();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<RoleManager<Role>>();

var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    
    
    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
