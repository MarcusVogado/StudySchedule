using StudySchedule.Helpers;
using StudySchedule.Models;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Timers;

namespace StudySchedule.Pages;

public partial class StartStudyPage : ContentPage, INotifyPropertyChanged
{
    private bool isRunning;
    TimeSpan timer;
    TimeSpan timerItemSelected;
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
    private void SetTime()
    {
        ItemSelected.Text = $"{timer.Hours}:{timer.Minutes}:{timer.Seconds}";
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
    private async void playStop_Clicked(object sender, EventArgs e)
    {
        isRunning = !isRunning;
        playandpauseBotton.Source = isRunning ? "pause.png" : "play.png";
        while (isRunning)
        {
            timer = timer - TimeSpan.FromSeconds(1);
            SetTime();
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
    private void Onreset(object sender, EventArgs e)
    {
        timer = timerItemSelected;
        SetTime();
    }

    private void resetTimer_Clicked(object sender, EventArgs e)
    {
        timer = timerItemSelected;
        isRunning = !isRunning;
        SetTime();
    }

    public void CarregarMaterias()
    {
        if(this.BindingContext != null)
        {
			List<Object> collection = new List<Object>((IEnumerable<Object>)this.BindingContext);
			collectionStartStudy.ItemsSource = collection;
        }
        else
        {
            DisplayAlert("OPS..", "SEM MAT�RIAS PARA O DIA SELECIONADO", "OK");
        }        
    }

    private void ItemAlteradoScrolled(object sender, CurrentItemChangedEventArgs e)
    {
        isRunning = false;
        playandpauseBotton.Source = "play.png";
        var itemSelected = (CurrentItemChangedEventArgs)e;
        Agenda agenda = new Agenda();
        if (itemSelected.CurrentItem != null)
        {
			var propriedades = App.ObjectGetPropertyValues.getPropertyValues(itemSelected.CurrentItem);
            var duracao = propriedades.Where(a => a.Key == "Agenda");
            foreach (var a in duracao)
            {
                var agendaValue = a.Value;
                agenda = (Agenda)agendaValue;
            }
            horas = agenda.Duracao / 60;
            minutos = agenda.Duracao % 60;
            timerItemSelected = new TimeSpan(horas, minutos, segundos);
            timer = timerItemSelected;
            ItemSelected.Text = timerItemSelected.ToString();
        }
        return;
    } 
}
