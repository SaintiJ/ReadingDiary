using ReadingDiary.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

var connectionString = builder.Configuration.GetConnectionString("ReadingDiaryDbContext");

services.AddDataBase(connectionString ?? "");

services.AddControllers();
services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.UseDataBase();

app.Run();
