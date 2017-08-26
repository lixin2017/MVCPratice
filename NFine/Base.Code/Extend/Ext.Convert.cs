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

        #region 日期转换
        //转换为日期
        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }

        //转换为可空日期
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        #endregion 日期转换

        #region 布尔转换
        //转换为布尔值
        public static bool ToBool(this object data)
        {
            if (data == null)
                return false;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            return bool.TryParse(data.ToString(), out result) && result;
        }

        //获取布尔值
        private static bool? GetBool(this object data)
        {
            switch (data.ToString().Trim().ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "否":
                    return false;
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    return null;
            }
        }

        //转化为可空布尔值
        public static bool? ToBoolOrNull(this object data)
        {
            if (data == null)
                return null;
            bool? value = GetBool(data);
            if (value != null)
                return value.Value;
            bool result;
            bool IsValid= bool.TryParse(data.ToString(),out result);
            if (IsValid)
                return result;
            return null;
        }

        #endregion 布尔转换

        #region 字符串转换

        public static string ToString(this object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }

        #endregion 字符串转换

        //安全返回值
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }

        //是否为空
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmpty(this Guid? value)
        {
            if (value == null)
                return true;
            return IsEmpty(value.Value);
        }

        public static bool IsEmpty(this Guid value)
        {
            if (value == Guid.Empty)
                return true;
            return false;
        }

        public static bool IsEmpty(this object value)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
