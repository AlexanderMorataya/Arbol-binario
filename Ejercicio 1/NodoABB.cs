using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    class NodoABB
    {
        private int dato; //Campo del valor a inertar en el arbol binario

        private NodoABB izq; //Puntero al hijo izquierdo
        private NodoABB der; //Puntero al hijo derecho

        //Propiedades de los campos anteriores
        public int Dato {  get { return dato; } set {  dato = value; } } 
        internal NodoABB Izq { get { return izq; } set {  izq = value; } }
        public NodoABB Der { get {  return der; } set { der = value; } }

        //Constructor de la clase Nodo
        public NodoABB()
        {
            dato = 0;
            izq = null;
            der = null;
        }
    }
}
