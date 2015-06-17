using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ProCP
{
    [DataContract(Name = "Light")]
    class Light
    {


        bool state;

        /// <summary>
        /// the state of the light
        /// </summary>
        public bool State
        {
            get { return state; }
            set { state = value; }

        }

        /// <summary>
        /// constructor for light
        /// </summary>
        /// <param name="state">the initial state of the light</param>
        public Light(bool state)
        {
            this.State = state;
        }
    }
}
