using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using RepoUoW.Database;
using RepoUoW.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RepoDbContext>(options =>
{
    var connString = builder.Configuration.GetConnectionString("MySQL");
    var mySqlConnection = new MySqlConnection(connString);

    options
        .EnableSensitiveDataLogging()
        .UseLazyLoadingProxies()
        .UseMySql(connString, ServerVersion.AutoDetect(mySqlConnection));


});

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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