using EFCore.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Repo
{
    public class ITContext : DbContext
    {

        //Padrão entityframework = quando criar uma entidade lista tem que ser plural, exemplo: equipamentos
        //DbSet = Lista

        public ITContext(DbContextOptions<ITContext> options) : base(options) {}
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<FuncSquad> FuncionariosSquads { get; set; }
        public DbSet<Gestor> Gestores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //chave para gerar a Haskey composta

            modelBuilder.Entity<FuncSquad>(entity =>
            {
                entity.HasKey(e => new { e.FuncionarioId, e.SquadId });
            });

        }
    }
}
