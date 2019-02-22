using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vote.Core.Interfaces.Model;

namespace Vote.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
    }
}