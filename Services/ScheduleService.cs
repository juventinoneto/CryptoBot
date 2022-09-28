namespace CryptoBot.Services;

public class ScheduleService : BackgroundService
{
    private readonly IServiceProvider _service;

    public ScheduleService(IServiceProvider service)
    {
        _service = service;
        // https://stackoverflow.com/questions/31271355/how-to-use-telegram-api-in-c-sharp-to-send-a-message
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromSeconds(10));

            using var scope = _service.CreateScope();
            var integrationService = scope.ServiceProvider
                .GetRequiredService<IntegrationService>();

            Console.WriteLine($"Horário: {DateTime.Now.TimeOfDay}");

            await integrationService.SendMessage();
        }
    }
}

