// See https://aka.ms/new-console-template for more information
using InterfazPila.Clases;
using InterfazPila.Interfaces;

Console.WriteLine("Hello, World!");

var cola = new Cola(3);
var pila = new Pila(5);

ColleccionAbstracta[] array = {cola, pila};

foreach (ColleccionAbstracta c in array)



Console.WriteLine();