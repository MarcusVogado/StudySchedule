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
    internal class ServiceAgenda : IServiceAgenda
    {
        private readonly DbStudyContext _dbStudy;
        public ServiceAgenda(DbStudyContext dbStudyContext)
        {
            _dbStudy = dbStudyContext;
        }
        public bool Create(Agenda agenda)
        {            
            try
            {
                _dbStudy.Agendas.Add(agenda);
                _dbStudy.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAgenda(Agenda agendaiD)
        {
            var agenda = GetAgenda(agendaiD);
            _dbStudy.Agendas.Remove(agenda);
            int linha = _dbStudy.SaveChanges();
            return (linha > 0) ? true : false;
        }

        public Agenda GetAgenda(Agenda agendaId)
        {
            var agenda = _dbStudy.Agendas.FirstOrDefault(agendaId);
            if (agenda == null)
            {
                return null;
            }
            return agenda;
        }

        public ICollection<Agenda> GetAgendaList(string diaSemana)
        {
            var agenda = _dbStudy.Agendas.Where(a => a.DiaSemana == diaSemana).ToList();
            if (agenda.Count == 0)
            {
                return null;
            }
            return agenda;
        }

        public async Task<bool> UpdateAgenda(Agenda agenda)
        {
            var agendaExistin = GetAgenda(agenda);
            _dbStudy.Agendas.Update(agenda);
            int linha = await _dbStudy.SaveChangesAsync();
            return (linha > 0) ? true : false;
        }
    }
}
