using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakcuulatorNew.Interfaces
{
    interface ICalculatorModel
    {
        double Num1 { get; set; }
        double Num2 { get; set; }
        double Result { get; set; }
        void Add();
        void Subtract();
        void Multiply();
        void Divide();
    }

    class CalculatorModel : ICalculatorModel
    {
        private double num1;
        private double num2;
        private double result;

        public double Num1
        {
            get => num1;
            set
            {
                if (num1 != value)
                {
                    num1 = value;
                }
            }
        }

        public double Num2
        {
            get => num2;
            set
            {
                if (num2 != value)
                {
                    num2 = value;
                }
            }
        }

        public double Result
        {
            get => result;
            set
            {
                if (result != value)
                {
                    result = value;
                }
            }
        }


        public void Add()
        {
            Result = Num1 + Num2;
        }

        public void Subtract()
        {
            Result = Num1 - Num2;
        }

        public void Multiply()
        {
            Result = Num1 * Num2;
        }

        public void Divide()
        {
            if (Num2 != 0)
            {
                Result = Num1 / Num2;
            }
            else
            {
                throw new DivideByZeroException("На ноль делить нельзя");
            }
        }
    }
}
