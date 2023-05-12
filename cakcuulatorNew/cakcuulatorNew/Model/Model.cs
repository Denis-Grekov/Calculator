using cakcuulatorNew.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakcuulatorNew.Model
{
    class CalculatorModel : ICalculatorModel
    {
        private double? numFirst = null;
        private double? numSecond = null;
        private double? result = null;

        public double? NumFirst
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

        public double? NumSecond
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

        public double? Result
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
            Result = NumFirst + NumSecond;
        }

        public void Subtract()
        {
            Result = NumFirst - NumSecond;
        }

        public void Multiply()
        {
            Result = NumFirst * NumSecond;
        }

        public void Divide()
        {
            if (NumSecond != 0)
            {
                Result = NumFirst / NumSecond;
            }
            else
            {
                throw new DivideByZeroException("На ноль делить нельзя");
            }
        }
    }
}
