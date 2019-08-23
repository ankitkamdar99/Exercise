using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excercise.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Excercise.Pages
{
    public class NumberToWordModel : PageModel
    {
        public void OnGet()
        {
            Number = "";
            Words = "";
            Error = "";
        }

        public void OnPost()
        {
            Number = Request.Form[nameof(Number)];

            string currencyPattern = @"^[1-9]\d*(\.\d+)?$";
            bool isValidCurrency = Regex.IsMatch(Number, currencyPattern);
            if(!isValidCurrency)
            {
                Error = "Enter valid currency value.";
                Words = "";
                return;
            }

            var number = Convert.ToDouble(Number).ToString();
            var isNegative = "";
            var word = "";
            if (number.Contains("-"))
            {
                isNegative = "Minus ";
                number = number.Substring(1, number.Length - 1);
            }
            if (number == "0")
            {
                word = "The number in currency is Zero";
            }
            else
            {
                word = string.Format("The number in currency format is \n {0}", isNegative + Conversion.ConvertToWords(number));
            }
            Words = word;
        }

        [RegularExpression(@"^[1-9]\d*(\.\d+)?$", ErrorMessage = "Enter valid currency value.")]
        public string Number { get; set; }
        public string Words { get; set; }
        public string Error { get; set; }
    }
}
