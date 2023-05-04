using cakcuulatorNew.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakcuulatorNew
{
    interface IModel
    {
        

        class CalculatorModel : ICalculatorModel
        {
            private double numFirst;
            private double numSecond;
            private double result;

            public double Num1
            {
                get => numFirst;
                set
                {
                    if (numFirst != value)
                    {
                        numFirst = value;
                    }
                }
            }

            public double Num2
            {
                get => numSecond;
                set
                {
                    if (numSecond != value)
                    {
                        numSecond = value;
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
}
