using BookingApi.Options;
using BookingApi.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using System;
using BookingApi.Commands.AddNewReservation;
using BookingApi.Commands.UpdateReservation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseInMemoryDatabase("BookingDb");
});
builder.Services.AddControllers(options =>
options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<AddNewReservationCommand>, AddNewReservationCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateReservationCommand>, UpdateReservationCommandValidator>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.Configure<UserOptions>(
    builder.Configuration.GetSection("Users"));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
