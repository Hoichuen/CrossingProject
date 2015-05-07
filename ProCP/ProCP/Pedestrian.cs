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

        //Properties

        /// <summary>
        /// Each pedestrian is unique
        /// </summary>
        public int PedId
        {
            get; private set;
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
            set { Speed = value; }
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
        public Pedestrian(int pedId, Color color, int speed, PedestrianLane lane)
        {
            this.PedId = pedId++;
            this.Color = color;
            this.Speed = speed; //Speed might be fixed to we can change that
            this.Lane = lane;
        }

        //Methods

        /// <summary>
        /// Returns the Point position of the pedestrian
        /// </summary>
        /// <returns></returns>
        Point getPosition()
        {
            Point p = new Point();
            return p;
        }

        /// <summary>
        /// Returns the peestrian's lane
        /// </summary>
        /// <returns></returns>
        PedestrianLane getLane()
        {
            return null;
        }

        /// <summary>
        /// Walking method
        /// </summary>
        void Walk()
        {

        }

    }
}
