using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder.Models
{
    public class Cuenta
    {
        public Cuenta() { }
        public int numero { get; set; }
        public string propietario { get; set; }
        public double tasa { get; set; }
        public double saldo { get; set; }
        public TipoCuenta tipo { get; set; }
        
    }
}
