using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRepositorioGenerico.Model
{
    public class Contexto :DbContext
    {
        public Contexto(DbContextOptions<Contexto> opts) :base(opts)
        {
        }
       public DbSet<Repositorio> Repositorio { get; set; }
       public DbSet<TipoRepositorio> TipoRepositorio { get; set; }
       public DbSet<TelefonoRepositorio> TelefonoRepositorio { get; set; }
    }
}
