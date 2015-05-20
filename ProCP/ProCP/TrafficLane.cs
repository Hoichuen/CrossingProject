using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class TrafficLane : Lane
    {
         //Fields
        bool? laneType;
        bool toFromCross;
        Direction direction;
        List<Light> trafficLights;
        List<Car> cars;
        List<TrafficLane> lanes;
       
        //Properties

        /// <summary>
        /// Feeder or end lane, or just a connecting lane
        /// </summary>
        public bool? LaneType
        {
            get { return laneType; }
            set { laneType = value; }
        }

        public bool ToFromCross
        {
            get { return toFromCross; }
            set { toFromCross = value; }
        }

        /// <summary>
        /// List of trafficlights within this lane
        /// </summary>
        public List<Light> TrafficLights
        {
            get { return trafficLights; }
            set { trafficLights = value; }
        }
        
        /// <summary>
        /// List of cars in this lane
        /// </summary>
        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        /// <summary>
        /// List of lanes connecting to this lane
        /// </summary>
        public List<TrafficLane> Lanes
        {
            get { return lanes; }
            set { lanes = value; }
        }

        /// <summary>
        /// Which direction the lane is going much easier as an int as we can do 0 is left to right
        /// 1 is right to left, 2 is up to down, and 3 is down to up.
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }


        //Constructor
        public TrafficLane(int iD, bool toFromCross, Direction direction, List<Point> points, bool isFull, List<Light> trafficLights, List<TrafficLane> lanes)
            : base(iD, points, isFull)
        {
            this.ID = iD;
            this.ToFromCross = toFromCross;
            this.Direction = direction;
            this.Lanes = lanes;
            //Need to figure out the lists
        }

        //Methods

        /// <summary>
        /// Returns a list of lanes that can connect to this one aka same direction
        /// </summary>
        /// <returns></returns>
       public List<Lane> GetConnectingLanes()
        {
            return null;
        }
    }
}