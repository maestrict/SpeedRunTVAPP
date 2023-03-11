namespace SpeedRunTV2.ViewModel;

public partial class GameDetailViewModel : BaseViewModel
{

    DetailGameService detailgameService;
    public ObservableCollection<Top10> top { get; set; } = new();

    [ObservableProperty]
    bool isRefreshing;

    public GameDetailViewModel(DetailGameService detailGameService)
    {
        Title = "SpeedRunTV";
        this.detailgameService = detailGameService;

    }

    [RelayCommand]
    async Task GetTaskAsync(string nameGame)
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var games = await detailgameService.GetTop10Async(nameGame);
            foreach (var item in games)
            {
                top.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("ERROR", "Impossible de récupérer les données", "ok");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

}

