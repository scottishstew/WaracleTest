using System.Reflection;
using HotelBookingAPI;
using HotelBookingAPI.Core.Commands.BookRoom;
using HotelBookingAPI.Core.Domain;
using HotelBookingAPI.Core.Queries.GetAvailableRooms;
using HotelBookingAPI.Core.Queries.GetBooking;
using HotelBookingAPI.Core.Queries.GetHotel;
using HotelBookingAPI.Core.Queries.HotelExists;
using HotelBookingAPI.Core.Queries.HotelRoomExists;
using HotelBookingAPI.Infrastructure;
using HotelBookingAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(

    builder.Configuration.GetConnectionString("WaracleTest") ?? throw new Exception("Unable to get database connection string."),
       null
    );

});

builder.Services.AddMediatR(x => {
    x.RegisterServicesFromAssemblyContaining<GetAvailableRoomsQuery>();
    x.RegisterServicesFromAssemblyContaining<GetAvailableRoomsQueryHandler>();
    x.RegisterServicesFromAssemblyContaining<GetBookingQuery>();
    x.RegisterServicesFromAssemblyContaining<GetBookingQueryHandler>();
    x.RegisterServicesFromAssemblyContaining<GetHotelQuery>();
    x.RegisterServicesFromAssemblyContaining<GetHotelQueryHandler>();
    x.RegisterServicesFromAssemblyContaining<HotelRoomExistsQuery>();
    x.RegisterServicesFromAssemblyContaining<HotelRoomExistsQueryHandler>();
    x.RegisterServicesFromAssemblyContaining<HotelExistsQuery>();
    x.RegisterServicesFromAssemblyContaining<HotelExistsQueryHandler>();
    x.RegisterServicesFromAssemblyContaining<BookRoomCommand>();
    x.RegisterServicesFromAssemblyContaining<BookRoomCommandHandler>();
});

builder.Services.AddScoped<IHotelRepository, HotelRepository>();

builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});


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
var serviceProvider = builder.Services.BuildServiceProvider();

Seeder seeder = new Seeder(app.Services.GetRequiredService<IConfiguration>(), serviceProvider.GetRequiredService<IHotelRepository>()!);

////Seed hotels and rooms
await seeder.SeedHotels();
await seeder.SeedHotelRooms();

app.Run();

