using StudySchedule.Contracts;
using StudySchedule.Models;
using StudySchedule.Services;

namespace StudySchedule.Pages;

public partial class MateriaManagement : ContentPage
{

    public MateriaManagement()
    {
        InitializeComponent();

    }

    private async void SalveMateria_Clicked(object sender, EventArgs e)
    {
        bool confirm;
        var button = (Button)sender;
        var existMateria = (Materia)button.CommandParameter;
        var getMateria = App.ServiceMateria.Get(existMateria.Id);
        try
        {

            if (getMateria == null)
            {
                Materia materia = new Materia();
                materia.NomeMateria = nameMateria.Text;
                confirm = App.ServiceMateria.Create(materia);
                if (confirm)
                {
                    await DisplayAlert("Materia", "Materia Salva com sucesso", "OK");
                }
            }
            getMateria.NomeMateria = nameMateria.Text;
            confirm = App.ServiceMateria.Update(getMateria);
            if (confirm)
            {
                await DisplayAlert("Materia", "Materia Alterada com sucesso", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", "{Não foi possível salvar a Matéria}" + ex.Message, "");
        }
    }
}