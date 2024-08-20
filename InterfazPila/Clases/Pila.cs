using InterfazPila.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazPila.Clases
{
    public class Pila : ColleccionAbstracta
    {
        public Pila(int size):base(size) 
        { 

        }
        public override object extraer()
        {
            object e = null;

            if (!estaVacia())
            {
                //int i;
                //for (i = 0; i < next && array[i] == null; i++) ;
                //e = array[i];
                //array[i] = null;

                e = array[next];
                array[next] = null;
                next--;
            }

            return e;
        }
    }
}
