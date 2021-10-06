using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P1___Ap1___Julio_Cesar_20180771.Entidades;

namespace P1___Ap1___Julio_Cesar_20180771.DAL
{
   public class Contexto : DbContext
    {
        public DbSet <Aportes> Aportes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DATA Source = DATA\AporteDatabase.db");
        }
    }
}
