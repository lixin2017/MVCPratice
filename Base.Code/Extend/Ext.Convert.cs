using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Code
{
    public static partial class Ext
    {
        #region 数值转换
        //转换位整形
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data,0));
            }
            catch(Exception)
            {
                return 0;
            }
        }

        //转换为可空整形
        public static int? ToIntOrNull(this object data)
        {
            if(data==null)
                return null;
            int result;
            bool IsValid=int.TryParse(data.ToString(),out result);
            if(IsValid)
                return result;
            return null;
        }

        //转换为双精度浮点数
        public static double ToDouble(this object data)
        {
            if(data==null)
                return 0;
            double result;
            return double.TryParse(data.ToString(),out result)?result:0;
        }

        //转换双精度浮点数，并按指定的小数位四舍五入
        public static double ToDouble(this object data,int digits)
        {
            return Math.Round(ToDouble(data),digits);
        }

        //转换为可空双精度浮点数
        public static double? ToDoubleOrNull(this object data)
        {
            if(data==null)
                return null;
            double result;
            bool IsValid=double.TryParse(data.ToString(),out result);
            if(IsValid)
                return result;
            return null;
        }

        //转换为高精度浮点数
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        public static decimal ToDecimal(this  object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        // 转换为可空高精度浮点数
        public static decimal? ToDecimalOrNull(this  object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }
      
        // 转换为可空高精度浮点数,并按指定的小数位4舍5入      
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }

        #endregion 数值转换


    }
}
