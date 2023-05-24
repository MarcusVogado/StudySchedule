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

        var button = (Button)sender;
        var existMateria = (Materia)button.CommandParameter;
        if (existMateria == null)
        {
            try
            {

            }
            catch (Exception menssagemExeption)
            {
                await DisplayAlert("Erro", "{Não foi possível salvar a Matéria}"+menssagemExeption.Message, "");
            }
            Materia materia = new Materia();
            materia.NomeMateria = nameMateria.Text;
            var confirm = serviceMateria.Create(materia);
            if (confirm)
            {
                await DisplayAlert("Materia", "Materia Salva com sucesso", "OK");
            }

        }


    }
}