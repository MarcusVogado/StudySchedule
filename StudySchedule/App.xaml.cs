using StudySchedule.Helpers;
using StudySchedule.Services;

namespace StudySchedule;

public partial class App : Application
{	public static ServiceMateria ServiceMateria { get; private set; }
	public static ServiceAgenda ServiceAgenda { get; private set; }
	public static ObjectGetPropertyValues  ObjectGetPropertyValues { get; private set; }
	public App(ServiceMateria matetriaService, ServiceAgenda agendaService )
	{
		InitializeComponent();
		MainPage = new AppShell();		
		ServiceAgenda = agendaService;
		ServiceMateria = matetriaService;
		
	}
}
