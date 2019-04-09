using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBL3.Models
{
    public class Estoque
    {
        public int EstoqueId { get; set; }
        public int CopoId { get; set; }
        public virtual Copo Copo { get; set; }
        public int QuaSacoCopos { get; set; }
    }
}