using shadyrun75.TestFrontBackendAPI.Interfaces.DB;
using shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var dbPath = "/var/testapi/Shop.db";
var migrationAssemblyPath = "DB.SQLite.dll";
builder.Services.AddSingleton<IWorker>(new shadyrun75.TestFrontBackendAPI.DB.SQLite.Worker(dbPath));

var app = builder.Build();

MigrateExecuter.Main(migrationAssemblyPath, dbPath);
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(builder => builder.AllowAnyOrigin());
app.UseAuthorization();

app.MapControllers();

app.Run();
