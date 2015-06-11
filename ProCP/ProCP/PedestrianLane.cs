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
     
        PedestrianLight pLight; 
        Crossing_B parent;

        //Properties
    

        /// <summary>
        /// A light object on the pedestrian lane
        /// </summary>
        public PedestrianLight PLight
        {
            get { return pLight; }
            set { pLight = value; }
        }

        /// <summary>
        /// A constructor for Pedestrian lane
        /// </summary>
        /// <param name="iD">the id of the lane</param>
        /// <param name="points">a list of points on the lane</param>
        /// <param name="pLight">the light object on the lane</param>
        /// <param name="crossing">the crossing this lane belongs to</param>
        public PedestrianLane(int iD, List<Point> points, PedestrianLight pLight,Crossing_B crossing)
            : base(iD, points)
        {
            this.PLight = pLight;
            this.parent = crossing;

        }

        /// <summary>
        /// Gets the crossing that owns the lane
        /// </summary>
        /// <returns>an object of type crossing B</returns>
       
        public Crossing_B GetCrossingB()
        {
            return parent;
        }

    }
}
