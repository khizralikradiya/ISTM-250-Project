using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingProject1._0
{
    public static class Validator
    {

        public static string IsPresent(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage += strControlName + " is a required field.\n";
            }
            return strMessage;
        }


        public static string IsInteger(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (!Int32.TryParse(strTestValue, out _))
            {
                strMessage += strControlName + " must be a valid integer value.\n";
            }
            return strMessage;
        }

        public static string IsDecimal(string strTestValue, string strControlName)
        {
            string strMessage = "";
            if (!Decimal.TryParse(strTestValue, out _))
            {
                strMessage += strControlName + " must be a valid decimal value.\n";
            }
            return strMessage;
        }

        public static string IsWithinRange(string strTestValue, string strControlName, decimal decMin, decimal decMax)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber < decMin || decTestNumber > decMax)
            {
                strMessage += strControlName + " must be between " + decMin + " and " + decMax + ".\n";
            }
            return strMessage;
        }

        public static string IsGreaterThan(string strTestValue, string strControlName, decimal decMin)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber <= decMin)
            {
                strMessage += strControlName + " must be greater than " + decMin + ".\n";
            }
            return strMessage;
        }

        public static string IsLessThan(string strTestValue, string strControlName, decimal decMax)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber >= decMax || decTestNumber > decMax)
            {
                strMessage += strControlName + " must be less than " + decMax + ".\n";
            }
            return strMessage;
        }

        public static string IsWithinDeliveryRange(string strTestValueCity, string strTestValueState)
        {
            string strMessage = "";

            strTestValueCity = strTestValueCity.ToLower();
            strTestValueState = strTestValueState.ToLower();

            if ((strTestValueCity == "bryan" || strTestValueCity == "college station") &&
                (strTestValueState == "tx" || strTestValueState == "texas"))
            {
                return strMessage;
            }

            strMessage = "Delivery location is out of range. Please enter a location in either Bryan or College Station, Texas. \n";
            return strMessage;
        }


    }
}
