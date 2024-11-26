using System;

namespace AppAVL
{
    public class CArbolBB
    {
        #region ***********************  Atributos   *************************
        private CArbolBB aSubArbolIzq;
        private Object aRaiz;
        private CArbolBB aSubArbolDer;
        #endregion Atributos  
        #region *********************  Constructores   ***********************
        /* -------------------------------------------------------------- */
        public CArbolBB()
        {
            aSubArbolIzq = null;
            aRaiz = null;
            aSubArbolDer = null;
        }
        /* -------------------------------------------------------------- */
        public CArbolBB(CArbolBB pSubArbolIzq, Object pRaiz, CArbolBB pSubArbolDer)
        {
            aSubArbolIzq = pSubArbolIzq;
            aRaiz = pRaiz;
            aSubArbolDer = pSubArbolDer;
        }

        /* -------------------------------------------------------------- */
        public static CArbolBB Crear()
        {
            return new CArbolBB();
        }

        /* -------------------------------------------------------------- */
        public static CArbolBB Crear(CArbolBB pSubArbolIzq, Object pRaiz, CArbolBB pSubArbolDer)
        {
            return new CArbolBB(pSubArbolIzq, pRaiz, pSubArbolDer);
        }
        #endregion Constructores

        #region *********************  Propiedades  ***********************
        /* ---------------------------------------------------------- */
        public CArbolBB SubArbolIzq
        {
            get
            {
                return aSubArbolIzq;
            }
            set
            {
                aSubArbolIzq = value;
            }
        }

        /* ---------------------------------------------------------- */
        public object Raiz
        {
            get
            {
                return aRaiz;
            }
            set
            {
                aRaiz = value;
            }
        }

        /* ---------------------------------------------------------- */
        public CArbolBB SubArbolDer
        {
            get
            {
                return aSubArbolDer;
            }
            set
            {
                aSubArbolDer = value;
            }
        }

        #endregion Propiedades

        #region ***********************  Metodos  *************************

        /* -------------------------------------------------------------- */
        public bool EstaVacio()
        {
            return (aRaiz == null);
        }

        /* -------------------------------------------------------------- */
        public virtual void Agregar(object Elemento)
        {
            if (aRaiz == null)
            {
                aRaiz = Elemento;
            }
            else
                if (Elemento.ToString().CompareTo(aRaiz.ToString()) < 0)
            {
                if (aSubArbolIzq == null)
                    aSubArbolIzq = new CArbolBB(null, Elemento, null);
                else
                    aSubArbolIzq.Agregar(Elemento);
            }
            else
            {
                if (aSubArbolDer == null)
                    aSubArbolDer = new CArbolBB(null, Elemento, null);
                else
                    aSubArbolDer.Agregar(Elemento);
            }
        }

        /* -------------------------------------------------------------- */
        public virtual void Eliminar(Object pRaiz)
        {
            if (EstaVacio())
                Console.WriteLine("ERROR. Elemento no encontrado...");
            else
            {
                // ----- Verificar si la raiz es el elemento que se desea eliminar
                if (pRaiz.Equals(aRaiz))
                {
                    // Si no tiene hijos, eliminar la raiz o una hoja
                    if ((aSubArbolIzq == null) && (aSubArbolDer == null))
                        aRaiz = null;
                    else // árbol tiene por lo menos un hijo  
                    if (aSubArbolIzq == null) // ----- Solo tiene hijo derecho        
                    {
                        aRaiz = aSubArbolDer.Raiz;
                        aSubArbolIzq = aSubArbolDer.SubArbolIzq;
                        aSubArbolDer = aSubArbolDer.SubArbolDer;
                    }
                    else
                        if (aSubArbolDer == null) // ----- Solo tiene hijo izquierdo        
                    {
                        aRaiz = aSubArbolIzq.Raiz;
                        aSubArbolDer = aSubArbolIzq.aSubArbolDer;
                        aSubArbolIzq = aSubArbolIzq.aSubArbolIzq;
                    }
                    else // Tiene ambos hijos
                    {
                        aRaiz = aSubArbolDer.Minimo();
                        aSubArbolDer.Eliminar(aRaiz);
                    }
                }
                else
                    // ----- Verificar si el elemento a eliminar esta en el hijo Izq
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                {
                    if (aSubArbolIzq != null)
                        aSubArbolIzq.Eliminar(pRaiz);
                }
                else
                        // ----- Elemento a eliminar esta en el hijo Der
                        if (aSubArbolDer != null)
                    aSubArbolDer.Eliminar(pRaiz);
                // Verificar si los hijos son hojas vacias
                if ((aSubArbolIzq != null) && aSubArbolIzq.EstaVacio())
                    aSubArbolIzq = null;
                if ((aSubArbolDer != null) && aSubArbolDer.EstaVacio())
                    aSubArbolDer = null;
            }
        }

