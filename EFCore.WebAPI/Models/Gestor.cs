using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Models
{
    public class Gestor
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
