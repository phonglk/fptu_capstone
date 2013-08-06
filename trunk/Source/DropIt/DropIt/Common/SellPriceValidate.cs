using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropIt.Common
{
    public class SellPriceValidate
    {
        public static ValidationResult RangeSellPrice(double value)
        {
            double Min = Double.Parse(Settings.get("MinSellPrice"));
            double Max = Double.Parse(Settings.get("MaxSellPrice"));
            if (value <= Min)
            {
                return new ValidationResult("Giá tiền vé tối thiểu từ " + Min + " đồng");
            }
            if (value >= Max)
            {
                return new ValidationResult("Giá tiền vé tối đa từ " + Max + " đồng");
            }
            return ValidationResult.Success;
        }
    }
}