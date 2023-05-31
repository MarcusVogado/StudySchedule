using Microsoft.EntityFrameworkCore;
using SqliteClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteClassLibrary
{
    public class StudyContext: DbContext
    {
        public StudyContext()
        {

        }
        public StudyContext(DbContextOptions<StudyContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite();
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
