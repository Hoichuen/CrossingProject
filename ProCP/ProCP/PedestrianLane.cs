using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class PedestrianLane : Lane
    {
        //Fields
        bool empty;
        List<PedestrianLight> pLights;

        //Properties
        /// <summary>
        /// Used to see if the lane contain pedestrians
        /// </summary>
        public bool Empty
        {
            get { return empty; }
            set { empty = value; }
        }

        /// <summary>
        /// List of lights for pedestrians
        /// </summary>
        public List<PedestrianLight> PLights
        {
            get { return pLights; }
            set { pLights = value; }
        }

        //Constructor

        public PedestrianLane(int iD, List<Point> points, bool isFull, List<PedestrianLight> pLights)
            : base(iD, points, isFull)
        {
            this.PLights = pLights;
        }

        
        public bool isEmpty(PedestrianLane lane)
        {

            return Empty;
        }

    }
}
