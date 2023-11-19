using MongoDB.Driver;
using seikatsu.Models;
using Microsoft.Extensions.Options;
using seikatsu.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<UsersSettings>(
    builder.Configuration.GetSection(nameof(UsersSettings)));

builder.Services.AddSingleton<IUsersSettings>(sp =>
sp.GetRequiredService<IOptions<UsersSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("UsersSettings:ConnectionString")));

builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.Configure<PropertiesSettings>(
    builder.Configuration.GetSection(nameof(PropertiesSettings)));

builder.Services.AddSingleton<IPropertiesSettings>(sp =>
sp.GetRequiredService<IOptions<PropertiesSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("PropertiesSettings:ConnectionString")));

builder.Services.AddScoped<IPropertiesService, PropertiesService>();

builder.Services.Configure<NotifSettings>(
    builder.Configuration.GetSection(nameof(NotifSettings)));

builder.Services.AddSingleton<INotifSettings>(sp =>
sp.GetRequiredService<IOptions<NotifSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("NotifSettings:ConnectionString")));

builder.Services.AddScoped<INotifService, NotifService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});


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

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
