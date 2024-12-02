using Fluxo.Core;
using Fluxo.Core.Messaging;
using Fluxo.Data;
using Fluxo.SharedKernel.Bus;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddFluxoCoreServices();
builder.Services.AddFluxoDataServices();

//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<FluxoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("FluxoDbConnection")));

builder.Services.AddScoped<IMessageSender, MessageSender>();

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
