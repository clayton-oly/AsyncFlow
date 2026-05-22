using AsyncFlow.Core.Consumer;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var rabbitSettings = builder.Configuration
    .GetSection("RabbitMq");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ProdutoCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(
            rabbitSettings["Host"],
            "/",
            h =>
            {
                h.Username(rabbitSettings["Username"]!);

                h.Password(rabbitSettings["Password"]!);
            });
        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
