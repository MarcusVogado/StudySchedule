using MigrationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Contracts
{
    public interface IServiceAgenda
    {
        public bool Create(Agenda agenda);
        public ICollection<Agenda> GetAgendaList();
        public void UpdateAgenda(Agenda agenda);
        public void DeleteAgenda(Agenda agendaiD);
        
    }
}
