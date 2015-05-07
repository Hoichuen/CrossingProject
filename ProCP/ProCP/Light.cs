using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    class Light
    {
        TimeSpan time;
        bool state;
        public delegate void LightSwitch(TimeSpan time, bool state);
        public event LightSwitch LightSwitchEvent;

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
            
        }

        public bool State
        {
            get { return state; }
            set { state = value; }
            
        }

        public Light(TimeSpan time, bool state)
        {
            this.Time = time;
            this.State = state;
        }
    }
}
