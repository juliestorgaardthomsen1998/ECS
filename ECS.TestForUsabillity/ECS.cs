using System;


namespace ECS.TestForUsabillity
{
    public class ECS
    {
        //private int _threshold;
        private readonly ITempSensor _tempSensor;
        private readonly IHeater _heater;

        public int Threshold { get; set; }

        public ECS(int thr, ITempSensor tempSensor, IHeater heater)
        {
            //SetThreshold(thr);
            Threshold = thr;
            _tempSensor = tempSensor;
            _heater = heater;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetTemp();
            Console.WriteLine($"Temperature measured was {t}");
            if (t < Threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }//yo

        public void SetThreshold(int thr)
        {
            Threshold = thr;
        }

        public int GetThreshold()
        {
            return Threshold;
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetTemp();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}
