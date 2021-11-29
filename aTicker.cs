using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    class aTicker
    {

        private string ticker;
        private string name;
        private string sector;

        public aTicker(string t, string n, string s)
        {
            ticker = t;
            name = n;
            sector = s;
        }

        public string getTicker()
        {
            return ticker;
        }

    }
}
