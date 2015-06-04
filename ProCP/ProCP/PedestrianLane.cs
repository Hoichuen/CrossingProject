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
        PedestrianLight pLight; //regardless of where you are you cant have one light red another 
        ///green per lane therefore we need 1 light
      

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
        public PedestrianLight PLight
        {
            get { return pLight; }
            set { pLight = value; }
        }

        //Constructor

        public PedestrianLane(int iD, List<Point> points, bool isFull, PedestrianLight pLight)
            : base(iD, points, isFull)
        {
            this.PLight = pLight;

        }

        
        public bool isEmpty(PedestrianLane lane)
        {

            return Empty;
        }
        public Crossing_B GetCrossingB()
        {
            return (Crossing_B)base.GetCrossing();
        }

    }
}
