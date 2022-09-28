using Flurl.Http;

namespace CryptoBot.Services;

public class IntegrationService
{
    private readonly IConfiguration _configuration;
    private int _cont;
    public IntegrationService(IConfiguration configuration)
    {
        _configuration = configuration;
        _cont = 0;
    }

    public async Task SendMessage()
    {
        var endpoint = _configuration.GetSection("Binance:ApiUrlBase").Value;
        var teste = _configuration.GetSection("Telegram:Url").Value;

        Console.WriteLine($"{_cont++} - {endpoint}");
        var request = string.Format(teste, "Bot API token");

        await request.PostJsonAsync(new { chat_id = -634037016, text = Resource.Regular_Report });
    }
}
