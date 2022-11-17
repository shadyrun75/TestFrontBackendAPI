using shadyrun75.TestFrontBackendAPI.DB.SQLite;
using shadyrun75.TestFrontBackendAPI.DB.SQLite.Migrations;
using shadyrun75.TestFrontBackendAPI.Models.Authorization;

string dbPath = "D:\\ShaDy\\Shop.db";
string migrationAssemblyPath = "DB.SQLite.dll";
try
{
    Console.WriteLine("Start migration");
    MigrateExecuter.Main(migrationAssemblyPath, dbPath);
    Console.WriteLine("Success");

    Worker worker = new(dbPath);
    Console.WriteLine("Add test user");
    worker.Authorization.InsertUser(new UserMax()
    {
        Login = "Test",
        Display = "Test",
        IsActive = true,
        Password = "Test",
    });
    int count = 0;
    var users = worker.Authorization.GetUsers(0, 0, ref count, null);
    Console.WriteLine($"Finded {count} users");
    foreach (var user in users)
        Console.WriteLine($"{user.Id} {user.Login} {user.Display} {user.IsActive}");
}
catch (Exception ex)
{
    Console.WriteLine("FAILED");
    Console.WriteLine(ex.ToString());
}
Console.ReadLine();