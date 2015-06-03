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
        const int MAX_POINTS_PER_LANE = 3;
        const int VERTICAL_SPACE_BETWEEN_POINTS = 15;
         
        //Fields
        bool? laneType = null;
        bool toFromCross;
        Direction direction;
        List<Light> trafficLights;
        List<Car> cars;
        List<TrafficLane> lanes;
        Crossing parent;
       
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

        public TrafficLane(int iD, bool toFromCross, Direction direction, List<Light> trafficLights, List<TrafficLane> connLanes, Crossing parent) : base(iD)
        {
            this.ID = iD;
            this.ToFromCross = toFromCross;
            this.Direction = direction;
            this.Lanes = connLanes;
            this.parent = parent;

            this.IsFull = false;
            //Need to figure out the lists

            this.initPoints();
        }

        private void initPoints()
        {
            if (parent is Crossing_A)
            {
                this.Points = processAndReturnPointsForCrossingA();
                return;
            }

            this.Points = processAndReturnPointsForCrossingB();
        }

        private List<Point> processAndReturnPointsForCrossingA()
        {
            List<Point> points = new List<Point>();

            bool ascending = (this.direction.Equals(Direction.NORTH) || this.direction.Equals(Direction.EAST)) ? true : false;
            bool vertical = (this.direction.Equals(Direction.SOUTH) || this.direction.Equals(Direction.NORTH)) ? true : false;

            int[] xOffset = { 138, 173, 81, 15, 81, 109, 173, 173, 138, 110, 15, 15 };
            int[] yOffset = { 7, 98, 118, 58, 7, 7, 58, 78, 118, 118, 98, 78 };

            for (int i = 0; i < MAX_POINTS_PER_LANE; i++)
            {
                int curOffsetX = xOffset[this.ID], curOffsetY = yOffset[this.ID];

                if (vertical) {
                    points.Add(new Point(curOffsetX, curOffsetY + (VERTICAL_SPACE_BETWEEN_POINTS * i)));
                    continue;
                }

                points.Add(new Point(curOffsetX + (VERTICAL_SPACE_BETWEEN_POINTS * i), curOffsetY));
            }

            if (!ascending)
                points.Reverse();

            return points;
        }

        private List<Point> processAndReturnPointsForCrossingB()
        {
            List<Point> points = new List<Point>();

            bool ascending = (this.direction.Equals(Direction.NORTH) || this.direction.Equals(Direction.EAST)) ? true : false;
            bool vertical = (this.direction.Equals(Direction.SOUTH) || this.direction.Equals(Direction.NORTH)) ? true : false;

            int[] xOffset = { 132, 170, 90, 15, 90, 170, 170, 132, 15, 15 };
            int[] yOffset = { 7, 98, 118, 58, 7, 58, 78, 118, 98, 78 };


            for (int i = 0; i < MAX_POINTS_PER_LANE; i++)
            {
                int curOffsetX = xOffset[this.ID], curOffsetY = yOffset[this.ID];

                if (vertical)
                {
                    points.Add(new Point(curOffsetX, curOffsetY + (VERTICAL_SPACE_BETWEEN_POINTS * i)));
                    continue;
                }

                points.Add(new Point(curOffsetX + (VERTICAL_SPACE_BETWEEN_POINTS * i), curOffsetY));
            }

            if (!ascending)
                points.Reverse();

            return points;
        }

    }
}