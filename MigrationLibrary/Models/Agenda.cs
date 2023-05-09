using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationLibrary.Models
{
    public class Agenda
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DiaSemana { get; set; } = null!;
        [Required]
        public DateTime HoraInicio { get; set; }
        [Required]
        public DateTime HoraFim { get; set; }
        [Required]
        public bool NotificationStatus { get; set; }
        [Required]
        public string Status { get; set; } = null!;
        public int MateriaId { get; set; }
        [ForeignKey("MateriaId")]
        public Materia Materia { get; set; } = null!;
    }
}
