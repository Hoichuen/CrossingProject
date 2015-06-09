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

        /// <summary>
        /// List of Traffic Lanes that make up the route
        /// </summary>
        public List<TrafficLane> Route
        {
            get { return route; }
            set { route = value; }
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="color"></param>
        /// <param name="startingLane"></param>
        public Car(int carId, Color color, TrafficLane startingLane)
        {
            this.CarId = carId++;
            this.Color = color;
            this.CurrentLane = startingLane;

            if (CurrentLane.Cars.Count == 0)
            {
                this.CurPoint = CurrentLane.Points.First();
            }

            this.Route = CreateRoute(startingLane);
            CurrentLane.Cars.Add(this);
        }

        //Methods
        /// <summary>
        /// Method for driving down the lane including 
        /// whether there is a car infront of it as well as if the light is green.
        /// </summary>
        public void DriveLane()
        {
            int num = this.CurrentLane.NumEmptyPoints();
            if (CurPoint == CurrentLane.Points.Last())
            {
                if (this.CurrentLane.ToFromCross && !this.CurrentLane.TrafficLight.State)
                {
                    return;
                }
                else
                {
                    //if (!this.Route.ElementAt(1).IsFirstPointEmpty() || this.Route.Count == 1)
                    //{
                        this.SwitchLane();
                    //}
                }
            }
            else if (((this.CurrentLane.TrafficLight == null) || (!this.CurrentLane.TrafficLight.State)) && this.CurrentLane.IsNextPointEmpty(this.CurPoint))
            {
                if (CurPoint.IsEmpty)
                {
                    if (CurrentLane.Cars.ElementAt(num) == this)
                    {
                        this.CurPoint = CurrentLane.Points.First();
                    }
                }
                else
                {
                    this.CurPoint = this.CurrentLane.GetNextPoint(this.CurPoint);
                }
            }
            else if (this.CurrentLane.TrafficLight.State && this.CurrentLane.IsNextPointEmpty(this.CurPoint))
            {
                if (CurPoint.IsEmpty)
                {
                    if (CurrentLane.Cars.ElementAt(num) == this)
                    {
                        this.CurPoint = CurrentLane.Points.First();
                    }
                }
                else
                {
                    this.CurPoint = this.CurrentLane.GetNextPoint(this.CurPoint);
                }
            }
        }

        /// <summary>
        /// Is triggered when the car is at the last point in the lane in which
        /// it is removed from the current lane and added to the next lane and
        /// point if the first point is availible.
        /// </summary>
        void SwitchLane()
        {
            if (Route.Count > 1)
            {
                TrafficLane temp = this.Route.ElementAt(1);
                this.CurrentLane = temp;
                this.Route.ElementAt(0).Cars.Remove(this);
                this.Route.RemoveAt(0);
                this.CurrentLane.Cars.Add(this);
                if (this.CurrentLane.IsFirstPointEmpty())
                {
                    this.CurPoint = Point.Empty;
                }
                else
                {
                    this.CurPoint = this.CurrentLane.Points.First();
                }
            }
            else
            {
                this.CurrentLane.Cars.Remove(this);
            }
        }
        /*
        void SwitchLane()
        {
            if (Route.ElementAt(1)!=null)
            {
                this.CurrentLane.Cars.Remove(this);
                this.Route.RemoveAt(0);
                this.CurrentLane = Route.First();
                this.CurrentLane.Cars.Add(this);
                if (this.CurrentLane.IsFirstPointEmpty())
                {
                    this.CurPoint = Point.Empty;
                }
                else
                {
                    this.CurPoint = this.CurrentLane.Points.First();
                }
            }
            else
            {
                this.CurrentLane.Cars.Remove(this);
            }
        }*/

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
