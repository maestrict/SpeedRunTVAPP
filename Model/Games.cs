using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace SpeedRunTV2.Model;

public class Games
{
	public string id { get; set; }
    public string name { get; set; }
    public string Photo { get; set; }
    public string desciption { get; set; }
    public string URL_photo
    {
        get => $"localhost/dashboard/php/SiteSpeedRun/Ressources/{Photo}";
    }


}

