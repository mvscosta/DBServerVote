using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vote.Core.Interfaces.Model;

namespace Vote.ViewModels
{
    public class RestauranteViewModel
    {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string CategoriaNome { get; set; }
        public int IdModalidade { get; set; }
        public string ModalidadeNome { get; set; }
        public decimal? DistanciaMedia { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public decimal? ValorMedio { get; set; }
        public bool Ativo { get; set; }
    }
}