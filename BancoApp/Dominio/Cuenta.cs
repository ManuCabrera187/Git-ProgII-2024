using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoApp.Dominio
{
    public class Cuenta
    {
        int Cbu { get; set; }
        double Saldo { get; set; }
        DateTime UltimoMovimiento { get; set; }
    }
}
