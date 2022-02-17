using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.TestForUsabillity;

namespace ECS.Unit.Test
{
    class FakeHeater : IHeater
    {
        public bool Status { get; set; }
        public void TurnOn()
        {
            Status = true;
        }

        public void TurnOff()
        {
            Status = false;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
