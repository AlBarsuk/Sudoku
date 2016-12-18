using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySudoku
{
    class Generator
    {


        #region Singleton
        static Generator Instance { get; set; }

        public static Generator GetInstance()
        {
            if (Instance != null)
            {
                return Instance;
            }
            Instance = new Generator();
            return Instance;
        }
        #endregion

        #region Properties
        int Min { get; set; }
        int Max { get; set; }

        public int?[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public int?[][] mass { get; set; }
        #endregion

        #region Random
        public static Random r { get; set; }

        static void SeedRandom()
        {
            r = new Random();
        }
        #endregion

        public Generator()
        {
            SeedRandom();
        }
        #region Main Creator
        public int?[][] Create()
        {
            while (true)
            {
                try
                {
                    mass = new int?[9][];

                    for (int i = 0; i < mass.Length; i++)
                    {
                        mass[i] = new int?[9];
                    }

                    for (int i = 0; i < mass.Length; i += 3)
                    {
                        for (int j = 0; j < mass[i].Length; j += 3)
                        {
                            List<int> test = new List<int>();
                            var amount = r.Next(Min, Max + 1);
                            for (int c = 0; c < 9; c++)
                            {
                                int el = 0;
                                do
                                {
                                    el = r.Next(0, 9);
                                }
                                while (test.Contains(el));
                                test.Add(el);

                                var elX = el / 3;
                                var elY = el % 3;

                                var ins = getInCube(i, j);
                                var hor = mass[i + elX].Where(s => s != null).ToList();
                                var vert = getVert(j + elY);

                                var merged = ins.Concat(vert).Concat(hor).ToArray().Distinct().ToArray();
                                var can = numbers.Except(merged).ToArray();
                                mass[i + elX][j + elY] = can[r.Next(0, can.Length)];
                            }
                        }
                    }
                    for (int i = 0; i < mass.Length; i++)
                    {
                        for (int j = 0; j < mass[i].Length; j++)
                        {
                            if (mass[i][j] == null)
                            {
                                mass[i][j] = 0;
                            }
                        }
                    }
                    return mass;
                }
                catch { }
            }
        }
        #endregion



        #region Add to list 
        List<int?> getVert(int y)
        {
            List<int?> res = new List<int?>();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i][y] != null)
                {
                    res.Add(mass[i][y]);
                }
            }

            return res.ToList();
        }
        #endregion

        #region Chek 3 to 3 
        List<int?> getInCube(int x, int y)
        {
            List<int?> res = new List<int?>();
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    if (mass[i][j] != null)
                    {
                        res.Add(mass[i][j]);
                    }
                }
            }
            return res.ToList();
        }
        #endregion


        public void Medium(int?[][] l)
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
        }
        public void Easy(int?[][] l)
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

                }
            }
        }

        public void Hard(int?[][] l)
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
