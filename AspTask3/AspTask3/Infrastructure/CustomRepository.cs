using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspTask3.Infrastructure
{
    public static class CustomRepository
    {
        private static string[] side = new string[] {"white", "black" };
        private static int _current;

        public static string GetSide()
        {
            return side[_current];
        }

        public static void SetSide(int count)
        {
            _current = count;
        }

        public static void ChangeSideToBlack()
        {
            _current = 1;
        }
    }
}