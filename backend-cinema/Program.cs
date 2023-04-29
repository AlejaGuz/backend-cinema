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

var app = builder.Build();

/*
 * using(var scope = app.Services.CreateScope())
{
    // Traemos el contexto que creamos
    var context = scope.ServiceProvider.GetRequiredService<AlejaCinemaContext>();
    // Hacemos la migracion hacia la base de datos
    context.Database.Migrate();
}
 */


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
