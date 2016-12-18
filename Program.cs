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
            //int?[][] mass = null;
            mass = c.Create();
            var l = mass;
            level(l);
            //level1(l);
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

        public static void level(int?[][] l)
        {
            for (int i = 0; i < l.Length; i=i+2)
            {
                
                for (int j = 0; j < l[i].Length; j=j+2)
                {
                    if (i == 1 || i == 4)
                    {
                        l[i][j] = 0;
                    }
                    if (j == 1 || j==3)
                    {
                        l[i][j] = 0;
                    }
                    l[i][j] = 0; 
                }
            }
        }
        public static void level1(int?[][] l)
        {
            for (int i = 0; i < l.Length; i = i + 3)
            {
                for (int j = 0; j < l[i].Length; j = j + 2)
                {
                    l[i][j] = 0;
                }
            }
        }
    }
}
