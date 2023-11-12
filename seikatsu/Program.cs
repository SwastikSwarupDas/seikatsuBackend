using MongoDB.Driver;
using seikatsu.Models;
using Microsoft.Extensions.Options;
using seikatsu.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UsersSettings>(
    builder.Configuration.GetSection(nameof(UsersSettings)));

builder.Services.AddSingleton<IUsersSettings>(sp =>
sp.GetRequiredService<IOptions<UsersSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("UsersSettings:ConnectionString")));

builder.Services.AddScoped<IUsersService, UsersService>();


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
