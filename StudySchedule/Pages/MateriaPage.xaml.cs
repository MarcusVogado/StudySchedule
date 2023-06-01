using Microsoft.Maui.Controls;
using StudySchedule.Contracts;
using StudySchedule.Models;
using StudySchedule.Services;

namespace StudySchedule.Pages;

public partial class MateriaPage : ContentPage
{
    private readonly ServiceMateria serviceMateria;

    [Obsolete]
    public MateriaPage()
    {
        InitializeComponent();       

        Task.Run(() =>
        {
            Device.BeginInvokeOnMainThread(async () =>
            { 
                var listMaterias= await App.ServiceMateria.GetMaterias();
                if (listMaterias != null)
                {
                    MateriaCollection.ItemsSource= listMaterias;
                }               
            });
        });              
    }

    private async void GoAddMateriaPage_Clicked(object sender, EventArgs e)
    {
        var tapped = (TappedEventArgs)e;
        var pagina = new MateriaManagement();
        pagina.BindingContext = (Materia)tapped.Parameter;

        await Navigation.PushAsync(pagina);
    }
   
}