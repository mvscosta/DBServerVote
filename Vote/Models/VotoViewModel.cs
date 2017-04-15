using System;
using System.ComponentModel.DataAnnotations;

namespace Vote.Models
{
    public class VotoViewModel : Vote.DAO.Voto
    {
        public new int Id { get; set; }

        [DisplayFormat(DataFormatString ="dd/MM/yyyy")]
        public new DateTime DataVoto { get; set; }

        public new DAO.Restaurante Restaurante { get; set; }

        public new DAO.Funcionario Funcionario { get; set; }

    }
}