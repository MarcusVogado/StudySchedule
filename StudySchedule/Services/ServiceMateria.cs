using MigrationLibrary;
using MigrationLibrary.Models;
using StudySchedule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Services
{
    public class ServiceMateria : IServiceMateria
    {
        private readonly DbStudyContext _dbStudyContext;

        public ServiceMateria(DbStudyContext dbStudyContext)
        {
            _dbStudyContext = dbStudyContext;
        }
        public bool Create(Materia materia)
        {
            try
            {
                if (materia == null) return false;
                _dbStudyContext.Add(materia);
                var confirm = _dbStudyContext.SaveChanges();
                return (confirm > 0) ? true : false;

            }
            catch
            {
                return false;
            }
        }
        public Materia Get(Materia materiaId)
        {
            var materia = _dbStudyContext.Materias.FirstOrDefault(materiaId);
            if (materia != null)
            {
                return materia;
            }
            return null;    
        }
        public ICollection<Materia> GetMaterias(Materia materiaId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Materia materiaId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Materia materia)
        {
            throw new NotImplementedException();
        }
    }
}
