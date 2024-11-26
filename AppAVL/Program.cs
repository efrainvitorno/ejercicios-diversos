using System;

namespace AppAVL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Árboles balanceados");
            CArbolAVL b = new CArbolAVL();
            b.Agregar(1);
            b.Agregar(2);
            b.Agregar(3);
            b.Agregar(4);
            b.Agregar(5);
            b.Agregar(6);
            b.Agregar(7);
            b.Agregar(8);

            // Crear una instancia de CImprimirArbol
            CImprimirArbol imprimirArbol = new CImprimirArbol();

            // Imprimir el árbol
            Console.WriteLine("Árbol AVL:");
            imprimirArbol.Imprimir(b);

            // Imprimir el recorrido en posorden
            Console.WriteLine("Recorrido en posorden:");
            imprimirArbol.ImprimirPosorden(b);
            Console.WriteLine();

            // Calcular el número de nodos que son hojas
            int numeroNodosHojas = b.NumeroNodosHojas();
            Console.WriteLine($"Número de nodos que son hojas: {numeroNodosHojas}");

            // Determinar si un nodo es hoja (ejemplo con el nodo 4)
            bool esHoja = (b.SubArbol(4) as CArbolAVL)?.NodoEsHoja() ?? false;
            Console.WriteLine($"El nodo 4 es hoja: {esHoja}");

            // Determinar el número de nodos que tienen un hijo
            int numeroNodosUnHijo = b.NumeroDeNodosunHijo();
            Console.WriteLine($"Número de nodos que tienen un hijo: {numeroNodosUnHijo}");

            // Determinar el número de nodos que tienen dos hijos
            int numeroNodosDosHijos = b.NumeroDeNodosDosHijos();
            Console.WriteLine($"Número de nodos que tienen dos hijos: {numeroNodosDosHijos}");

            // Determinar la suma total de los elementos
            int sumaTotalElementos = b.SumaTotalElementos();
            Console.WriteLine($"Suma total de los elementos: {sumaTotalElementos}");

            // Calcular el promedio de los elementos
            double promedioElementos = b.CalcularPromedio();
            Console.WriteLine($"Promedio de los elementos: {promedioElementos}");

            Console.ReadKey();
        }

        // Método auxiliar para convertir CArbolAVL a NodoAVL

    }
}
