using MigrationLibrary.Models;

namespace StudySchedule.Pages;

public partial class MateriaPage : ContentPage
{
    List<Materia> listMateria = new List<Materia> {
        new Materia {NomeMateria="Portugues",Id=1},
        new Materia {NomeMateria="Matemática",Id=1 },
        new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
         new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
          new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
           new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
            new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
             new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
              new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
               new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                 new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                  new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1},
    };
    public MateriaPage()
    {
        InitializeComponent();

        MateriaCollection.ItemsSource = listMateria;
    }

    private async void GoAddMateriaPage_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MateriaManagement());
    }
   
}