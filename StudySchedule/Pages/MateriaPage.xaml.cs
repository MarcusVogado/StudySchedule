using MigrationLibrary.Models;
using StudySchedule.Contracts;
using StudySchedule.Services;

namespace StudySchedule.Pages;

public partial class MateriaPage : ContentPage
{
    private readonly IServiceMateria serviceMateria;

    [Obsolete]
    public MateriaPage()
    {
        InitializeComponent();
        serviceMateria = new ServiceMateria();

        Task.Run(() =>
        {
            Device.BeginInvokeOnMainThread(async () =>
            { 
                var listMaterias= await serviceMateria.GetMaterias();
                if (listMaterias != null)
                {
                    MateriaCollection.ItemsSource= listMaterias;
                }               
            });
        });              
    }

    private async void GoAddMateriaPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MateriaManagement());
    }
   
}