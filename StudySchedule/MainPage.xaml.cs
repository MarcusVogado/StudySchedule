using MigrationLibrary.Models;
using StudySchedule.Pages;

namespace StudySchedule;

public partial class MainPage : ContentPage
{
    private const uint AnimationDuration = 800u;


    public MainPage()
	{
		InitializeComponent();
	}
    #region Anamation for Menu
    async private void MenuEvent_Clicked(object sender, TappedEventArgs e)
    {
        _ = MainContent.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
        await MainContent.ScaleTo(0.8, AnimationDuration);
        _ = MainContent.FadeTo(0.8, AnimationDuration);
        MenuContainer.IsVisible = true;
    }
    async private void GridArea_Tapped(object sender, TappedEventArgs e)
    {
        await CloseMenu();
        MenuContainer.IsVisible = false;
    }
    private async Task CloseMenu()
    {       
        _ = MainContent.FadeTo(1, AnimationDuration);
        _ = MainContent.ScaleTo(1, AnimationDuration);
        await MainContent.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
    }
    #endregion

    #region Days List For Clicked
    private void Monday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Tuesday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Wednesday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Thursday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Friday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Saturday_Clicked(object sender, TappedEventArgs e)
    {

    }

    private void Sunday_Clicked(object sender, TappedEventArgs e)
    {

    }

    #endregion

    #region MenuNavigation
    async private void GoToMateriaPage_Clicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new MateriaPage());
    }
    async private void GoToInfoPage_Clicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Info());
    }
    #endregion
}