        /* -------------------------------------------------------------- */
        public CArbolBB SubArbol(object pRaiz)
        {
            if (EstaVacio())
            {
                return null;
            }
            else
            {
                if (aRaiz.Equals(pRaiz))
                    return this;
                else
                {
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                    {
                        if (aSubArbolIzq != null)
                            return aSubArbolIzq.SubArbol(pRaiz);
                        else
                            return null;
                    }
                    else
                        return aSubArbolDer != null ? aSubArbolDer.SubArbol(pRaiz) : null;
                }
            }
        }
        /* -------------------------------------------------------------- */
        public CArbolBB Padre(object pRaiz)
        {
            if (EstaVacio())
                return null;
            else
                if (EsHijo(pRaiz))
                return this;
            else
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                return aSubArbolIzq != null ? aSubArbolIzq.Padre(pRaiz) : null;
            else
                return aSubArbolDer != null ? aSubArbolDer.Padre(pRaiz) : null;
        }

        /* -------------------------------------------------------------- */
        public bool EsHijo(object pRaiz)
        {
            return (((aSubArbolIzq != null) && (aSubArbolIzq.Raiz.Equals(pRaiz))) ||
                    ((aSubArbolDer != null) && (aSubArbolDer.Raiz.Equals(pRaiz))));
        }

        /* -------------------------------------------------------------- */
        public object Minimo()
        {
            if (EstaVacio())
                return null;
            else
                return SubArbolIzq == null ? aRaiz : aSubArbolIzq.Minimo();
        }

        /* -------------------------------------------------------------- */
        public object Maximo()
        {
            if (EstaVacio())
                return null;
            else
                return SubArbolDer == null ? aRaiz : aSubArbolDer.Maximo();
        }

        /* -------------------------------------------------------------- */
        public int Altura()
        {
            if (EstaVacio())
                return 0;
            else
            {
                int AlturaIzq = (aSubArbolIzq == null ? 0 : 1 + aSubArbolIzq.Altura());
                int AlturaDer = (aSubArbolDer == null ? 0 : 1 + aSubArbolDer.Altura());
                return (AlturaIzq > AlturaDer ? AlturaIzq : AlturaDer);
            }
        }

        /* -------------------------------------------------------------- */
        public void PreOrden()
        {
            if (aRaiz != null)
            {
                // ----- Procesar la raiz
                Console.WriteLine(aRaiz.ToString());
                // ----- Procesar hijo Izq
                if (aSubArbolIzq != null)
                    aSubArbolIzq.PreOrden();
                // ----- Procesar hijo Der
                if (aSubArbolDer != null)
                    aSubArbolDer.PreOrden();
            }
        }

        /* -------------------------------------------------------------- */
        public void InOrden()
        {
            if (aRaiz != null)
            {
                // ----- Procesar hijo Izq
                if (aSubArbolIzq != null)
                    aSubArbolIzq.InOrden();
                // ----- Procesar la raiz
                Console.WriteLine(aRaiz.ToString());
                // ----- Procesar hijo Der
                if (aSubArbolDer != null)
                    aSubArbolDer.InOrden();
            }
        }

        /* -------------------------------------------------------------- */
        public void PostOrden()
        {
            if (aRaiz != null)
            {
                // ----- Procesar hijo Izq
                if (aSubArbolIzq != null)
                    aSubArbolIzq.PostOrden();
                // ----- Procesar hijo Der
                if (aSubArbolDer != null)
                    aSubArbolDer.PostOrden();
                // ----- Procesar la raiz
                Console.WriteLine(aRaiz.ToString());
            }

        }
        #endregion Metodos
    }
}
