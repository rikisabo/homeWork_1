using תשתית_לניהול_חנות_פיצה_חני_גולדברג;
using myServices;
using myModels.Interfaces;
using myModels;
using FileService;
using FileService.Interfaces;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IpizzaMannager,ChanisPizzaServices>();
builder.Services.AddTransient<Iorders,OrdersServices>();
builder.Services.AddScoped<Iworker,WorkerServices>();
builder.Services.AddSingleton<IFileService<ChanisPizza>>(new ReadWrite<ChanisPizza>(@"H:\webApi\חדש\file.json"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseDefaultFiles();
// app.UseStaticFiles();
// app.UseAuthorization();

app.MapControllers();

app.Run();

// app.UseHttpsRedirection();

// app.UseAuthorization();

// app.MapControllers();

// app.Run();
