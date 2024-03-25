using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    class ABB
    {
        //*************CAMPOS UTILIZADOS POR EL PROGRAMA Y SUS PROPIEDADES*******************

        private NodoABB raiz; //Nodo de la raiz del arbol

        //Propuedad del campo raiz
        internal NodoABB Raiz { get { return raiz; } set{ raiz = value; } }


        //******************METODOS UTILIZADOS POR EL ARBOL******************
        //Constructor del arbol binario
        public ABB() 
        {
            raiz = null;
        }
        //Metodo de insercion
        public NodoABB Insertar(int pDato, NodoABB pNodo) 
        {
            if(pNodo == null) 
            {
                NodoABB temp = new NodoABB();
                temp.Dato = pDato;

                return temp;
            }
            if(pDato < pNodo.Dato)
            {
                pNodo.Izq = Insertar(pDato, pNodo.Izq);
            }
            if(pDato > pNodo.Dato)
            {
                pNodo.Der = Insertar(pDato, pNodo.Der);
            }

            return pNodo;
        }
        //Metodo de eliminacion
        public NodoABB Borrar(int pDato, NodoABB pNodo)
        {
            NodoABB pPadre, pMinimo;
            
            if(pNodo == null) //Revisar si el nodo actual es nulo
                return null;

            if (pDato < pNodo.Dato) //Busqueda del nodo
            {
                pNodo.Izq = Borrar(pDato, pNodo.Izq);
            }
            else
            {
                if(pDato > pNodo.Dato)
                {
                    pNodo.Der = Borrar(pDato, pNodo.Der);
                }
                else
                {
                    //Casos de eliminacion
                    if(pNodo.Izq == null && pNodo.Der == null && pNodo.Dato == pDato) //Caso de nodo sin hijos
                    {
                        pNodo = null;
                        return pNodo;
                    }
                    else if(pNodo.Izq == null && pNodo.Dato == pDato) //Caso de nodo con un solo hijo a la derecha
                    {
                        pPadre = BuscarPadre(pNodo.Dato ,pNodo);
                        pPadre.Der = pNodo.Der;

                        return pNodo;
                    }
                    else if(pNodo.Der == null && pNodo.Dato == pDato) //Caso de nodo con un solo hijo a la izquierda
                    {
                        pPadre = BuscarPadre(pNodo.Dato, pNodo);
                        pPadre.Izq = pNodo.Izq;

                        return pNodo;
                    }
                    else if(pNodo.Izq != null && pNodo.Der != null && pNodo.Dato == pDato) //Caso de un nodo con dos hijos
                    {
                        pMinimo = BuscarMinimo(pNodo.Der);
                        pNodo.Dato = pMinimo.Dato;

                        pNodo.Der = Borrar(pMinimo.Dato, pNodo.Der);
                    }                    
                }
            }

            return pNodo;
        }

        //***********TIPOS DE RECORRIDO**************
        //Recorrido en PreOrder
        public string PreOrder(NodoABB pNodo)
        {
            string cadena = "";

            if (pNodo == null)
                return "";

            cadena += pNodo.Dato.ToString() + ","; //Ingresa el valor del nodo raiz
            if (pNodo.Izq != null) 
            {
                cadena += PreOrder(pNodo.Izq); //Ingresa el valor de hijo izquierdo de la raiz
            }
            if (pNodo.Der != null) 
            {
                cadena += PreOrder(pNodo.Der); //Ingresa el valor de hijo derecho de la raiz
            }

            return cadena;
        }
        //Recorrido en PostOrder
        public string PostOrder(NodoABB pNodo)
        {
            string cadena = "";

            if (pNodo == null)
                return "";

            if (pNodo.Izq != null) 
            {
                cadena += PostOrder(pNodo.Izq); //Ingresa el valor de hijo izquierdo de la raiz
            }
            if (pNodo.Der != null) 
            {
                cadena += PostOrder(pNodo.Der); //Ingresa el valor de hijo derecho de la raiz
            }
            cadena += pNodo.Dato.ToString() + ","; //Ingresa el valor del nodo raiz                        

            return cadena;
        }
        //Recorrido en InOrder
        public string InOrder(NodoABB pNodo)
        {
            string cadena = "";

            if (pNodo == null)
                return "";

            if(pNodo.Izq != null) 
            {
                cadena += InOrder(pNodo.Izq); //Ingresa el valor de hijo izquierdo de la raiz
            }
            cadena += pNodo.Dato.ToString() + ","; //Ingresa el rato del nodo raiz
            if (pNodo.Der != null)
            {
                cadena += InOrder(pNodo.Der); //Ingresa el valor de hijo derecho de la raiz
            }

            return cadena;
        }

        //****************BUSQUEDAS*******************
        //Busqueda del nodo padre
        public NodoABB BuscarPadre(int pDato, NodoABB pNodo)
        {
            NodoABB temp = null;

            if(pNodo == null)
                return null;

            //Verificamos si el nodo actual es el padre
            if (pNodo.Izq != null)
                if (pNodo.Izq.Dato == pDato)
                    return pNodo;

            if (pNodo.Der != null)
                if (pNodo.Der.Dato == pDato)
                    return pNodo;

            //Revisamos los hijos del nodo actual
            if(pNodo.Izq != null && pDato < pNodo.Dato) //Revision del nodo izquierdo
            {
                temp = BuscarPadre(pDato, pNodo.Izq);
            }
            if(pNodo.Der != null && pDato > pNodo.Dato)
            {
                temp = BuscarPadre(pDato, pNodo.Der);
            }

            return temp;
        }
        //Busqueda del nodo con el valor minimo
        public NodoABB BuscarMinimo(NodoABB pNodo)
        {
            NodoABB aux, minimo;

            if(pNodo == null) 
                return null;

            minimo = aux = pNodo;

            while(aux.Izq != null) 
            {
                aux = aux.Izq;
                minimo = aux;
            }

            return minimo;
        }
        //Busqueda del nodo con el valor maximo
        public NodoABB BuscarMaximo(NodoABB pNodo)
        {
            NodoABB aux, maximo;

            if (pNodo == null)
                return null;

            maximo = aux = pNodo;

            while (aux.Der != null)
            {
                aux = aux.Der;
                maximo = aux;
            }

            return maximo;
        }



    }
}
