using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYK_Project
{

    class Rule
    {
        public char S;
        private string Nt;

        public Rule(char s, string n)
        {
            S = s;
            Nt = n;
        }

        public bool Check(char c)
        {
            for (int i = 0; i < Nt.Length; i++)
                if (c == Nt[i])
                    return true;
            return false;
        }

        public bool Check(Rule X, Rule Y)
        {
            if (Nt[0] == X.S && Nt[1] == Y.S)
                return true;
            return false;
        }
    
}

}
