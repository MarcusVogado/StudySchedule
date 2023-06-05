using StudySchedule.Helpers;
using StudySchedule.Models;

namespace StudySchedule.Pages;

public partial class AgendaDayPage : ContentPage
{
	private readonly ObjectGetPropertyValues objectGetPropertyValues;
	private List<Materia> materiasList;
	[Obsolete]
	public AgendaDayPage()
	{objectGetPropertyValues = new ObjectGetPropertyValues();
		InitializeComponent();
		Task.Run(() =>
		{
			Device.InvokeOnMainThreadAsync(async () =>
			{
				if (this.BindingContext != null)
				{
					var dayVerification = new List<Object>((IEnumerable<Object>)this.BindingContext);
					var listAgenda =  objectGetPropertyValues.getPropertyValues(dayVerification);
					foreach (var day in listAgenda)
					{
						var agenda = day.Value as Agenda;
						var materia = App.ServiceMateria.Get(agenda.MateriaId);
						materiasList.Add(materia);
					}
					AgendaCollection.ItemsSource = materiasList;
				}
			});
		});
	}

	private void GoToManagementPage_Clicked(object sender, TappedEventArgs e)
	{

	}
}