

namespace SpeedRunTV2.ViewModel;

public partial class GamesViewModel : BaseViewModel
{

	GameService gameService;
	public ObservableCollection<Games> Game { get; set; } = new ();

	public bool FirstRun { get; set; } = true;

	[ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    public async Task PerformmyTestButton(string obj)
    {
        await Shell.Current.DisplayAlert("test", obj, "test");
    }


    public GamesViewModel(GameService gameService)
    {
		Title = "SpeedRunTV";
        this.gameService = gameService;

	}

    [RelayCommand]
    async Task GetTaskAsync()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			var games = await gameService.GetGamesAsync();
			foreach(var item in games)
			{
				Game.Add(item);
			}
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("ERROR", "Impossible de récupérer les données","ok");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}

	}
} 

