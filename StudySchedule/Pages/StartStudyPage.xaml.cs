using Android.App.Job;
using Java.Security;
using MigrationLibrary.Models;
using System.Reflection;


namespace StudySchedule.Pages;

public partial class StartStudyPage : ContentPage
{
    TimeSpan timer;
    int horas;
    int minutos;
    int segundos = 0;
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

        Device.StartTimer(timer, () =>
        {
            
            Device.BeginInvokeOnMainThread(() =>
            {
              timeItemSelected.Text=timer.ToString();
            });
            bool pausePlay=false;
            if(pausePlay==true) {
                pausePlay = false;
                //playandpauseBotton.Source = "play.png";

            }
            else
            {
                pausePlay=true;
               //playandpauseBotton.Source = "pause.png";
            }
            return pausePlay; 
        });

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
        var itemSelected = (CurrentItemChangedEventArgs)e;
        Agenda agenda = new Agenda();
        if (itemSelected.CurrentItem != null)
        {
            var propriedades = getPropertyValues(itemSelected.CurrentItem);
            var duracao = propriedades.Where(a => a.Key == "Agenda");
            foreach (var a in duracao)
            {
                var agendaValue = a.Value;
                agenda = (Agenda)agendaValue;
            }
            horas = agenda.Duracao / 60;
            minutos = agenda.Duracao % 60;
            timer = new TimeSpan(horas, minutos, segundos);
            timeItemSelected.Text = timer.ToString();
        }
        return;

    }
    public static Dictionary<string, object> getPropertyValues(object o)
    {
        if(o == null) return null;
        Dictionary<string, object> propertyValues = new Dictionary<string, object>();
        Type ObjectType = o.GetType();
        System.Reflection.PropertyInfo[] properties = ObjectType.GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            propertyValues.Add(property.Name, property.GetValue(o, null));
        }
        return propertyValues;
    }
}
