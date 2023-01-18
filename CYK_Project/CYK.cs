using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYK_Project
{
    class CYK
    {
        List<Rule> G;
        string Word;
        char StartSymbol;
        bool[,,] T;
        bool result;
        int n, r;

        public CYK(string w, List<Rule> g, char s = 'S')
        {
            Word = w;
            n = Word.Length;
            G = g;
            r = G.Count;
            StartSymbol = s;
            T = new bool[n, n, r];
        }

        public void Parse()
        {
            int i, j, k, x, y, Z;

            InitTable();

            for (i = 1; i < n; i++)
                for (j = 0; j < n - i; j++)
                    for (k = 0; k < i; k++)
                        for (x = 0; x < r; x++)
                            for (y = 0; y < r; y++)
                                if (T[j, k, x] && T[j + k + 1, i - k - 1, y])
                                    for (Z = 0; Z < r; Z++)
                                        if (G[Z].Check(G[x], G[y]))
                                            T[j, i, Z] = true;

            SetResult();
        }

        public void PrintTable()
        {
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write('|');

                    for (int z = 0; z < r; z++)
                    {
                        if (T[j, i, z])
                            Console.Write(G[z].S);
                        else
                            Console.Write(' ');
                    }
                    if (j == n - 1)
                        Console.Write('|');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private void SetResult()
        {
            for (int i = 0; i < r; i++)
                if (T[0, n - 1, i] && G[i].S == StartSymbol)
                {
                    result = true;
                    break;
                }

        }

        public bool GetResult()
        {
            return result;
        }

        private void InitTable()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < r; j++)
                    if (G[j].Check(Word[i]))
                        T[i, 0, j] = true;
        }

    }
}
