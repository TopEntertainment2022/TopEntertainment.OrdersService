using Microsoft.EntityFrameworkCore;
using TopEntertainment.Ordenes.AccessData;
using TopEntertainment.Ordenes.AccessData.Commands;
using TopEntertainment.Ordenes.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
IConfiguration configuration = configBuilder.Build();
string connectionString = configuration.GetSection("ConnectionString").Value;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ICompraService, CompraService>();
builder.Services.AddTransient<ICompraRepository, CompraRepository>();
builder.Services.AddTransient<ICarritoService, CarritoService>();
builder.Services.AddTransient<ICarritoRepository, CarritoRepository>();
builder.Services.AddDbContext<OrdenesContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:5500")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                          policy.WithOrigins("http://localhost:5500")
.AllowAnyHeader()
.AllowAnyMethod();
                      });
});


var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
