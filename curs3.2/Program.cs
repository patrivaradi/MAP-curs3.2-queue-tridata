using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curs3._2
{
    class Program
    {
        static int[,] load(string fileName)
        {
            int lines;
            int columns;

            string buffer;
            List<string> data = new List<string>();

            System.IO.TextReader dataLoad = new System.IO.StreamReader(fileName);
            while ((buffer = dataLoad.ReadLine()) != null)
                data.Add(buffer);
            dataLoad.Close();
            lines = data.Count();
            columns = (data[0].Split(' ')).Length;

            int[,] toReturn = new int[lines, columns];
            for (int i = 0; i < lines; i++)
            {
                string[] values = data[i].Split(' ');
                for (int j = 0; j < columns; j++)
                {
                    toReturn[i, j] = int.Parse(values[j]);
                }
            }
            return toReturn;

        }
        static void view(int[,] toView)
        {
            int lines = toView.GetLength(0);
            int columns = toView.GetLength(1);
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {  /* if (toView[i, j] < 0)
                        Console.Write("[] ");
                    else
                        Console.Write(toView[i, j].ToString("00") + " ");*/
                    Console.Write(toView[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        
        static void Lee()
        {
            int[,] a = load(@"..\..\dataIN.txt");
            Queue A = new Queue();
            A.Push(new triData(0, 0, 1));
            a[0, 0] = 1;
            while(!A.isEmpty())
            {
                triData local = A.Pop();
                if (local.l - 1 >= 0)
                    if (a[local.l - 1, local.c] == 0)
                    {
                        a[local.l - 1, local.c] = local.v + 1;
                        A.Push(new triData(local.l - 1, local.c, local.v + 1));
                    }
                if (local.c + 1 < a.GetLength(1))
                    if (a[local.l, local.c+1] == 0)
                    {
                        a[local.l, local.c+1] = local.v + 1;
                        A.Push(new triData(local.l, local.c+1, local.v+1));
                    }
                if (local.l + 1 < a.GetLength(0))
                    if (a[local.l+1, local.c] == 0)
                    {
                        a[local.l+1, local.c ] = local.v + 1;
                        A.Push(new triData(local.l+1, local.c , local.v + 1));
                    }
                if (local.c - 1 >= 0)
                    if (a[local.l, local.c - 1] == 0)
                    {
                        a[local.l, local.c - 1] = local.v + 1;
                        A.Push(new triData(local.l, local.c - 1, local.v + 1));
                    }
                
            }
            view(a);
        }

        static void Main(string[] args)
        {
            Lee();
            //int[,] a = load(@"..\..\dataIn.txt");
           // view(a);
            Console.ReadKey();
        }


    }
}
