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
        const int MAX_POINTS_PER_VERTICAL_LANE = 3;
        const int MAX_POINTS_PER_HORIZONTAL_LANE = 4;
        const int VERTICAL_SPACE_BETWEEN_POINTS = 15;
         
        //Fields
        bool? laneType = null;
        bool toFromCross;
        Direction direction;
        Light trafficLight;
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
        public Light TrafficLight
        {
            get { return trafficLight; }
            set { trafficLight = value; }
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
        public TrafficLane(int iD, bool toFromCross, Direction direction, Light trafficLight, List<TrafficLane> connLanes, Crossing parent) : base(iD)
        {
            this.ID = iD;
            this.ToFromCross = toFromCross;
            this.Direction = direction;
            this.Lanes = connLanes;
            this.parent = parent;
            this.TrafficLight = trafficLight;
            this.IsFull = false;
            //Need to figure out the lists

            Cars = new List<Car>();

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
            int[] xOffset = { 134, 157, 77, 5, 77, 104, 157, 157, 134, 107, 5, 5 };
            int[] yOffset = { 1, 98, 111, 54, 1, 1, 54, 74, 111, 111, 94, 74 };

            return getPointList(xOffset, yOffset);
        }

        private List<Point> processAndReturnPointsForCrossingB()
        {
            int[] xOffset = { 128, 157, 85, 5, 85, 157, 157, 128, 5, 5 };
            int[] yOffset = { 1, 94, 113, 54, 1, 54, 73, 113, 94, 74 };

            return getPointList(xOffset, yOffset);
        }

        private List<Point> getPointList(int[] xOffset, int[] yOffset)
        {
            List<Point> points = new List<Point>();

            bool ascending = (this.direction.Equals(Direction.NORTH) || this.direction.Equals(Direction.EAST)) ? true : false;
            bool vertical = (this.direction.Equals(Direction.SOUTH) || this.direction.Equals(Direction.NORTH)) ? true : false;

            for (int i = 0; i < MAX_POINTS_PER_HORIZONTAL_LANE; i++)
            {
                int curOffsetX = xOffset[this.ID], curOffsetY = yOffset[this.ID];

                if (vertical && i < MAX_POINTS_PER_VERTICAL_LANE)
                {
                    points.Add(new Point(curOffsetX, curOffsetY + (VERTICAL_SPACE_BETWEEN_POINTS * i)));
                    continue;
                }

                if (!vertical) {
                    points.Add(new Point(curOffsetX + (VERTICAL_SPACE_BETWEEN_POINTS * i), curOffsetY));
                }
            }

            if (this.direction.Equals(Direction.NORTH) || this.direction.Equals(Direction.WEST))
                points.Reverse();

            return points;
        }

        public Point GetNextPoint(Point point)
        {
            return this.Points.ElementAt(Points.FindIndex(x => x == point) + 1);
        }

        public int NumEmptyPoints()
        {
            int count = 0;
            foreach (Point i in this.Points)
            {
                foreach (Car c in Cars)
                {
                    if (c.CurPoint == i)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        internal bool IsNextPointEmpty(Point point)
        {
            if (Cars.Exists(x=>x.CurPoint == Points.ElementAt(Points.FindIndex(y=>y == point)+1)))
            {
                return false;
            }
            return true;
        }

        public bool IsFirstPointEmpty()
        {
            return Cars.Exists(x => x.CurPoint == Points.First());
        }
    }
}