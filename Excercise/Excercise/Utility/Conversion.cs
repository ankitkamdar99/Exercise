using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Excercise.Utility
{
    public static class Conversion
    {
        public static string OneDigitCalculation(string Number)
        {
            int _Number = Convert.ToInt32(Number);
            string name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        public static string TwoDigitCalculation(string Number)
        {
            int num = Convert.ToInt32(Number);
            string word = null;
            switch (num)
            {
                case 10:
                    word = "Ten";
                    break;
                case 11:
                    word = "Eleven";
                    break;
                case 12:
                    word = "Twelve";
                    break;
                case 13:
                    word = "Thirteen";
                    break;
                case 14:
                    word = "Fourteen";
                    break;
                case 15:
                    word = "Fifteen";
                    break;
                case 16:
                    word = "Sixteen";
                    break;
                case 17:
                    word = "Seventeen";
                    break;
                case 18:
                    word = "Eighteen";
                    break;
                case 19:
                    word = "Nineteen";
                    break;
                case 20:
                    word = "Twenty";
                    break;
                case 30:
                    word = "Thirty";
                    break;
                case 40:
                    word = "Fourty";
                    break;
                case 50:
                    word = "Fifty";
                    break;
                case 60:
                    word = "Sixty";
                    break;
                case 70:
                    word = "Seventy";
                    break;
                case 80:
                    word = "Eighty";
                    break;
                case 90:
                    word = "Ninety";
                    break;
                default:
                    if (num > 0)
                    {
                        word = TwoDigitCalculation(Number.Substring(0, 1) + "0") + " " + OneDigitCalculation(Number.Substring(1));
                    }
                    break;
            }
            return word;
        }

        public static string ConvertToWords(string numb)
        {
            string val = "", number = numb, points = "", andStr = "", pointStr = "";
            string endStr = "";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    number = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        //To seprate dollar and cent values
                        andStr = "and";
                        //Postfix of the currency
                        endStr = "dollars " + endStr;//Cents  
                        pointStr = " " + points.ToString() + "/100";
                    }
                }
                val = string.Format("{0} {1}{2} {3}", ConvertNumberToWords(number).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }

        public static string ConvertNumberToWords(string Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                //Variable to use check Conversion is already done or not?
                bool isDone = false;
                double dblAmt = (Convert.ToDouble(Number));
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int digitPosition = 0;//store digit grouping
                    string place = "";//digit grouping name:hundres,thousand,etc...
                    switch (numDigits)
                    {
                        //Below case is use to check one digit calculation If amount is between 1...9 than it goes to case 1
                        case 1:
                            word = OneDigitCalculation(Number);
                            isDone = true;
                            break;
                        //Below case is use to check Two digit calculation If amount is between 10...99 than it goes to case 2
                        case 2:
                            word = TwoDigitCalculation(Number);
                            isDone = true;
                            break;
                        //Below case is use to check Three digit calculation If amount is between 100...999 than it goes to case 3
                        case 3:
                            digitPosition = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        //Below case is use to check Four,Five and Six digit calculation If amount is between 1000...999999 than it goes to case 6
                        case 4:
                        case 5:
                        case 6:
                            digitPosition = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        //Below case is use to check Million calculation If amount is between 1000000...999999999 than it goes to case 9
                        case 7:
                        case 8:
                        case 9:
                            digitPosition = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        //Below case is use to check Billion calculation If amount is between 1...9 than it goes to case 4,5,6
                        case 10:
                        case 11:
                        case 12:
                            digitPosition = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    //If Conversion is not done recursive is comes here
                    if (!isDone)
                    {
                        if (Number.Substring(0, digitPosition) != "0" && Number.Substring(digitPosition) != "0")
                        {
                            try
                            {
                                word = ConvertNumberToWords(Number.Substring(0, digitPosition)) + place + ConvertNumberToWords(Number.Substring(digitPosition));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertNumberToWords(Number.Substring(0, digitPosition)) + ConvertNumberToWords(Number.Substring(digitPosition));
                        }
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        
        
    }
}