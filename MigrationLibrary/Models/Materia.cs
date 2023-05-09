using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationLibrary.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeMateria { get; set; } = null!;

        public ICollection<Materia> Materias { get; set; }= new List<Materia>();
    }
}
