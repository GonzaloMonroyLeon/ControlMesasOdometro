using ControlMesasOdometro.ControlMesasOdometro;

public class ControlMesasOdometroService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient _httpClient;
    private Timer? _timer;

    public event Action? OnDataUpdated;

    public List<ControlMesasOdometroModel> CurrentJackpots { get; private set; } = new List<ControlMesasOdometroModel>();

    public ControlMesasOdometroService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient(); // Crea una instancia de HttpClient
    }

    public async Task<List<ControlMesasOdometroModel>> GetJackpotAsync(string methodName)
    {
        var response = await _httpClient.GetFromJsonAsync<List<ControlMesasOdometroModel>>($"https://localhost:7217/api/Jackpot/{methodName}");
        return response ?? new List<ControlMesasOdometroModel>();
    }

    public async Task UpdateJackpotAsync(ControlMesasOdometroModel jackpot)
    {
        var response = await _httpClient.PostAsJsonAsync("https://localhost:7217/api/Jackpot/update", jackpot);
        response.EnsureSuccessStatusCode();
    }

    public void StartDataRefresh()
    {
        _timer = new Timer(async _ =>
        {
            try
            {
                CurrentJackpots = await GetJackpotAsync("GetVistaJackPot");
                OnDataUpdated?.Invoke(); // Dispara el evento cuando los datos se actualizan
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al refrescar los datos: {ex.Message}");
            }
        }, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
    }

    public void StopDataRefresh()
    {
        _timer?.Dispose();
    }
}


