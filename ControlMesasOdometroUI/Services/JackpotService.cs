using System.Net.Http.Json;
using JackpotApi.Models;
public class JackpotService
{
	private readonly HttpClient _httpClient;

	public JackpotService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Jackpot>> GetJackpotsAsync()
	{
		return await _httpClient.GetFromJsonAsync<List<Jackpot>>("api/jackpots");
	}
}
