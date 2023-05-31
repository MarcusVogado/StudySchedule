﻿using MigrationLibrary;
using MigrationLibrary.Models;
using StudySchedule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Services
{
    public class ServiceMateria : IServiceMateria
    {
        private readonly DbStudyContext _dbStudyContext;

        public ServiceMateria()
        {
            _dbStudyContext =  new DbStudyContext();
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
            var materia = _dbStudyContext.Materias.Find(materiaId.Id);
            if (materia != null)
            {
                return materia;
            }
            return null;
        }
        public async  Task<ICollection<Materia>> GetMaterias()
        {
            var materia = new List<Materia>(_dbStudyContext.Materias).ToList();
            return materia;
        }

        public bool Delete(Materia materiaId)
        {
            var materia = Get(materiaId);
            if (materia != null)
            {
                try
                {
                    _dbStudyContext.Remove(materia);
                    var confirm = _dbStudyContext.SaveChanges();
                    return (confirm > 0) ? true : false;
                }
                catch
                {
                    return false;
                }               
            }
            return false;
        }

        public bool Update(Materia materia)
        {
            var existMateria= Get(materia);
            if(existMateria != null)
            {
                _dbStudyContext.Update(materia);
               var confirm= _dbStudyContext.SaveChanges();
                return (confirm>0) ? true : false;
            }
            return false;
        }
    }
}
