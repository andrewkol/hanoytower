using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp20
{
    public static class Util
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next(1, 255);
        }
    }
}
