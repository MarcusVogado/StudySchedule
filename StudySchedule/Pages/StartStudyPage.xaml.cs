using MigrationLibrary.Models;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Timers;

namespace StudySchedule.Pages;

public partial class StartStudyPage : ContentPage, INotifyPropertyChanged
{
   
    int horas;
    int minutos;
    int segundos = 0;
    System.Timers.Timer timers;


    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public System.Timers.Timer Time { get { return timers; } set { timers = value; OnPropertyChanged("Time"); } }
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
    [Obsolete]
    private void playStop_Clicked(object sender, EventArgs e)
    {
            timers.Interval = 1000;
            timers.Elapsed += OnTimedEvent;
        
        var buttonValidation = playandpauseBotton.Source.ToString();
            if (buttonValidation == "File: play.png")
            {
              timers.Start();
                playandpauseBotton.Source = "pause.png";
              
            }
            else
            {
                playandpauseBotton.Source = "play.png";
              
           
            }
        
           
    }
    public async Task<bool> boleanTask()
    {
        var resposta = await DisplayAlert("Tempo terminou", "Deseja ir para proxia materia?", "sim", "não");
        return resposta;
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
            timeItemSelected.Text = "horas"+":"+"minutos"+":"+"00";
        }
        return;

    }
    public static Dictionary<string, object> getPropertyValues(object o)
    {
        if (o == null) return null;
        Dictionary<string, object> propertyValues = new Dictionary<string, object>();
        Type ObjectType = o.GetType();
        System.Reflection.PropertyInfo[] properties = ObjectType.GetProperties();
        foreach (System.Reflection.PropertyInfo property in properties)
        {
            propertyValues.Add(property.Name, property.GetValue(o, null));
        }
        return propertyValues;
    }
    private void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
    {
        horas--;

        //Update visual representation here
        //Remember to do it on UI thread

        if (horas == 0)
        {
            timers.Stop();
        }
    }

}
