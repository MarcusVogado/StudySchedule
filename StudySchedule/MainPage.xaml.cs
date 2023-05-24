using MigrationLibrary.Models;
using StudySchedule.Pages;

namespace StudySchedule;

public partial class MainPage : ContentPage
{
    
    private const uint AnimationDuration = 1000u;
    ICollection<Agenda> agendas = new List<Agenda> {
    new Agenda{DiaSemana="Segunda",Duracao=60,MateriaId=1},
    new Agenda{DiaSemana="Segunda",Duracao=120,MateriaId=2},
    new Agenda{DiaSemana="Segunda",Duracao=45,MateriaId=3},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=4},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=5},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=6},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=7},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=8},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=9},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=10},
    new Agenda{DiaSemana="Segunda",Duracao=80,MateriaId=11},

    };
    List<Materia> listMateria = new List<Materia> {
        new Materia {NomeMateria="Português",Id=1 },
        new Materia {NomeMateria="Matemática",Id=2,},
        new Materia {NomeMateria="Programação Orientada a Objetos",Id=3},
         new Materia {NomeMateria="Engenharia de software",Id=4 },
          new Materia {NomeMateria="Sistemas Operacionais",Id=5 },
           new Materia {NomeMateria="Lógica",Id=6},
            new Materia {NomeMateria="Sistemas de Comunicação",Id=7},
             new Materia {NomeMateria="Projeto WEB 1",Id=8},
              new Materia {NomeMateria="Sistemas para Internet",Id=9},
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
    private async void Monday_Clicked(object sender, TappedEventArgs e)
    {
        textLoading.IsVisible = true;
        textLoading.Text = "Carregando suas Matérias do dia ...";
        await Task.Delay(50);
        AgendaCollection.IsVisible = false;
        ProgressLoading.IsVisible = true;
        var agendaCollection = from agenda in agendas
                               join mat in listMateria
                               on agenda.MateriaId equals mat.Id
                               select new{
                                           Agenda = agenda,
                                           Materia = mat,
                               };
        await Task.Delay(50);
        textLoading.Text = "Quase lá...";
        await ProgressLoading.ProgressTo(1.0, 1000, Easing.Linear);        
        ProgressLoading.ProgressColor = Colors.Green;
        textLoading.Text = "Tudo pronto, Bons Estudos!";
        await Task.Delay(50);
        AgendaCollection.ItemsSource= agendaCollection;
        textLoading.IsVisible= false;
        ProgressLoading.IsVisible= false;
        AgendaCollection.IsVisible= true;
        ProgressLoading.ProgressColor = Colors.Red;
        ProgressLoading.Progress = 0;
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
   
    private async void StartStudy_Clicked(object sender, EventArgs e)
    {
       bool acepty = await DisplayAlert("START ESTUDOS", "DESEJA INICIAR OS ESTUDOS?", "SIM", "NÃO");
        if (acepty)
        {
            var materias = AgendaCollection.ItemsSource;
            //var agenda= materias.OfType<Agenda>;
            var pagina = new StartStudyPage();
            pagina.BindingContext = materias;
            await Navigation.PushAsync(pagina);
        }
        return;
    }

    private async void GoToManagementPage_Clicked(object sender, TappedEventArgs e)
    {
        var tapped = (TappedEventArgs)e;
        var pagina = new Pages.MateriaManagement();
        pagina.BindingContext =(Materia)tapped.Parameter;
        await Navigation.PushAsync(pagina);            
    }
}

//TODO- FAZER PAGINA DE CADASTRO DE MATÉRIA
//TODO- FAZER PAGINA DE MONTAGEM DA AGENDA
//TODO- ALTERAÇÃO NAS SEQUENCIAS DAS MATÉRIAS DA AGENDA DE FORMA DINAMICA ARRASTA E SOLTAR.
//TODO- CRIAÇÃO DOS SERVIÇOS ONLINE