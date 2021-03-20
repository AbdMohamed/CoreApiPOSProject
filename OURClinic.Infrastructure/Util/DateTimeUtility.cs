using System;
using System.Collections.Generic;
using System.Text;

namespace OURCart.Infrastructure.Util
{
    public static class DateTimeUtility
    {
        //convert to datetime from yyyyMMdd
        public static DateTime GetDateTimeFromFormat(string dateTime, string format)
        {

            try
            {
                var result = DateTime.ParseExact(dateTime, format, null);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Date is not in the exact Format");
            }
        }
        //convert datetime to yyyyMMdd
        public static string getFormatFromDateTime(DateTime dateTime, string format = "yyyyMMdd")
        {

            try
            {
                var result = dateTime.ToString(format);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("not Valid Format");
            }
        }
    }
}
