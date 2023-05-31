using Microsoft.EntityFrameworkCore;
using MigrationLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationLibrary
{
    public class DbStudyContext : DbContext
    {
        public DbStudyContext()
        {
        }
        public DbStudyContext(DbContextOptions<DbStudyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite();
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
