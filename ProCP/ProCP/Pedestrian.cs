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
        PedestrianLane lane;
        Point position = new Point();
        Crossing_B crossing;
        Point StartPosition = new Point(); 

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
        /// The lane of the pedestrian
        /// </summary>
        public PedestrianLane Lane
        {
            get { return lane; }
            set { lane = value; }
        }


        /// <summary>
        /// Constructor for type pedestrian
        /// </summary>
        /// <param name="pedId">which pedestrian</param>
        /// <param name="Crossing">on which crossing should it be created</param>
        
        public Pedestrian(int pedId, Crossing_B Crossing)
        {
            this.pedId = pedId;
            this.crossing = Crossing;
            this.StartPosition = WhereToStart();
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
        /// Walking method based on direction
        /// </summary>
        public void Walk()
        {
            if (lane.PLight.State)
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
        /// <summary>
        /// Makes the pedestrian press the sensor of his lane
        /// </summary>
        private void PressSensor()
        {
            this.lane.PLight.sensorPressed();
        }
    }
}
