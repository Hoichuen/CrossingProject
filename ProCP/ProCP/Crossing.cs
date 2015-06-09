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
        List<TrafficLane> lanes = new List<TrafficLane>();

        TimeSpan time;
        int numCars;

        //Properties

        /// <summary>
        /// the Time the light is green
        /// </summary>
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// the total number of cars
        /// </summary>
        public int NumCars
        {
            get { return numCars; }
            set { numCars = value; }
        }

        /// <summary>
        /// Each crossing is unique and cannot have more than 12
        /// </summary>
        public int CrossingId
        {
            get { return crossingId; }
            set { crossingId = value; }
        }

        /// <summary>
        /// Which direction the lane is going
        /// </summary>
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// the list of all lanes in this crossing
        /// </summary>
        public List<TrafficLane> Lanes
        {
            get { return lanes; }
            set { lanes = value; }
        }

        //Constructor
        //public Crossing(int crossingId, Point position, List<TrafficLane> lanes)
        public Crossing(int crossingId, Point position)
        {
            this.CrossingId = crossingId;
            this.Position = position;

            this.Time = TimeSpan.Zero;
            this.NumCars = 0;
            
            //this.Lanes = lanes;
            //Need to figure out the lists
        }

        //Methods

        /// <summary>
        /// finds all lanes that are in that direction and that are going to the crossing
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<TrafficLane> LanesInDirection(Direction direction)
        {
            List<TrafficLane> temp = new List<TrafficLane>();

            foreach (TrafficLane i in Lanes)
            {
                if ((i.LaneType == null) && (i.Direction == direction) && (i.ToFromCross))
                {
                    temp.Add(i);
                }
            }

            return temp;
        }

    }
}
