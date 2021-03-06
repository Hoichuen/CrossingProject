﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace ProCP
{
    [KnownType(typeof(Crossing))]
    [KnownType(typeof(Crossing_A))]
    [KnownType(typeof(Crossing_B))]
    [KnownType(typeof(TrafficLane))]
    [KnownType(typeof(Lane))]
    [KnownType(typeof(PedestrianLane))]
    [DataContract(Name = "Crossing")]
    class Crossing
    {
        //Fields
        int crossingId = 0;
        List<TrafficLane> lanes = new List<TrafficLane>();
        int turn = 1;
        TimeSpan time;
        int numCars;

        private System.Windows.Forms.Timer aTimer;

        //Properties

        public System.Windows.Forms.Timer ATimer
        {
            get { return aTimer; }
            set { aTimer = value; }
        }

        /// <summary>
        /// which rotation of the lights
        /// </summary>
        public int Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        /// <summary>
        /// The Green time
        /// </summary>
        public TimeSpan Time
        {
            get { return time; }
            set { time = value; }
        }

        /// <summary>
        /// the total number of Cars in this crossing
        /// </summary>
        public int NumCars
        {
            get { return numCars; }
            set { numCars = value; }
        }

        /// <summary>
        /// Each crossing is unique and cannot have more than 12
        /// </summary>
        /// 
        [DataMember(Name = "CrossingId")]
        public int CrossingId
        {
            get { return crossingId; }
            set { crossingId = value; }
        }

        /// <summary>
        /// The list of traffic lanes on the crossing
        /// </summary>
        public List<TrafficLane> Lanes
        {
            get { return lanes; }
            set { lanes = value; }
        }

        /// <summary>
        /// The Constructor of the crossing
        /// </summary>
        /// <param name="crossingId"></param>
        /// <param name="position"></param>
        public Crossing(int crossingId)
        {
            this.CrossingId = crossingId;

            this.Time = TimeSpan.FromSeconds(5);
            this.NumCars = 0;
        }

        //Methods

        /// <summary>
        /// Finds the lanes in the direction that are
        /// traveling to the crossing and are connecting lanes
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<TrafficLane> LanesInDirection(Direction direction)
        {
            List<TrafficLane> temp = new List<TrafficLane>();

            foreach (TrafficLane i in Lanes)
            {
                if ((i.LaneType == null) && (i.Direction == direction) && (i.ToFromCross))
                {
                    temp.Add(i);
                }
            }

            return temp;
        }

    }
}
