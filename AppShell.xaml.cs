namespace SpeedRunTV2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(DetailGame), typeof(DetailGame));
	}
}

