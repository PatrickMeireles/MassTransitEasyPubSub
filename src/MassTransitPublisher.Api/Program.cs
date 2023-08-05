using MassTransit;
using MassTransitPublisher.Api;
using MassTransitPublisher.Api.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransitExtension(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/person", async (PersonCreateMessage model, IBusControl _bus) =>
{
    await _bus.Publish(model);

    return Results.Ok();
});

//app.MapControllers();

app.Run();
