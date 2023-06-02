using Microsoft.EntityFrameworkCore;
using SQLite;
using StudySchedule.Contracts;
using StudySchedule.Models;
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
        string _dbPath;
        private SQLiteConnection conn;

        
        private void Init()
        {
            if (conn != null) return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Materia>();
        }
        public ServiceMateria(string dbPath)
        {
            _dbPath = dbPath;
        }
        public bool Create(Materia materia)
        {
            try
            {
                Init();
                if (materia == null) return false;                 
                var confirm = conn.Insert(materia);
                return (confirm > 0) ? true : false;

            }
            catch
            {
                return false;
            }
        }
        public Materia Get(Materia materiaId)
        {
            try
            {
                Init();
                var materia = from u in conn.Table<Materia>()
                              where u.Id == materiaId.Id
                              select u;
                return materia.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
        public ICollection<Materia> GetMaterias()
        {
            Init();
            var materia = conn.Table<Materia>().ToList();
            return materia;
        }

        public bool Delete(Materia materiaId)
        {
            Init();
            var materia = Get(materiaId);
            if (materia != null)
            {
                try
                {                   
                    var confirm = conn.Delete(materia);
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
            Init();
            var existMateria= Get(materia);
            if(existMateria != null)
            {              
               var confirm = conn.Update(materia);
                return (confirm>0) ? true : false;
            }
            return false;
        }
    }
}
