using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class Date
    {
        public int dd;
        public int mm;
        public int yyyy;
        public Date(int dd, int mm, int yyyy) 
        {
            this.dd = dd;
            this.mm = mm;
            this.yyyy = yyyy;
        }
        public bool isCorrect()
        {
            if (yyyy < 1) return false;
            if (mm < 1) return false;
            if (mm > 12) return false;
            if (dd < 1) return false;
            if ((mm == 1 || mm == 3 || mm == 5 || mm == 7 || mm == 8 || mm == 10 || mm == 12) && (dd > 31)) return false;
            if ((mm == 4 || mm == 6 || mm == 9 || mm == 11 ) && (dd > 30)) return false;
            if ((mm == 2) && (dd > 29) && (yyyy % 4 == 0)) return false;
            if ((mm == 2) && (dd > 28) && (yyyy % 4 > 0)) return false;
            return true;
        }
    }
}
