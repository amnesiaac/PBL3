using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Bebedouro
    {
        public int BebedouroId { get; set; }
        public string Localizacao { get; set; }
        public bool TemSaco { get; set; }

        public Bebedouro()
        {
            TemSaco = false;
        }
    }
}