using Transferencia.DATA;
using Transferencia.DATA.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;
var postgresSQLConnectionConfiguration = new PostgreSQLConfiguration(configuration.GetConnectionString("PostgresSQLConnection"));
builder.Services.AddSingleton(postgresSQLConnectionConfiguration);

builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<ICuenta, CuentaRepostitory>();
builder.Services.AddScoped<IBanco, BancoRepository>();
builder.Services.AddScoped<ITransferencia,TransferenciaRepository>();


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
