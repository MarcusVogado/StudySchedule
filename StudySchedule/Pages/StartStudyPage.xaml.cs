using MigrationLibrary.Models;
namespace StudySchedule.Pages;

public partial class StartStudyPage : ContentPage
{
   TimeSpan timer ;
    int horas;
    int minutos;
    [Obsolete]
    public StartStudyPage()
    {
        InitializeComponent();

        Task.Run(() =>
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                CarregarMaterias();
            });
        });

    }

    private void playStop_Clicked(object sender, EventArgs e)
    {


    }

    private void resetTimer_Clicked(object sender, EventArgs e)
    {

    }

    public void CarregarMaterias()
    {
        List<Object> collection = new List<Object>((IEnumerable<Object>)this.BindingContext);
        collectionStartStudy.ItemsSource = collection;
    }

    private void ItemAlteradoScrolled(object sender, CurrentItemChangedEventArgs e)
    {
        var itemSelected= (CurrentItemChangedEventArgs)e;
        var agenda= (Agenda)itemSelected.CurrentItem;
        int horas = agenda.Duracao / 60;
        int minutos = agenda.Duracao % 60;
        timer = new TimeSpan(horas,minutos,59) ;

        timeItemSelected.Text=timer.ToString();
    }
}