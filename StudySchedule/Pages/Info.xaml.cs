using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;

namespace StudySchedule.Pages;

public partial class Info : ContentPage
{
	public Info()
	{
		InitializeComponent();
	}

    private async void BrowserOpenGitHub_Clicked(object sender, EventArgs e)
    {
        try
        {
            var tapped = (TappedEventArgs)e;
            string uri = (string)tapped.Parameter;
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro",$"Não foi possível acessar o link;{ex.Message} ", "ok");
        }
    }
    private async void BrowserOpenLinkedin_Clicked(object sender, EventArgs e)
    {
        try
        {
            var tapped = (TappedEventArgs)e;
            string uri = (string)tapped.Parameter;
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Não foi possível acessar o link;{ex.Message} ", "ok");
        }
    }
}