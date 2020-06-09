using System;
using Microsoft.EntityFrameworkCore;
using System.Text;




namespace _2do_Usuario.Entidades
{
    public class Contexto : DbContext
    {
        public DbSet<Entidades.Usuarios> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuider)
        {
            optionsBuider.UseSqlite(@"Data source = Data\Usuarios.db");
        }
    }
}