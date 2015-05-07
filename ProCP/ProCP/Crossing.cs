using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Crossing
    {
        //Fields
        int crossingId = 0;
        Point position;
        List<Lane> lanes;

        //Properties

        /// <summary>
        /// Each crossing is unique and cannot have more than 12
        /// </summary>
        public int CrossingId
        {
            get { return crossingId; }
            set { if (value <= 12)
	                {
		             crossingId = value; 
	                }
                }
        }

        /// <summary>
        /// Which direction the lane is going
        /// </summary>
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }


        //Constructor
        public Crossing(int crossingId, Point position, List<Lane> lanes)
        {
            this.CrossingId = crossingId++;
            this.Position = position;

            this.lanes = new List<Lane>();
            //Need to figure out the lists
        }

        //Methods

    }
}
