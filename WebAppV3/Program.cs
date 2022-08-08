using Microsoft.EntityFrameworkCore;
using WebAppV3.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient("bible", configureClient: client =>
{
    client.BaseAddress = new Uri("https://bible-api.com/");
});

builder.Services.AddDbContext<BibleContext>(opt =>
    opt.UseInMemoryDatabase("BibleList"));

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