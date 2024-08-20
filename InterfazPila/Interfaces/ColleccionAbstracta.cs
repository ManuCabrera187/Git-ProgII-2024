using InterfazPila.Clases;
using InterfazPila.Implementación;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfazPila.Interfaces
{
    public abstract class ColleccionAbstracta : IColleccion
    {
        protected object[] array;
        protected int next;

        public ColleccionAbstracta(int size)
        {
            array = new object[size];
            next = -1;
        }

        public virtual bool añadir(object elemento)
        {
            bool añadido = false;

            if(next<array.Length)
            {
                array[++next] = elemento;
                añadido = true;
            }

            return añadido;
        }

        public virtual bool estaVacia()
        {
            return next == -1;
        }

        public abstract object extraer();

        public virtual object primero()
        {
            //return array.First();

            object? e = null;
            if(!estaVacia())
            {
                e = array[0];
            }

            return e;
        }
    }
}
