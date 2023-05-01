using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cakcuulatorNew.Interfaces
{
    interface ICar
    {
        string Brand { get; }
        double HorsePower { get;  }
        int YearOfRealese { get; }

        int MaxSpeed();

        

        
    }

    class BMW : ICar
    {
        public string Brand => "BMW";

        public double HorsePower => 200;

        public int YearOfRealese => 2003;

        public int MaxSpeed()
        {
            int MaxSpeed = 300;
            return MaxSpeed;
        }
    }
    class Marcedes : ICar
    {
        public string Brand => "Marcedes";

        public double HorsePower => 210;

        public int YearOfRealese => 2010;

        public int MaxSpeed()
        {
            int MaxSpeed = 320;
            return MaxSpeed;
        }
    }

}
