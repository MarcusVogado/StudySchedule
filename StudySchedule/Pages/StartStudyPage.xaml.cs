using MigrationLibrary.Models;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace StudySchedule.Pages;

public partial class StartStudyPage : ContentPage, INotifyPropertyChanged
{
    TimeSpan timer;
    int horas;
    int minutos;
    int segundos = 0;


    public event PropertyChangedEventHandler PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public TimeSpan Time { get { return timer; } set { timer = value; OnPropertyChanged("Time"); } }
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
        Task.Run(() =>
        {
            Device.StartTimer(new TimeSpan(0,0,1), () =>
            {
                bool startStop = false;
                if (startStop == false)
                {
                    playandpauseBotton.Source = "pause.png";
                    startStop = true;
                }
                else
                {
                    playandpauseBotton.Source = "play.png";
                    startStop =false;
                }
                timer = timer-new TimeSpan(0,0,0,0,1000);
                timeItemSelected.Text = timer.ToString();
               

                return startStop;

            });

        });
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
            timer = new TimeSpan(horas, minutos, segundos);
            timeItemSelected.Text = timer.ToString();
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


}
