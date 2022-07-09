using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator.Model
{
    public class SimpleMath
    {
        public static double Add(double numberOne, double numberTwo)
        {
            return numberOne + numberTwo;
        }
        public static double Subtract(double numberOne, double numberTwo)
        {
            return numberOne - numberTwo;
        }
        public static double Multiply(double numberOne, double numberTwo)
        {
            return numberOne * numberTwo;
        }
        public static double Divide(double numberOne, double numberTwo)
        {
            if (numberTwo == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return numberOne / numberTwo;
        }
    }
}
