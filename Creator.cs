using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    #region Different LVL
    //public enum LVL
    //{
    //    SIMPLE,
    //    MEDIUM,
    //    HARD
    //}
    #endregion
    class Creator
    {
        #region Singleton
        static Creator Instance { get; set; }

        public static Creator GetInstance()
        {
            if (Instance != null)
            {
                return Instance;
            }
            Instance = new Creator();
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

        public Creator()
        {
            SeedRandom();
        }
        #region Main Creatore
        public int?[][] Create()
        {
            while (true)
            {
                try
                {
                    //DefineLVL(_lvl);
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

        #region LVL but it works incorrectly// Изначально планировал, чтобы в зависимости от уровня, судоку сразу заполнялся с нулями, 
                                             //но это приводило к ошибкам, решил сначала создавать, а потом уже вставлять 0
           
        //void DefineLVL(LVL _lvl)
        //{
        //    switch (_lvl)
        //    {
        //        case LVL.SIMPLE:
        //            Min = 5;
        //            Max = 6;
        //            break;
        //        case LVL.MEDIUM:
        //            Min = 4;
        //            Max = 5;
        //            break;
        //        case LVL.HARD:
        //            Min = 3;
        //            Max = 4;
        //            break;
        //    }
        //}
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
    }
}

