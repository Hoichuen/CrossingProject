using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Pedestrian
    {
        //Fields
        int pedId = 1;
        Color color;
        int speed = 5;
        PedestrianLane lane;
        Point position = new Point();
        Crossing_B crossing;
        Point StartPosition = new Point(); //we need this to calculate the direction of the pedestrian

        //Properties

        /// <summary>
        /// Each pedestrian is unique
        /// </summary>
        public int PedId
        {
            get { return pedId; }
            private set { }
        }

        /// <summary>
        /// Color of the pedestrian
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
            set { speed = value; }
        }

        /// <summary>
        /// Cars will be switching lanes a lot, its nice to keep track
        /// </summary>
        public PedestrianLane Lane
        {
            get { return lane; }
            set { lane = value; }
        }


        //Constructor
        public Pedestrian(int pedId, Color color, int speed, Crossing_B Crossing)
        {
            this.PedId = pedId++;
            this.Color = color;//thats racism
            this.Speed = speed; //Speed might be fixed to we can change that
            this.crossing = Crossing;
            this.StartPosition = WhereToStart(); //this one sets the lane aswell
            this.position = StartPosition;
            PressSensor();
        }

        //Methods

        /// <summary>
        /// Returns the Point position of the pedestrian
        /// </summary>
        /// <returns></returns>
        public Point getPosition()
        {

            return position;
        }

        /// <summary>
        /// Returns the pedestrian's lane
        /// </summary>
        /// <returns></returns>
        PedestrianLane getLane()
        {
            return lane;
        }

        /// <summary>
        /// Walking method
        /// </summary>
        public void Walk()
        {
            if (lane.PLight.State) //if the light is on
            {
                int indexPosition = 0;
                for (int i = 0; i < lane.Points.Count; i++)
                {
                    if (lane.Points[i] == this.position) indexPosition = i;
                }
                try
                {
                    if (Direction())
                    {
                        position = lane.Points[indexPosition + 1];
                    }
                    else position = lane.Points[indexPosition - 1];
                }
                catch (Exception)
                {
                    Pedestrian p = lane.GetCrossingB().pedestrians.Find(x => x.PedId == this.PedId);
                    for (int i = 0; i < lane.GetCrossingB().pedestrians.Count; i++)
                    {
                        if (lane.GetCrossingB().pedestrians[i].lane == p.lane && p.pedId != lane.GetCrossingB().pedestrians[i].pedId) 
                            PressSensor();
                            if (lane.GetCrossingB().pedestrians[i] == p) 
                                lane.GetCrossingB().pedestrians.RemoveAt(i);
                    }
                }

            }

        }
        /// <summary>
        /// Determines the starting position of the pedestrian at random
        /// A random lane and a random point of the lane
        /// </summary>
        private Point WhereToStart()
        {
            Random rng = new Random();
            int startHelper = rng.Next(1, 2);
            if (startHelper == 1) lane = crossing.pLanes[0];
            else lane = crossing.pLanes[1];

            startHelper = rng.Next(1, 2);
            if (startHelper == 1) return lane.Points[0];
            else return lane.Points[lane.Points.Count - 1];

        }
        /// <summary>
        /// Calculates the direction of the pedestrian.
        /// True = left to right
        /// False = right to left
        /// </summary>
        /// <returns></returns>
        private bool Direction()
        {
            if (StartPosition == lane.Points[0]) return true;
            else return false;
        }
        private void PressSensor()
        {
            this.lane.PLight.sensorPressed();
        }
    }
}
