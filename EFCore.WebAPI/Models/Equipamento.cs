using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}
