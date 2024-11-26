using System;

namespace AppAVL
{
    public class CImprimirArbol
    {
        public void Imprimir(CArbolAVL arbol)
        {
            if (arbol == null || arbol.Raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            ImprimirRecursivo(arbol, 0);
        }

        private void ImprimirRecursivo(CArbolAVL arbol, int nivel)
        {
            if (arbol == null)
                return;

            ImprimirRecursivo(arbol.SubArbolDer as CArbolAVL, nivel + 1);
            Console.WriteLine(new string(' ', nivel * 4) + arbol.Raiz);
            ImprimirRecursivo(arbol.SubArbolIzq as CArbolAVL, nivel + 1);
        }

        public void ImprimirPosorden(CArbolAVL arbol)
        {
            if (arbol == null || arbol.Raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }
            ImprimirPosordenRecursivo(arbol);
        }

        private void ImprimirPosordenRecursivo(CArbolAVL arbol)
        {
            if (arbol == null)
                return;

            ImprimirPosordenRecursivo(arbol.SubArbolIzq as CArbolAVL);
            ImprimirPosordenRecursivo(arbol.SubArbolDer as CArbolAVL);
            Console.Write(arbol.Raiz + " ");
        }
    }
}
