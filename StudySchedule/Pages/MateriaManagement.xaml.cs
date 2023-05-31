using MigrationLibrary.Models;
using StudySchedule.Contracts;
using StudySchedule.Services;

namespace StudySchedule.Pages;

public partial class MateriaManagement : ContentPage
{
  private readonly ServiceMateria _serviceMateria;
    public MateriaManagement()
    {
        InitializeComponent();  
        _serviceMateria = new ServiceMateria();
    }

    private async void SalveMateria_Clicked(object sender, EventArgs e)
    {   
        bool confirm;
        var button = (Button)sender;
        var existMateria = (Materia)button.CommandParameter;
        var getMateria = _serviceMateria.Get(existMateria);
        try
        {
            if (getMateria == null)
            {
                Materia materia = new Materia();
                materia.NomeMateria = nameMateria.Text;
                confirm = _serviceMateria.Create(materia);
                if (confirm)
                {
                    await DisplayAlert("Materia", "Materia Salva com sucesso", "OK");
                }
            }
            confirm = _serviceMateria.Update(getMateria);
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