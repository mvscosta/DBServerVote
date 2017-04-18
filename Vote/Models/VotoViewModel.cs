using System;
using System.ComponentModel.DataAnnotations;

namespace Vote.Models
{
    public class VotoViewModel : Vote.DAO.Voto
    {
        public new int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public new DateTime DataVoto { get { return base.DataVoto; } set { base.DataVoto = value; } }

        public DAO.Restaurante Restaurante { get { return base.Restaurante; } set { base.Restaurante= value; } }

        public DAO.Funcionario Funcionario { get { return base.Funcionario; } set { base.Funcionario= value; } }

    }
}