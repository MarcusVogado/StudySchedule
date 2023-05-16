using MigrationLibrary.Models;
using StudySchedule.Pages;

namespace StudySchedule;

public partial class MainPage : ContentPage
{
    private const uint AnimationDuration = 1000u;
    ICollection<Agenda> agendas = new List<Agenda> {
    new Agenda{DiaSemana="Segunda",Duracao=60,MateriaId=1,},
    new Agenda{DiaSemana="Segunda",Duracao=120,MateriaId=2,},
    new Agenda{DiaSemana="Segunda",Duracao=45,MateriaId=3,},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=4,},
    };
    List<Materia> listMateria = new List<Materia> {
        new Materia {NomeMateria="Português",Id=1 },
        new Materia {NomeMateria="Matemática",Id=2,},
        new Materia {NomeMateria="Programação Orientada a Objetos",Id=3},
         new Materia {NomeMateria="Engenharia de software",Id=4 },
          new Materia {NomeMateria="Programação Orientada a Objetos",Id=5 },
           new Materia {NomeMateria="Programação Orientada a Objetos",Id=6},
            new Materia {NomeMateria="Programação Orientada a Objetos",Id=7},
             new Materia {NomeMateria="Programação Orientada a Objetos",Id=8},
              new Materia {NomeMateria="Programação Orientada a Objetos",Id=9},
               new Materia {NomeMateria="Programação Orientada a Objetos",Id=10},
                new Materia {NomeMateria="Programação Orientada a Objetos",Id=11},
                 new Materia {NomeMateria="Programação Orientada a Objetos",Id=12},
                  new Materia {NomeMateria="Programação Orientada a Objetos",Id=13},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=14},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=15},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=16},
    };

    public MainPage()
	{
		InitializeComponent();
	}
    #region Anamation for Menu
    async private void MenuEvent_Clicked(object sender, TappedEventArgs e)
    {
        _ = MainContent.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn);
        await MainContent.ScaleTo(0.7, AnimationDuration);
        _ = MainContent.FadeTo(0.7, AnimationDuration);
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
        var agendaCollection = from agenda in agendas
                               join mat in listMateria
                               on agenda.MateriaId equals mat.Id
                               select new{
                                           Agenda = agenda,
                                           Materia = mat,
                               };
                                        
        AgendaCollection.ItemsSource= agendaCollection;
     
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




