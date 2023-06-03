using SQLite;
using StudySchedule.Contracts;
using StudySchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Services
{
    public class ServiceAgenda : IServiceAgenda
    {
        string _dbPath;       
        
        private SQLiteConnection conn;
        
        private void Init()
        {
            if (conn != null) return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Agenda>();
        }
        public ServiceAgenda(string dbPath)
        {
            _dbPath = dbPath;
        }
        public bool Create(Agenda agenda)
        {            
            try
            {
                Init();
               var result =  conn.Insert(agenda);
                return (result > 0) ? true : false ;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteAgenda(Agenda agendaiD)
        {
            Init();
            var agenda = GetAgenda(agendaiD);
             var linha= conn.Delete<Agenda>(agenda);           
            return (linha > 0) ? true : false;
        }

        public Agenda GetAgenda(Agenda agendaId)
        {
            Init();
            var agenda = conn.Table<Agenda>().FirstOrDefault(agendaId);
            if (agenda == null)
            {
                return null;
            }
            return agenda;
        }

        public ICollection<Agenda> GetAgendaList(string diaSemana)
        {
            Init();
            var agenda = conn.Table<Agenda>().Where(a => a.DiaSemana == diaSemana).ToList();
            if (agenda.Count == 0)
            {
                return null;
            }
            return agenda;
        }

        public async Task<bool> UpdateAgenda(Agenda agenda)
        {
            Init();
            var agendaExistin = GetAgenda(agenda);
            int linha = conn.Update(agenda);           
            return (linha > 0) ? true : false;
        }
    }
}
