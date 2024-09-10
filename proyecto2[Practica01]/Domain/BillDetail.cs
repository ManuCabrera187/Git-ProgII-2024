using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto2_Practica01_.Domain
{
    public class BillDetail
    {
        public Item Item { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public double SubTotal()
        {
            return  Price * Amount;
        }
    }
}
