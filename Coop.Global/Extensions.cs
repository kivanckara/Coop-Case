using System;

namespace Coop.Global
{
    public static class Extensions
    {
        public static int ToInt32(this object value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(this object value)
        {
            try
            {
                return Convert.ToDouble(value);
            }
            catch
            {
                return 0;
            }
        }

        public static int KeepPositive(this int value)
        {
            return value >= 0 ? value : 0;
        }
    }
}