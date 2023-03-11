namespace SpeedRunTV2.View;

public partial class Setting : ContentPage
{
	public Setting()
	{
		InitializeComponent();
	}
    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new SignUp());
    }

    async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        string Pseudo = pseudo.Text;
        String Password = password.Text;

        await Shell.Current.DisplayAlert("nom",Pseudo, Password);


    }
}
