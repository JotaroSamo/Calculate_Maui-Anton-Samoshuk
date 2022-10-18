using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Anton
{
    public static class Calculate
    {
        public static string DoCalculation(float val1, float val2, string operatorMath)// АРИФМЕТИЧЕСКИЕ ВЫРАЖЕНИЯ
        {
            string result = "0";
            switch (operatorMath)
            {
                case "/":
                        result = (val1 / val2).ToString();
                    break;
                case "-":
                    result = (val1 - val2).ToString();
                    break;
                case "*":
                    result = (val1 * val2).ToString();
                    break;
                case "+":
                    result = (val1 + val2).ToString();
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
