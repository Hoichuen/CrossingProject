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

        //Properties

        /// <summary>
        /// Each car is unique
        /// </summary>
        public int CarId
        {
            get; private set;
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
        /// Cars will be switching lanes a lot, its nice to keep track
        /// </summary>
        public TrafficLane CurrentLane
        {
            get { return currentLane; }
            set { currentLane = value; }
        }


        //Constructor
        public Car(int carId, Color color, int speed, TrafficLane lane)
        {
            this.CarId = carId++;
            this.Color = color;
            this.Speed = speed; //Speed might be fixed to we can change that
            this.CurrentLane = lane;
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

        }

        /// <summary>
        /// When a car switches lane we have to know
        /// </summary>
        void SwitchLane()
        {

        }

        /// <summary>
        /// Car has to stop sometimes for red lights, and pedestrians
        /// </summary>
        void Stop()
        {

        }

    }
}
