using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Models
{
    [Table("Agendas")]
    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DiaSemana { get; set; } = null!;
        [Required]
        public int Duracao { get; set; }

        public int MateriaId { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; } = null!;
    }
}
