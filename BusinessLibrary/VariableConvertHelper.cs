
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLibrary
{
    public static class VariableConvertHelper
    {
        public static int ToInt(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToInt32(o.ToString().Replace("_", ""));
            }
            catch
            {
                return 0;
            }
        }

        public static double ToDouble(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToDouble(o);
            }
            catch
            {
                return 0;
            }
        }

        public static decimal ToDecimal(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? 0 : Convert.ToDecimal(o);
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? new DateTime(1900, 1, 1) : Convert.ToDateTime(o);
            }
            catch
            {
                return new DateTime(1900, 1, 1);
            }
        }

        public static DateTime ToDateTime(this object o, DateTime date)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? date : Convert.ToDateTime(o);
            }
            catch
            {
                return date;
            }
        }

        public static DateTime ToDateTime(this object o, string time)
        {
            try
            {
                if (o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()))
                {
                    return new DateTime(1900, 1, 1, 0, 0, 0);
                }
                else
                {
                    DateTime date = Convert.ToDateTime(o);
                    date = date.AddHours(time.Split(':')[0].ToDouble());
                    date = date.AddMinutes(time.Split(':')[1].ToDouble());
                    return Convert.ToDateTime(date);
                }
            }
            catch
            {
                return new DateTime(1900, 1, 1, 0, 0, 0);
            }
        }

        public static bool ToBool(this object o)
        {
            try
            {
                return o is DBNull || o == null || string.IsNullOrEmpty(o.ToString()) ? false : Convert.ToBoolean(o);
            }
            catch
            {
                return false;
            }
        }

        public static Guid ToGuid(this object o)
        {
            try
            {
                return o is DBNull || o == null ? Guid.Empty : Guid.Parse(o.ToString());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string ToMoney(this object o)
        {
            if (o == null) return "Yok.";
            double d = 0;

            if (double.TryParse(o.ToString().Replace(".", ","), out d))
            {
                string result = "";
                result = d.ToString("C", CultureInfo.CreateSpecificCulture("tr-TR"));
                return result.Substring(0, result.Length - 5);
            }
            else
            {
                return o.ToString();
            }

        }

 
    }
}
