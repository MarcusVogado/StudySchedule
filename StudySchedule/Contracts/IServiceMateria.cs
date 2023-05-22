using MigrationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Contracts
{
    public interface IServiceMateria
    {
        public void Create(Materia materia);
        public ICollection<Materia> GetMaterias(Materia materiaId);
        public void Update(Materia materia);
        public void Delete(Materia materiaId);
    }
}
