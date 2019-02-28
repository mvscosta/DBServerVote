using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vote.Core.Interfaces.Model;

namespace Vote.ViewModels
{
    public class VotoViewModel
    {
        public int Id { get; set; }
        public int IdRestaurante { get; set; }
        public string RestauranteNome { get; set; }
        public int IdFuncionario { get; set; }
        public string FuncionarioNome { get; set; }
        public System.DateTime DataVoto { get; set; }
    }
}