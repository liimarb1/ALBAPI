using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class ITContext : DbContext
    {
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<FuncSquad> FuncionariosSquads { get; set; }
        public DbSet<Gestor> Gestores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=sa123456;Persist Security Info=True;User ID=sa;Initial Catalog=ALBAPI;Data Source=DESKTOP-9M0RIHB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuncSquad>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioId, e.SquadId });
            });

        }
    }
}
