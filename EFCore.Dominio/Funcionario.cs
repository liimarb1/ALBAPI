using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Dominio
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Gestor Gestor { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<FuncSquad> FuncionariosSquads { get; set; }

    }
}
