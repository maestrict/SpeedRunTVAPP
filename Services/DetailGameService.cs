using System.Text.Json;

namespace SpeedRunTV2.Services;

public class DetailGameService
{
    const string URL_READ_GAME = "http://localhost/dashboard/php/SiteSpeedRun/controller/API/acceuilApi.php";
    HttpClient httpClient;
    private List<Top10> top10;

    public DetailGameService()
    {
        httpClient = new HttpClient();
    }

    public async Task<List<Top10>> GetTop10Async(string gameName)
    {
        top10 = new List<Top10>();

        var game = gameName;

        var URL_TOP10 = $"{URL_READ_GAME}?game={game}";

        Uri uri = new Uri(URL_READ_GAME);
        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                top10 = JsonSerializer.Deserialize<List<Top10>>(content);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }


        return top10;

    }
}
