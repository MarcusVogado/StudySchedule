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
            //TODO- ADICIONARA ALGORITMO PARA VERIFICAÇÃO DE HORÁRIOS ANTES DE CADASTRAR AGENDA
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
            if (agenda != null)
            {
                _dbStudy.Agendas.Remove(agenda);
                _dbStudy.SaveChanges();
                return true;
            }
            return false;
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

        public bool UpdateAgenda(Agenda agenda)
        {
            var agendaExistin = GetAgenda(agenda);
            if (agendaExistin != null)
            {
                _dbStudy.Agendas.Update(agenda);
                _dbStudy.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
