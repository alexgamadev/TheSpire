using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TheSpire.Models;
using TheSpire.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ElementalTowerDbSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<IElementalTowerDbSettings>(sp =>
    sp.GetRequiredService<IOptions<ElementalTowerDbSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(services =>
    new MongoClient(builder.Configuration.GetValue<string>("MongoDB:ConnectionString")));

builder.Services.AddScoped<IAscensionDataRepo, AscensionDataRepo>();

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
