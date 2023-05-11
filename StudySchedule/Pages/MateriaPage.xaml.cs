using MigrationLibrary.Models;

namespace StudySchedule.Pages;

public partial class MateriaPage : ContentPage
{
    List<Materia> listMateria = new List<Materia> {
        new Materia {NomeMateria="Portugues",Id=1,BackGroundColor= "1" },
        new Materia {NomeMateria="Matemática",Id=1,BackGroundColor= "2" },
        new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "3" },
         new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "4" },
          new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "5" },
           new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "6" },
            new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "7" },
             new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "8" },
              new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "9" },
               new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "10" },
                new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "11" },
                 new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "12" },
                  new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "3" },
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "4" },
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "5" },
                   new Materia {NomeMateria="Programação Orientada a Objetos",Id=1,BackGroundColor= "6" },
    };
    public MateriaPage()
    {
        InitializeComponent();

        MateriaCollection.ItemsSource = listMateria;
    }
}