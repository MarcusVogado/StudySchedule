using MigrationLibrary.Models;

namespace StudySchedule.Pages;

public partial class MateriaPage : ContentPage
{
    List<Materia> listMateria = new List<Materia> {
        new Materia {NomeMateria="Portugues",Id=1,BackGroundColor= "1" },
        new Materia {NomeMateria="Matem�tica",Id=1,BackGroundColor= "Green" },
        new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
         new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
          new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
           new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
            new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
             new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
              new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
               new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                 new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                  new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                   new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                   new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
                   new Materia {NomeMateria="Programa��o Orientada a Objetos",Id=1,BackGroundColor= "Red" },
    };
    public MateriaPage()
    {
        InitializeComponent();

        MateriaCollection.ItemsSource = listMateria;
    }
}