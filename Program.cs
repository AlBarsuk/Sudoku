using System;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        public static int?[][] mass { get; set; }
        public static Random r { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
            Creator c = Creator.GetInstance();
            //DifferentLevels DL = new DifferentLevels();
            //int?[][] mass = null;
            mass = c.Create();
            var m = mass;
            var l = mass;
            for (int i = 0; i < mass.Length; i++)
            {
                for (int j = 0; j < mass[i].Length; j++)
                {
                    if (j == 3 || j == 6)
                    {
                        Console.Write(" || ");
                    }
                    Console.Write(mass[i][j] + " ");
                }
                if (i == 2 || i == 5)
                {
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //level_medium(l);
            //level_easy(l);
            //level1(l);
            
            level_hard(l);
            //var t = p.level1(l);
            for (int i = 0; i < l.Length; i++)
            {
                for (int j = 0; j < l[i].Length; j++)
                {
                    if (j == 3 || j == 6)
                    {
                         Console.Write(" || ");
                    }
                     Console.Write(mass[i][j] + " ");
                }
                if (i == 2 || i == 5)
                {
                     Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        public static void level_medium(int?[][] l)
        {
            for (int i = 0; i < l.Length; i++)
            {

                for (int j = 0; j < l[i].Length; j++)
                {
                    if (i == 1 || i == 4)
                    {
                        l[i][j] = 0;
                    }
                    if (j == 1 || j == 3)
                    {
                        l[i][j] = 0;
                    }

                }
            }
            //return Level_mass;
        }
        public static void level_easy(int?[][] l)
        {
            for (int i = 0; i < l.Length; i++)
            {
                for (int j = 0; j < l[i].Length; j = j + 2)
                {
                    if (i == 2 || i == 4)
                    {
                        l[i][j] = 0;
                    }

                    if (j == 4 || j == 8)
                    {
                        l[i][j] = 0;
                    }
                    //l[i][j] = 0;
                }
            }
        }


        public static void level_hard(int?[][] l)
        {
            for (int i = 0; i < l.Length; i++)
            {
                for (int j = 0; j < l[i].Length; j++)
                {
                    if (i == 1)
                    {
                        l[i][j] = 0;
                    }
                    if (i == 5 || i == 7)
                    {
                        l[i][j] = 0;
                    }

                    if (j == 1 || j == 8)
                    {
                        l[i][j] = 0;
                    }
                    if (j == 5)
                    {
                        l[i][j] = 0;
                    }
                    //l[i][j] = 0;
                }
            }
        }

    }
}
