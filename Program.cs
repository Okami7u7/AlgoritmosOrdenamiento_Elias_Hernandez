using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    // Lista donde se guardan todos los números ingresados
    static List<int> numeros = new List<int>();

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("==========================================");
            Console.WriteLine("       ALGORITMOS DE ORDENAMIENTO");
            Console.WriteLine("==========================================");
            Console.WriteLine("  1. Registrar números");
            Console.WriteLine("  2. Mostrar lista actual");
            Console.WriteLine("  3. Bubble Sort");
            Console.WriteLine("  4. Insertion Sort");
            Console.WriteLine("  5. Merge Sort");
            Console.WriteLine("  6. Salir");
            Console.WriteLine("==========================================");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("\nOpción no válida.");
                Pausa();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarNumeros();
                    break;

                case 2:
                    MostrarLista();
                    break;

                case 3:
                    EjecutarBubbleSort();
                    break;

                case 4:
                    EjecutarInsertionSort();
                    break;

                case 5:
                    EjecutarMergeSort();
                    break;

                case 6:
                    Console.WriteLine("\nPrograma finalizado.");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida.");
                    Pausa();
                    break;
            }

        } while (opcion != 6);
    }


    // ==========================================
    // REGISTRAR NÚMEROS
    // ==========================================

    static void RegistrarNumeros()
    {
        Console.Clear();

        Console.WriteLine("========== REGISTRAR NÚMEROS ==========");
        Console.WriteLine("Puedes ingresar positivos y negativos.");
        Console.WriteLine("Escribe FIN cuando termines.\n");

        while (true)
        {
            Console.Write("Número: ");
            string entrada = Console.ReadLine();

            if (entrada.ToUpper() == "FIN")
                break;

            if (int.TryParse(entrada, out int numero))
            {
                numeros.Add(numero);
                Console.WriteLine("Agregado correctamente.\n");
            }
            else
            {
                Console.WriteLine("Ese valor no es un número válido.\n");
            }
        }

        Console.WriteLine("\nNúmeros guardados: " + numeros.Count);
        Pausa();
    }


    // ==========================================
    // MOSTRAR LISTA
    // ==========================================

    static void MostrarLista()
    {
        Console.Clear();

        Console.WriteLine("========== LISTA ACTUAL ==========\n");

        if (numeros.Count == 0)
        {
            Console.WriteLine("Todavía no hay números registrados.");
        }
        else
        {
            MostrarArreglo(numeros);
        }

        Pausa();
    }


    // ==========================================
    // BUBBLE SORT
    // ==========================================

    static void EjecutarBubbleSort()
    {
        Console.Clear();

        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números para ordenar.");
            Pausa();
            return;
        }

        List<int> copia = new List<int>(numeros);

        Console.WriteLine("========== BUBBLE SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(copia);

        Console.WriteLine("\nIniciando ordenamiento...");
        Thread.Sleep(700);

        int pasos = 0;

        // Contamos los pasos aproximados para la barra
        int totalPasos = (copia.Count * (copia.Count - 1)) / 2;

        if (totalPasos == 0)
            totalPasos = 1;

        for (int i = 0; i < copia.Count - 1; i++)
        {
            for (int j = 0; j < copia.Count - i - 1; j++)
            {
                pasos++;

                Console.Clear();

                Console.WriteLine("========== BUBBLE SORT ==========\n");

                Console.WriteLine("Paso " + pasos + " de " + totalPasos);
                Console.WriteLine("Comparando: " + copia[j] + " con " + copia[j + 1]);

                if (copia[j] > copia[j + 1])
                {
                    int temporal = copia[j];
                    copia[j] = copia[j + 1];
                    copia[j + 1] = temporal;

                    Console.WriteLine("\nSe realiza un cambio.");
                }
                else
                {
                    Console.WriteLine("\nNo es necesario cambiar.");
                }

                Console.Write("\nEstado actual: ");
                MostrarArreglo(copia);

                MostrarBarra(pasos, totalPasos);

                Thread.Sleep(450);
            }
        }

        Console.Clear();

        Console.WriteLine("========== BUBBLE SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(numeros);

        Console.Write("\nLista ordenada: ");
        MostrarArreglo(copia);

        Console.WriteLine("\nOrdenamiento terminado.");

        MostrarBarra(totalPasos, totalPasos);

        Pausa();
    }


    // ==========================================
    // INSERTION SORT
    // ==========================================

    static void EjecutarInsertionSort()
    {
        Console.Clear();

        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números para ordenar.");
            Pausa();
            return;
        }

        List<int> copia = new List<int>(numeros);

        Console.WriteLine("========== INSERTION SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(copia);

        Thread.Sleep(700);

        int totalPasos = copia.Count - 1;

        if (totalPasos == 0)
            totalPasos = 1;

        int paso = 0;

        for (int i = 1; i < copia.Count; i++)
        {
            paso++;

            int actual = copia[i];
            int j = i - 1;

            Console.Clear();

            Console.WriteLine("========== INSERTION SORT ==========\n");

            Console.WriteLine("Paso " + paso + " de " + totalPasos);
            Console.WriteLine("Número que se está colocando: " + actual);

            while (j >= 0 && copia[j] > actual)
            {
                copia[j + 1] = copia[j];
                j--;
            }

            copia[j + 1] = actual;

            Console.WriteLine("\nEstado actual:");
            MostrarArreglo(copia);

            MostrarBarra(paso, totalPasos);

            Thread.Sleep(600);
        }

        Console.Clear();

        Console.WriteLine("========== INSERTION SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(numeros);

        Console.Write("\nLista ordenada: ");
        MostrarArreglo(copia);

        Console.WriteLine("\nOrdenamiento terminado.");

        MostrarBarra(totalPasos, totalPasos);

        Pausa();
    }


    // ==========================================
    // MERGE SORT
    // ==========================================

    static void EjecutarMergeSort()
    {
        Console.Clear();

        if (numeros.Count == 0)
        {
            Console.WriteLine("No hay números para ordenar.");
            Pausa();
            return;
        }

        List<int> copia = new List<int>(numeros);

        Console.WriteLine("========== MERGE SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(copia);

        Console.WriteLine("\nDividiendo y ordenando...");
        Thread.Sleep(800);

        MergeSort(copia, 0, copia.Count - 1);

        Console.Clear();

        Console.WriteLine("========== MERGE SORT ==========\n");

        Console.Write("Lista original: ");
        MostrarArreglo(numeros);

        Console.Write("\nLista ordenada: ");
        MostrarArreglo(copia);

        Console.WriteLine("\nOrdenamiento terminado.");

        MostrarBarra(1, 1);

        Pausa();
    }


    // ==========================================
    // MÉTODO PRINCIPAL DE MERGE SORT
    // ==========================================

    static void MergeSort(List<int> lista, int izquierda, int derecha)
    {
        if (izquierda >= derecha)
            return;

        int medio = (izquierda + derecha) / 2;

        // Se divide la lista en dos partes
        MergeSort(lista, izquierda, medio);
        MergeSort(lista, medio + 1, derecha);

        // Se unen las partes ordenadas
        Mezclar(lista, izquierda, medio, derecha);
    }


    // ==========================================
    // MEZCLA DE MERGE SORT
    // ==========================================

    static void Mezclar(List<int> lista, int izquierda, int medio, int derecha)
    {
        List<int> temporal = new List<int>();

        int i = izquierda;
        int j = medio + 1;

        while (i <= medio && j <= derecha)
        {
            if (lista[i] <= lista[j])
            {
                temporal.Add(lista[i]);
                i++;
            }
            else
            {
                temporal.Add(lista[j]);
                j++;
            }
        }

        while (i <= medio)
        {
            temporal.Add(lista[i]);
            i++;
        }

        while (j <= derecha)
        {
            temporal.Add(lista[j]);
            j++;
        }

        for (int k = 0; k < temporal.Count; k++)
        {
            lista[izquierda + k] = temporal[k];
        }

        // Mostrar el proceso de Merge Sort
        Console.Clear();

        Console.WriteLine("========== MERGE SORT ==========\n");

        Console.WriteLine(
            "Uniendo posiciones " +
            izquierda +
            " hasta " +
            derecha
        );

        Console.Write("\nEstado actual: ");
        MostrarArreglo(lista);

        MostrarBarra(derecha + 1, lista.Count);

        Thread.Sleep(700);
    }


    // ==========================================
    // MOSTRAR BARRA DE PROGRESO
    // ==========================================

    static void MostrarBarra(int actual, int total)
    {
        int largo = 20;

        double porcentaje = (double)actual / total;

        if (porcentaje > 1)
            porcentaje = 1;

        int llenos = (int)(porcentaje * largo);

        Console.Write("\n[ ");

        for (int i = 0; i < largo; i++)
        {
            if (i < llenos)
                Console.Write("=");
            else
                Console.Write(".");
        }

        Console.WriteLine(
            " ] " +
            (porcentaje * 100).ToString("0") +
            "%"
        );
    }


    // ==========================================
    // MOSTRAR UNA LISTA
    // ==========================================

    static void MostrarArreglo(List<int> lista)
    {
        Console.Write("[ ");

        for (int i = 0; i < lista.Count; i++)
        {
            Console.Write(lista[i]);

            if (i < lista.Count - 1)
                Console.Write(", ");
        }

        Console.WriteLine(" ]");
    }


    // ==========================================
    // PAUSA PARA REGRESAR AL MENÚ
    // ==========================================

    static void Pausa()
    {
        Console.WriteLine("\nPresione ENTER para regresar al menú...");
        Console.ReadLine();
    }
}