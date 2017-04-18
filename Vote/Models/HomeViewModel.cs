using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vote.DAO;

namespace Vote.Models
{
    public class HomeViewModel
    {
        public Restaurante RestauranteVencedor { get; set; }

        public int VotosComputadosHoje { get; set; }
        
    }
}