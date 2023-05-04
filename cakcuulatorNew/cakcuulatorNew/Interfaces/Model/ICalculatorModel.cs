﻿using System;
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
}
