
using Serilog;
using NLog;
using NLog.Web;
using AlgoServer.Internal;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
builder.Logging.ClearProviders();
builder.Host.UseNLog();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

string? writeConnectionString = configuration.GetValue<string>("ConnectionStrings:WriteConnectionString");
string? readConnectionString = configuration.GetValue<string>("ConnectionStrings:ReadConnectionString");
DapperMysql.Init(writeConnectionString, readConnectionString);


builder.Services.AddSingleton<ApiMiddleware>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


string logPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "logs\\log-.txt").Replace("\\", "/");

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(
        logPath,
        rollingInterval: RollingInterval.Hour,
        retainedFileCountLimit: 720)
    .CreateLogger();


var app = builder.Build();


app.UseCors("AllowAll");


app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<ApiMiddleware>();

app.MapControllers();

app.Urls.Add("http://localhost:5278");

app.Run();
