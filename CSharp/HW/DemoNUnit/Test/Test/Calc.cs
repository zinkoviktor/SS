using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Calc
    {
        private double num1;
        private double num2;
        public Calc() { num1 = 0; num2 = 0; }
        
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        public double Sub(double num1, double num2)
        {
            return num1 - num2;
        }
        public double Mul(double num1, double num2)
        {
            return num1 * num2;
        }
        public double Div(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            return num1 / num2;
        }
    }
}
