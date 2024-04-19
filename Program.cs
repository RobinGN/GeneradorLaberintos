using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

internal class Program
{
    private static void Main(string[] args)
    {
        int x = 15;
        int y = 10;
        GeneradordeLaberinto(x, y);
        Console.WriteLine("Hello people from youtube"); //el jorge es un presumido saquenlo del server por favor //fue culpa del robot
    }

    public static void GeneradordeLaberinto(int x, int y)
    {
        int size = x * y;
        int entrance = 0;
        int exit = size - 1;
        int cell1 = 0;
        int cell2 = 0;
        int s = 0;
        int[] parent = new int[size];
        int[] temp = new int[4];
        Random rnd = new Random();

        for (int i = 0; i < size; i++)
        {
            parent[i] = i;
        }

        // Crear un arreglo para representar las paredes.
        bool[,] walls = new bool[x * 2 - 1, y * 2 - 1];

        // Inicializar todas las paredes como existentes.
        for (int i = 0; i < x * 2 - 1; i++)
        {
            for (int j = 0; j < y * 2 - 1; j++)
            {
                walls[i, j] = true;
            }
        }

        while (find(parent, entrance) != find(parent, exit))
        {
            cell1 = rnd.Next(0, size - 1);  //posicion aleatoria del arreglo
            temp = new int[] { cell1 + 1, cell1 - 1, cell1 - x, cell1 + x };

            while (true)
            {
                s = rnd.Next(0, 3);
                cell2 = temp[s];


                if (s == 2 || s == 3)
                {
                    if (cell2 >= 0 && cell2 < size)
                        break;
                }
                else if (s == 0)
                {
                    if ((cell2 % x != 0) && (cell2 >= 0 && cell2 < size))
                        break;
                }
                else
                {
                    if (((cell2 + 1) % x != 0) && (cell2 >= 0 && cell2 < size))
                        break;
                }
            }

            if (find(parent, cell1) != find(parent, cell2)) //el robin es una negraaaaa exoticaa negra exoticaaaa
            {
                union(parent, cell1, cell2);

                // Eliminar la pared entre cell1 y cell2.
                int wallX = cell1 % x + cell2 % x;
                int wallY = cell1 / x + cell2 / x;
                walls[wallX, wallY] = false;
            }
        }

        // Imprimir el laberinto.
        for (int i = 0; i < x * 2 - 1; i++)
        {
            for (int j = 0; j < y * 2 - 1; j++)
            {
                Console.Write(walls[i, j] ? "#" : " ");
            }
            Console.WriteLine();
        }
    }

    public static int find(int[] parent, int i)  //se tiene que arreglar
    {
        if (parent[i] == i || parent[i] == -1)
            return i;
        return find(parent, parent[i]);
    }

    public static void union(int[] parent, int x, int y)
    {
        parent[find(parent, x)] = find(parent, y); //robin champs
    }
}
