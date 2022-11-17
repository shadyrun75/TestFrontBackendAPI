using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.DB.SQLite;
using shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var dbPath = "Shop.db";
var migrationAssemblyPath = "DB.SQLite.dll";
builder.Services.AddSingleton<IWorker>(new shadyrun75.TestFrontBackendAPI.DB.SQLite.Worker(dbPath));

var app = builder.Build();

MigrateExecuter.Main(migrationAssemblyPath, dbPath);
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
