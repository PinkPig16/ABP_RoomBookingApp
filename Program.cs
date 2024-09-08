

using ABP_RoomBookingApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ABP_RoomBookingApp.Interfaces.HallConferenceRepository, ABP_RoomBookingApp.Repository.HallConferenceRepository>();
builder.Services.AddScoped<ABP_RoomBookingApp.Interfaces.PriceModifiersRepository, ABP_RoomBookingApp.Repository.PriceModifiersRepository>();
builder.Services.AddScoped<ABP_RoomBookingApp.Interfaces.ServiceConferenceRepository, ABP_RoomBookingApp.Repository.ServiceConferenceRepository>();
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
