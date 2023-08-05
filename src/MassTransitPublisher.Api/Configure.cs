using MassTransit;
using MassTransitPublisher.Api.Worker.Consumer;

namespace MassTransitPublisher.Api;
public static class Configure
{
    public static void AddMassTransitExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(c =>
        {
            c.AddConsumer<PersonCreateConsumer>();
            c.UsingRabbitMq((ctx, cfg) =>
            {
                var stringConnection = configuration["RabbitMq:ConnectionString"];
                cfg.Host(stringConnection);

                int retryCount;
                int interval;

                int.TryParse(configuration["RabbitMq:RetryCount"], out retryCount);
                int.TryParse(configuration["RabbitMq:IntervalTimeToRetry"], out interval);

                cfg.UseMessageRetry(retry => { retry.Interval(retryCount, TimeSpan.FromSeconds(interval)); });

                cfg.ConfigureEndpoints(ctx);

                cfg.AddMassTransitRabbitMQConsumers(ctx, configuration);
            });
        });
    }

    public static void AddMassTransitRabbitMQConsumers(this IRabbitMqBusFactoryConfigurator configurator, IBusRegistrationContext context, IConfiguration configuration)
    {
        var stringConnection = configuration["RabbitMq:ConnectionString"];
        configurator.Host(stringConnection);

        var person_create_queue = configuration["RabbitMq:PersonCreateQueue"] ?? "";
        configurator.ReceiveEndpoint(person_create_queue, e =>
        {
            e.PrefetchCount = 10;
            e.ConfigureConsumer<PersonCreateConsumer>(context);
        });
    }
}