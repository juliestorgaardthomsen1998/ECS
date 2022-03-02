using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.TestForUsabillity;

namespace ECS.Unit.Test
{
    class FakeTempSensor : ITempSensor
    {
        public int Gen { get; set; } 
        public int GetTemp()
        {
            return Gen;
        }

        public bool RunSelfTest()
        {
            return true;
        }

        


    }
}
