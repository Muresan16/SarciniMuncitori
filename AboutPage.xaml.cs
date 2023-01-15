using System.Diagnostics;

namespace SarciniMuncitori;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}
    private void OnContactUsClicked(object sender, EventArgs e)
    {
        var email = "mailto:alexmuresan@gmail.com";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(email)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void OnWebClicked(object sender, EventArgs e)
    {
        var url = "https://www.depozituldeutilaje.ro/";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
    private void OnFacebookClicked(object sender, EventArgs e)
    {
        var url = "https://www.facebook.com/Pieseieftineutilajeconstructii";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }

    private void OnWhatsAppClicked(object sender, EventArgs e)
    {
        var url = "https://api.whatsapp.com/send?phone=+40758957234/";
        var process = new Process
        {
            StartInfo = new ProcessStartInfo(url)
            {
                UseShellExecute = true
            }
        };
        process.Start();
    }
}