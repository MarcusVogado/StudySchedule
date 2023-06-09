﻿using StudySchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudySchedule.Contracts
{
    public interface IServiceMateria
    {
        public bool Create(Materia materia);
        public  ICollection<Materia> GetMaterias();
        public bool Update(Materia materia);
        public bool Delete(Materia materiaId);
        public Materia Get(int materiaId);

    }
}
