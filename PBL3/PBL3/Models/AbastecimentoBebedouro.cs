using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class AbastecimentoBebedouro
    {
        public int AbastecimentoBebedouroId { get; set; }
        public int BebedouroId { get; set; }
        public virtual Bebedouro Bebedouro { get; set; }
        public int EstoqueId { get; set; }
        public virtual Estoque Estoque  { get; set; }

        public bool mudastatusBebedouro()
        {
            if (!Bebedouro.TemSaco)
            {
                return true;
            }
            return false;
        }
        public bool decrementaEstoque()
        {
            if (Estoque.QuaSacoCopos != 0)
            {
                return true;
            }
            return false;
        }
    }
}