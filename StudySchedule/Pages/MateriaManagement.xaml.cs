using Intents;
using MigrationLibrary.Models;
using StudySchedule.Services;

namespace StudySchedule.Pages;

public partial class MateriaManagement : ContentPage
{
    private ServiceMateria serviceMateria;
    public MateriaManagement(ServiceMateria _serviceMateria)
    {
        InitializeComponent();
        serviceMateria = _serviceMateria;
    }

    private async void SalveMateria_Clicked(object sender, EventArgs e)
    {   
        bool confirm;
        var button = (Button)sender;
        var existMateria = (Materia)button.CommandParameter;
        var getMateria = serviceMateria.Get(existMateria);
        try
        {
            if (getMateria == null)
            {
                Materia materia = new Materia();
                materia.NomeMateria = nameMateria.Text;
                confirm = serviceMateria.Create(materia);
                if (confirm)
                {
                    await DisplayAlert("Materia", "Materia Salva com sucesso", "OK");
                }
            }
            confirm = serviceMateria.Update(getMateria);
            if (confirm)
            {
                await DisplayAlert("Materia", "Materia Salva com sucesso", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "{Não foi possível salvar a Matéria}" + ex.Message, "");
        }


    }
}