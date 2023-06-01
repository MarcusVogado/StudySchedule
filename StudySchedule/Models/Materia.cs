using SQLite;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Models
{
    [Table("Materias")]
    public class Materia
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Required]
        public string NomeMateria { get; set; } = null!;
    }
}
