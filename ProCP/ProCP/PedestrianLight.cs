using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    class PedestrianLight : Light
    {
        //Fields
        bool sensor=false;

        public bool Sensor
        {
            get { return sensor; }
            set { sensor = value; }
        }

        public PedestrianLight(TimeSpan time, bool state, bool sensor)
            : base(time, state)
        {
            this.Sensor = sensor;
        }

        public void sensorPressed()
        {
            sensor = true;
        }


    }
}
