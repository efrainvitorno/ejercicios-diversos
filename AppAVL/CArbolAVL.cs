using System;
using System.Collections.Generic;

namespace AppAVL
{

    public class CArbolAVL : CArbolBB
    {

        #region  ======================  Constructores  =======================
        /* -------------------------------------------------------------- */
        public CArbolAVL() : base()
        {

        }

        /* -------------------------------------------------------------- */
        public CArbolAVL(CArbolBB pSubArbolIzq, Object pRaiz, CArbolBB pSubArbolDer) : base(pSubArbolIzq, pRaiz, pSubArbolDer)
        {

        }

        /* -------------------------------------------------------------- */
        public static CArbolAVL CrearAVL()
        {
            return new CArbolAVL();
        }

        /* -------------------------------------------------------------- */
        public static CArbolAVL CrearAVL(CArbolBB pSubArbolIzq, Object pRaiz, CArbolBB pSubArbolDer)
        {
            return new CArbolAVL(pSubArbolIzq, pRaiz, pSubArbolDer);
        }
        #endregion Constructores

        #region ====================   Metodos    ======================

        /* -------------------------------------------------------------- */
        private bool EstaBalanceado()
        {
            int Altura1 = (SubArbolIzq == null ? 0 : 1 + SubArbolIzq.Altura());
            int Altura2 = (SubArbolDer == null ? 0 : 1 + SubArbolDer.Altura());
            return (Math.Abs(Altura1 - Altura2) < 2);
        }

        /* -------------------------------------------------------------- */
        protected void RotacionSimpleIzq()
        {
            // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
            SubArbolDer = CArbolAVL.CrearAVL(SubArbolIzq.SubArbolDer, Raiz, SubArbolDer);
            Raiz = SubArbolIzq.Raiz;
            SubArbolIzq = SubArbolIzq.SubArbolIzq;
        }

        /* -------------------------------------------------------------- */
        protected void RotacionDobleIzq()
        {
            ((CArbolAVL)SubArbolIzq).RotacionSimpleDer();
            RotacionSimpleIzq();
        }

        /* -------------------------------------------------------------- */
        protected void RotacionSimpleDer()
        {
            // La rotación se efectuara primero creando un nuevo arbol y reordenando los enlaces de los arboles
            SubArbolIzq = CArbolAVL.CrearAVL(SubArbolIzq, Raiz, SubArbolDer.SubArbolIzq);
            Raiz = SubArbolDer.Raiz;
            SubArbolDer = SubArbolDer.SubArbolDer;
        }

        /* -------------------------------------------------------------- */
        protected void RotacionDobleDer()
        {
            ((CArbolAVL)SubArbolDer).RotacionSimpleIzq();
            RotacionSimpleDer();
        }

        /* -------------------------------------------------------------- */
        public override void Agregar(object Elemento)
        {
            if (Raiz == null)
                Raiz = Elemento;
            else
            {
                if (Elemento.ToString().CompareTo(Raiz.ToString()) < 0)
                {   // Agregar el nuevo elemento como hijo Izq
                    if (SubArbolIzq == null)
                        SubArbolIzq = CArbolAVL.CrearAVL(null, Elemento, null);
                    else
                        SubArbolIzq.Agregar(Elemento);
                    // Balancear arbol si esta desbalanceado
                    if (!EstaBalanceado())
                        if (Elemento.ToString().CompareTo(SubArbolIzq.Raiz.ToString()) < 0)
                            RotacionSimpleIzq();
                        else
                            RotacionDobleIzq();
                }
                else
                {   // Agregar el nuevo elemento como hijo Der
                    if (SubArbolDer == null)
                        SubArbolDer = CArbolAVL.CrearAVL(null, Elemento, null);
                    else
                        SubArbolDer.Agregar(Elemento);
                    // Balancear arbol si esta desbalanceado
                    if (!EstaBalanceado())
                        if (Elemento.ToString().CompareTo(SubArbolDer.Raiz.ToString()) > 0)
                            RotacionSimpleDer();
                        else
                            RotacionDobleDer();
                }
            }
        }
        // numero de nodo de hojas 
        public int NumeroNodosHojas()
        {
            if (Raiz == null)
            {
                return 0;
            }
            if (SubArbolIzq == null && SubArbolDer == null)
            {
                return 1;
            }
            int hojasIzq = SubArbolIzq != null ? ((CArbolAVL)SubArbolIzq).NumeroNodosHojas() : 0;
            int hojasDer = SubArbolDer != null ? ((CArbolAVL)SubArbolDer).NumeroNodosHojas() : 0;
            return hojasIzq + hojasDer;
        }
        // nodo es hoja 
        public bool NodoEsHoja()
        {
            return SubArbolIzq == null && SubArbolDer == null;
        }
        // numero de nodos un hijo
        public int NumeroDeNodosunHijo()
        {
            if (Raiz == null)
            {
                return 0;
            }

            int count = 0;

            if ((SubArbolIzq == null && SubArbolDer != null) || (SubArbolIzq != null && SubArbolDer == null))
            {
                count = 1;
            }

            int nodosIzq = SubArbolIzq != null ? ((CArbolAVL)SubArbolIzq).NumeroDeNodosunHijo() : 0;
            int nodosDer = SubArbolDer != null ? ((CArbolAVL)SubArbolDer).NumeroDeNodosunHijo() : 0;

            return count + nodosIzq + nodosDer;
        }
        // numero de nodos 2 hijos 

        public int NumeroDeNodosDosHijos()
        {
            if (Raiz == null)
            {
                return 0;
            }

            int count = 0;

            if (SubArbolIzq != null && SubArbolDer != null)
            {
                count = 1;
            }

            int nodosIzq = SubArbolIzq != null ? ((CArbolAVL)SubArbolIzq).NumeroDeNodosDosHijos() : 0;
            int nodosDer = SubArbolDer != null ? ((CArbolAVL)SubArbolDer).NumeroDeNodosDosHijos() : 0;

            return count + nodosIzq + nodosDer;
        }
        // suma de los elementos 
        public int SumaTotalElementos()
        {
            if (Raiz == null)
            {
                return 0;
            }

            int suma = Convert.ToInt32(Raiz);

            int sumaIzq = SubArbolIzq != null ? ((CArbolAVL)SubArbolIzq).SumaTotalElementos() : 0;
            int sumaDer = SubArbolDer != null ? ((CArbolAVL)SubArbolDer).SumaTotalElementos() : 0;

            return suma + sumaIzq + sumaDer;
        }
        //Si los valores son números enteros, que calcule el promedio.
        public double CalcularPromedio()
        {
            int sumaTotal = SumaTotalElementos();
            int numeroNodos = NumeroDeNodos();
            return numeroNodos == 0 ? 0 : (double)sumaTotal / numeroNodos;
        }
        // numero de nodos 
        public int NumeroDeNodos()
        {
            if (Raiz == null)
            {
                return 0;
            }
            int nodosIzq = SubArbolIzq != null ? ((CArbolAVL)SubArbolIzq).NumeroDeNodos() : 0;
            int nodosDer = SubArbolDer != null ? ((CArbolAVL)SubArbolDer).NumeroDeNodos() : 0;
            return 1 + nodosIzq + nodosDer;
        }
       



        #endregion Metodos
    }
}
