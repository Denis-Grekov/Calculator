using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2
{
    class Foo
    {
        private char TestChar { get; }

        protected int testNumber2;
        protected int TestNumber2
        {
            get { return testNumber2; }
            set { testNumber2 = value; }
        }
        private char TestChar3;
        public int a { get; set; }
    }
}
