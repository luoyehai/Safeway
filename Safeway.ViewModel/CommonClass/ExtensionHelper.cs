using Safeway.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Safeway.ViewModel.CommonClass
{
    public static class ExtensionHelper
    {
        /// <summary>
        /// Datetime to string with format : yyyy-MM-dd
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToShortDateFormatString(this DateTime datetime)
        {
            return datetime.ToString(CommConstant.ShortDateFormatString);
        }

        /// <summary>
        /// Datetime to string with format : yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToDateTimeFormatString(this DateTime datetime)
        {
            return datetime.ToString(CommConstant.DateTimeFormatString);
        }

        public static string GetDescription(this Enum em)
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetField(em.ToString());
            if (fd == null)
                return string.Empty;
            object[] attrs = fd.GetCustomAttributes(typeof(DisplayAttribute), false);
            string name = string.Empty;
            foreach (DisplayAttribute attr in attrs)
            {
                name = attr.Name;
            }
            return name;
        }
    }
}
