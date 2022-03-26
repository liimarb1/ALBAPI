using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Dominio
{
    public class FuncSquad
    {
        public  int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
    }
}
