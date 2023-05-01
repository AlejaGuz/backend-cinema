using backend_cinema.Services;
using backend_cinema.Services.Interfaces;
using DB_cinema;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//traemos el connectionString de nuestro archivo de configurcion json
builder.Services.AddDbContext<AlejaCinemaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cinemaconnection"));
});

//Inyeccion de dependencias de los services
builder.Services.AddTransient<IShowingService, ShowingService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IChairService, ChairService>();
builder.Services.AddTransient<ISaleService, SaleService>();
builder.Services.AddTransient<IScheduleService, ScheduleService>();

//Se configura CORS para que permita acceso desde cualquier dominio
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigins",
    app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAnyOrigins");


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
