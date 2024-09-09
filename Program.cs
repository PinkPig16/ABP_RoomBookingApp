

using ABP_ConferenceBookingApp.Service;
using ABP_ConferenceBookingApp.Data;
using Microsoft.EntityFrameworkCore;
using ABP_ConferenceBookingApp.Validatior;
using ABP_ConferenceBookingApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.HallConferenceRepository, HallConferenceRepository>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.PriceModifiersRepository, PriceModifiersRepository>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.BookingHallRepository, BookingHallRepository>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.ServiceConferenceRepository, ServiceConferenceRepository>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.HallConferenceService, HallConferenceService>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.BookingHallService, BookingHallService>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.ServiceConferenceService, ServiceConferenceService>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.HallConferenceValidator, HallConferenceValidator>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.ServiceConferenceValidator, ServiceConferenceValidator>();
builder.Services.AddScoped<ABP_ConferenceBookingApp.Interfaces.BookingHallValidator, BookingHallValidator>();
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddDbContext<ApplicationDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

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

app.Run();
