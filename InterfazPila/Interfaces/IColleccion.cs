using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazPila.Implementación
{
    public interface IColleccion
    {
        bool estaVacia();
        object extraer();
        object primero();
        bool añadir(object elemento);
    }
}
