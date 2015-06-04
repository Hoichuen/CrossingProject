using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Car
    {
        //Fields
        int carId = 1;
        Color color;
        int speed = 50;
        TrafficLane currentLane;
        Point curPoint;
        List<TrafficLane> route;

        //Properties

        /// <summary>
        /// Each car is unique
        /// </summary>
        public int CarId
        {
            get
            {
                return carId;
            }
            private set
            {
                carId = value;
            }
        }

        /// <summary>
        /// Color of the car
        /// </summary>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Speed of the car should be fixed
        /// </summary>
        public int Speed
        {
            get { return speed; }
            set { Speed = value; }
        }

        /// <summary>
        /// Current Point
        /// </summary>
        public Point CurPoint
        {
            get { return curPoint; }
            set { curPoint = value; }
        }

        /// <summary>
        /// Cars will be switching lanes a lot, its nice to keep track
        /// </summary>
        public TrafficLane CurrentLane
        {
            get { return currentLane; }
            set { currentLane = value; }
        }

        public List<TrafficLane> Route
        {
            get { return route; }
            set { route = value; }
        }


        //Constructor
        public Car(int carId, Color color, TrafficLane startingLane)
        {
            this.CarId = carId++;
            this.Color = color;
            this.CurrentLane = startingLane;
            if (CurrentLane.Cars.First()==null)
            {
                this.CurPoint = CurrentLane.Points.First();
            }
            this.Route = CreateRoute(startingLane);
            CurrentLane.Cars.Add(this);

        }

        //Methods

        /// <summary>
        /// Returns the Point position of the car
        /// </summary>
        /// <returns></returns>
        Point getPosition()
        {
            Point p = new Point();
            return p;
        }

        /// <summary>
        /// Returns the car's lane
        /// </summary>
        /// <returns></returns>
        Lane getLane()
        {
            return null;
        }

        /// <summary>
        /// Driving method down the lane
        /// </summary>
        void DriveLane()
        {
            if (this.CurrentLane.TrafficLight.State && this.CurrentLane.GetNextPoint(this.CurPoint).IsEmpty)
            {
                if (CurPoint.IsEmpty)
                {
                    if (CurrentLane.Cars.ElementAt(CurrentLane.Points.Count()) == this)
                    {
                        this.CurPoint = CurrentLane.Points.First();
                    }
                }
                else if (CurPoint == CurrentLane.Points.Last())
                {
                    this.SwitchLane();
                }
                else
                {
                    this.CurPoint = this.CurrentLane.GetNextPoint(this.CurPoint);
                }
            }
        }

        /// <summary>
        /// When a car switches lane we have to know
        /// </summary>
        void SwitchLane()
        {
            if (Route.ElementAt(1)!=null)
            {
                this.CurrentLane.Cars.Remove(this);
                this.Route.RemoveAt(0);
                this.CurrentLane = Route.First();
                this.CurrentLane.Cars.Add(this);
            }
            else
            {
                this.CurrentLane.Cars.Remove(this);
            }
        }

        /// <summary>
        /// Creates the route of the car
        /// </summary>
        /// <param name="startingLane"></param>
        /// <returns></returns>
        public List<TrafficLane> CreateRoute(TrafficLane startingLane)
        {
            bool finished = false;
            Random rnd = new Random();

            List<TrafficLane> tempRoute = new List<TrafficLane>();
            List<TrafficLane> temp = new List<TrafficLane>();

            TrafficLane tmp;

            tempRoute.Add(startingLane);
            temp = startingLane.Lanes;

            while (!finished)
            {
                tmp = temp.ElementAt(rnd.Next(temp.Count));
                tempRoute.Add(tmp);

                if (tmp.LaneType == false)
                {
                    finished = true;
                }

                temp = tmp.Lanes;
            }

            return tempRoute;
        }

    }
}
