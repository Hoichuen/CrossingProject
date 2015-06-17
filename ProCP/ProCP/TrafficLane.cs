using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace ProCP
{
    [DataContract(Name = "TrafficLane")]
    class TrafficLane : Lane
    {
        /// <summary>
        /// constant fields for the points
        /// </summary>
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
        /// Parent Crossing
        /// </summary>
        public Crossing Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        /// <summary>
        /// Feeder or end lane, or just a connecting lane
        /// </summary>
        public bool? LaneType
        {
            get { return laneType; }
            set { laneType = value; }
        }

        /// <summary>
        /// Whether or not the lane is going toward or away from the crossing 
        /// </summary>
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


        /// <summary>
        /// Constructor of the traffic lane
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="toFromCross"></param>
        /// <param name="direction"></param>
        /// <param name="trafficLight"></param>
        /// <param name="connLanes"></param>
        /// <param name="parent"></param>
        public TrafficLane(int iD, bool toFromCross, Direction direction, Light trafficLight, List<TrafficLane> connLanes, Crossing parent)
            : base(iD)
        {
            this.ID = iD;
            this.ToFromCross = toFromCross;
            this.Direction = direction;
            this.Lanes = connLanes;
            this.parent = parent;
            this.TrafficLight = trafficLight;

            Cars = new List<Car>();

            this.initPoints();
        }

        /// <summary>
        /// initiates the points for the lane
        /// </summary>
        private void initPoints()
        {
            if (parent is Crossing_A)
            {
                this.Points = processAndReturnPointsForCrossingA();
                return;
            }

            this.Points = processAndReturnPointsForCrossingB();
        }

        /// <summary>
        /// returns the list of points of crossing A
        /// </summary>
        /// <returns></returns>
        private List<Point> processAndReturnPointsForCrossingA()
        {
            int[] xOffset = { 134, 157, 77, 5, 77, 104, 157, 157, 134, 107, 5, 5 };
            int[] yOffset = { 1, 98, 111, 54, 1, 1, 54, 74, 111, 111, 94, 74 };

            return getPointList(xOffset, yOffset);
        }

        /// <summary>
        /// returns the list of points of crossing B
        /// </summary>
        /// <returns></returns>
        private List<Point> processAndReturnPointsForCrossingB()
        {
            int[] xOffset = { 128, 157, 85, 5, 85, 157, 157, 128, 5, 5 };
            int[] yOffset = { 1, 94, 113, 54, 1, 54, 73, 113, 94, 74 };

            return getPointList(xOffset, yOffset);
        }

        /// <summary>
        /// Uses 2 arrays one x the other yto create the list of points
        /// </summary>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <returns></returns>
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

                if (!vertical)
                {
                    points.Add(new Point(curOffsetX + (VERTICAL_SPACE_BETWEEN_POINTS * i), curOffsetY));
                }
            }

            if (this.direction.Equals(Direction.NORTH) || this.direction.Equals(Direction.WEST))
                points.Reverse();

            return points;
        }

        /// <summary>
        /// returns the next point in the list
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Point GetNextPoint(Point point)
        {
            return this.Points.ElementAt(Points.FindIndex(x => x == point) + 1);
        }

        /// <summary>
        /// returns the number of cars on the points in the list
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// checks if there is a car on the next point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        internal bool IsNextPointEmpty(Point point)
        {
            if (Cars.Exists(x => x.CurPoint == Points.ElementAt(Points.FindIndex(y => y == point) + 1)))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// checkls if the first point of the list has a car on it.
        /// </summary>
        /// <returns></returns>
        public bool IsFirstPointEmpty()
        {
            return Cars.Exists(x => x.CurPoint == Points.First());
        }
    }
}