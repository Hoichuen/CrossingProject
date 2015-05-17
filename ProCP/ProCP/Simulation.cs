using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP
{
    class Simulation
    {
        private int time;
        
        private Crossing[] Crossings;
        public Simulation()
        {
            Crossings = new Crossing[16];
        }
        public void Start() { }
        public void Stop() { }
        public void AddCrossing(Crossing Crossing,int where)
        {
            Crossings[where - 1] = Crossing; 
        }
    }
}
