using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication1.DB;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.AddSerilog(logger, dispose: true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IPointService, PointService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
