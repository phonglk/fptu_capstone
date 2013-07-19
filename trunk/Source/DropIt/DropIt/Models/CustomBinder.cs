using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropIt.Models
{
    public class DateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            //var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
            String dateString = HttpUtility.UrlDecode((String)value.ConvertTo(typeof(String)));

            while (dateString.IndexOf("  ") > -1)
            {
                dateString = dateString.Replace("  ", " ");
            }

            dateString = dateString.Trim() + ":00";

            string[] dateElement = dateString.Split('/', ':', ' ','-','T');


            DateTime date = DateTime.Now;
            if (dateString.IndexOf('T') > -1)
            {
                date = new DateTime(Int32.Parse(dateElement[0]), Int32.Parse(dateElement[1]), Int32.Parse(dateElement[2]),
                Int32.Parse(dateElement[3]), Int32.Parse(dateElement[4]), Int32.Parse(dateElement[5]));
            }else{
                date = new DateTime(Int32.Parse(dateElement[2]), Int32.Parse(dateElement[1]), Int32.Parse(dateElement[0]),
                Int32.Parse(dateElement[3]), Int32.Parse(dateElement[4]), Int32.Parse(dateElement[5]));
            }
            return date;
        }
    }
    public class NullableDateTimeBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            //var date = value.ConvertTo(typeof(DateTime), CultureInfo.CurrentCulture);
            String dateString = HttpUtility.UrlDecode((String)value.ConvertTo(typeof(String)));

            while (dateString.IndexOf("  ") > -1)
            {
                dateString = dateString.Replace("  ", " ");
            }

            dateString = dateString.Trim() + ":00";

            string[] dateElement = dateString.Split('/', ':', ' ', '-', 'T');
            if (dateElement.Length == 5)
            {
                
            }
            DateTime date = DateTime.Now;
            if (dateString.IndexOf('T') > -1)
            {
                date = new DateTime(Int32.Parse(dateElement[0]), Int32.Parse(dateElement[1]), Int32.Parse(dateElement[2]),
                Int32.Parse(dateElement[3]), Int32.Parse(dateElement[4]), Int32.Parse(dateElement[5]));
            }
            else
            {
                date = new DateTime(Int32.Parse(dateElement[2]), Int32.Parse(dateElement[1]), Int32.Parse(dateElement[0]),
                Int32.Parse(dateElement[3]), Int32.Parse(dateElement[4]), Int32.Parse(dateElement[5]));
            }
            return date;
        }
    }
}