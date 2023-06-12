using StudySchedule.Models;
using StudySchedule.Pages;
using StudySchedule.Services;
using System.Linq;

namespace StudySchedule;

public partial class MainPage : ContentPage
{
    
    private const uint AnimationDuration = 1000u;   
    public MainPage()
	{
		InitializeComponent();        
	}
    #region Animation for Menu
    async private void MenuEvent_Clicked(object sender, TappedEventArgs e)
    {
        await (_ = MainContent.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn));
        _ = await MainContent.ScaleTo(0.7, AnimationDuration);
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
		#region FontAndClicked
		segunda.FontSize = 25;
        terca.FontSize = 19;
        quarta.FontSize = 19;
        quinta.FontSize = 19;
        sexta.FontSize = 19;
        sabado.FontSize = 19;
        domingo.FontSize = 19;
		#endregion
		/*const string diaSemana = "Segunda-Feira";
        LoadingListAgenda(diaSemana);*/
	}

	private void Tuesday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 25;
		quarta.FontSize = 19;
		quinta.FontSize = 19;
		sexta.FontSize = 19;
		sabado.FontSize = 19;
		domingo.FontSize = 19;
		#endregion
		const string diaSemana = "Terça-Feira";
		LoadingListAgenda(diaSemana);
	}

    private void Wednesday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 19;
		quarta.FontSize = 25;
		quinta.FontSize = 19;
		sexta.FontSize = 19;
		sabado.FontSize = 19;
		domingo.FontSize = 19;
		#endregion
		const string diaSemana = "Quarta-Feira";
		LoadingListAgenda(diaSemana);

	}

    private void Thursday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 19;
		quarta.FontSize = 19;
		quinta.FontSize = 25;
		sexta.FontSize = 19;
		sabado.FontSize = 19;
		domingo.FontSize = 19;
		#endregion
		const string diaSemana = "Quinta-Feira";
		LoadingListAgenda(diaSemana);
	}

    private void Friday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 19;
		quarta.FontSize = 19;
		quinta.FontSize = 19;
		sexta.FontSize = 25;
		sabado.FontSize = 19;
		domingo.FontSize = 19;
		#endregion
		const string diaSemana = "Sexta-Feira";
		LoadingListAgenda(diaSemana);

	}

    private void Saturday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 19;
		quarta.FontSize = 19;
		quinta.FontSize = 19;
		sexta.FontSize = 19;
		sabado.FontSize = 25;
		domingo.FontSize = 19;
		#endregion
		const string diaSemana = "Sábado";
		LoadingListAgenda(diaSemana);
	}

    private void Sunday_Clicked(object sender, TappedEventArgs e)
	{
		#region FontAndClicked
		segunda.FontSize = 19;
		terca.FontSize = 19;
		quarta.FontSize = 19;
		quinta.FontSize = 19;
		sexta.FontSize = 19;
		sabado.FontSize = 19;
		domingo.FontSize = 25;
		#endregion
		const string diaSemana = "Domingo";
		LoadingListAgenda(diaSemana);
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

    private async void LoadingListAgenda(string diaSemana)
    {
		var agendas = App.ServiceAgenda.GetAgendaList(diaSemana);
		var listMateria = App.ServiceMateria.GetMaterias();

		textLoading.IsVisible = true;
		textLoading.Text = "Carregando suas Matérias do dia ...";
		await Task.Delay(50);
		AgendaCollection.IsVisible = false;
		ProgressLoading.IsVisible = true;
		var agendaCollection = from agenda in agendas
							   join mat in listMateria
							   on agenda.MateriaId equals mat.Id
							   select new
							   {
								   Agenda = agenda,
								   Materia = mat,
							   };
		await Task.Delay(50);
		textLoading.Text = "Quase lá...";
		await ProgressLoading.ProgressTo(1.0, 1000, Easing.Linear);
		ProgressLoading.ProgressColor = Colors.Green;
		textLoading.Text = "Tudo pronto, Bons Estudos!";
		await Task.Delay(50);
		AgendaCollection.ItemsSource = agendaCollection;
		textLoading.IsVisible = false;
		ProgressLoading.IsVisible = false;
		AgendaCollection.IsVisible = true;
		ProgressLoading.ProgressColor = Colors.Red;
		ProgressLoading.Progress = 0;
	}

	private void GoToAgendaDayPage(object sender, EventArgs e)
	{
		var button = (ImageButton)sender;
		var pagina= new AgendaDayPage();
		pagina.BindingContext =(Agenda)button.CommandParameter;
		Navigation.PushAsync(pagina);
	}
}





//TODO- FAZER PAGINA DE MONTAGEM DA AGENDA
//TODO- ALTERAÇÃO NAS SEQUENCIAS DAS MATÉRIAS DA AGENDA DE FORMA DINAMICA ARRASTA E SOLTAR.
//TODO- CRIAÇÃO DOS SERVIÇOS ONLINE