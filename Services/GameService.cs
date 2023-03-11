using System.Text.Json;

namespace SpeedRunTV2.Services;

public class GameService
{
	const string URL_READ_GAME = "http://localhost/dashboard/php/SiteSpeedRun/controller/API/acceuilApi.php";
	HttpClient httpClient;
    private List<Games> games;

    public GameService()
	{
		httpClient = new HttpClient();
	}

	public async Task<List<Games>> GetGamesAsync()
	{
		games = new List<Games>();
		Uri uri = new Uri(URL_READ_GAME);
		try
		{
			HttpResponseMessage response = await httpClient.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				string content = await response.Content.ReadAsStringAsync();
				games = JsonSerializer.Deserialize<List<Games>>(content);
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
		}


		return games;

	}
}

