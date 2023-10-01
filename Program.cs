using Microsoft.AspNetCore.Identity;
using IDS_Integrador.Model.Entity;
using IDS_Integrador.Database;
using IDS_Integrador.Database.Test;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.Security.Claims;

string  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors
                    (
                        options =>
                            {
                                options.AddPolicy(MyAllowSpecificOrigins, policy => 
                                    {
                                        policy.WithOrigins("http://localhost:5173/");
                                    }
                                );
                            }    
                    );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

MariaDbServerVersion version = new(new Version(10, 6, 12));

builder.Services.AddDbContext<IDSBContext>
    (
        contextOptions => contextOptions.UseMySql(builder.Configuration["ConnectionStrings:Desktop"], version)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
    );

    builder.Services.AddDbContext<TeamContext>
    (
        contextOptions => contextOptions.UseMySql(builder.Configuration["ConnectionStrings:Desktop"], version)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
    );

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();


builder.Services.AddIdentity<User, Role>( options => 
                                        {
                                            options.Password.RequiredLength = 8; 
                                            options.Password.RequiredUniqueChars = 0;
                                            options.Password.RequireNonAlphanumeric = false;
                                            options.Password.RequiredUniqueChars = 0;
                                            options.Password.RequireLowercase = false;
                                            options.Password.RequireUppercase = false;
                                        })
                                        .AddEntityFrameworkStores<IDSBContext>();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<RoleManager<Role>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

bool[] dbChanges = new bool[3] {false,false,false};

PopulateDB.LoadContext(app);
dbChanges[0] = await PopulateDB.LoadCategories();
dbChanges[1] = await PopulateDB.LoadTeams();
dbChanges[2] = await PopulateDB.LoadPlayers();

if(dbChanges.Any(x => x == true)){
    PopulateDB.SaveChangesAsync();
}

app.Run();
