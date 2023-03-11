namespace SpeedRunTV2.View;

public partial class MainPage : ContentPage
{

	GamesViewModel gamesViewModel;


	public MainPage(GamesViewModel gamesViewModel)
	{
		InitializeComponent();
		this.gamesViewModel = gamesViewModel;
		BindingContext = gamesViewModel;
		
	}

    protected override async void OnAppearing()
    {
		

		GamesCollection.ItemsSource = gamesViewModel.Game;

		if(gamesViewModel.FirstRun && gamesViewModel.GetTaskCommand.CanExecute(null))
		{
			await gamesViewModel.GetTaskCommand.ExecuteAsync(null);
			gamesViewModel.FirstRun = false;
		}

        base.OnAppearing();
    }

}


