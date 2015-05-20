﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Crossing_B:Crossing
    {
        /// <summary>
        /// The crossing type B constructor
        /// </summary>
        public Crossing_B(int crossingId, Point position)
            : base(crossingId, position)
        {
            List<TrafficLane> lanes = new List<TrafficLane>();
            List<TrafficLane> tLanes;
            lanes = new List<TrafficLane>();

            tLanes = new List<TrafficLane>();

            for (int i = 0; i < 4; i++)
            {
                lanes.Add(new TrafficLane(i, false, (Direction)i, null, false, null, tLanes));
            }

            //Adding the list of lanes that a certain lane can go to, as well as creating the lanes.

            //For South
            tLanes.Add(lanes.ElementAt(2));
            lanes.Add(new TrafficLane(4, true, Direction.SOUTH, null, false, null, tLanes));
            tLanes.Clear();

            //For West
            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(0), lanes.ElementAt(3) });
            lanes.Add(new TrafficLane(5, true, Direction.WEST, null, false, null, tLanes));
            tLanes.Clear();

            tLanes.Add(lanes.ElementAt(2));
            lanes.Add(new TrafficLane(6, true, Direction.WEST, null, false, null, tLanes));
            tLanes.Clear();

            //For North
            tLanes.Add(lanes.ElementAt(0));
            lanes.Add(new TrafficLane(7, true, Direction.NORTH, null, false, null, tLanes));
            tLanes.Clear();

            //For East
            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(1), lanes.ElementAt(2) });
            lanes.Add(new TrafficLane(8, true, Direction.EAST, null, false, null, tLanes));
            tLanes.Clear();

            tLanes.Add(lanes.ElementAt(0));
            lanes.Add(new TrafficLane(9, true, Direction.EAST, null, false, null, tLanes));
            tLanes.Clear();

            base.Lanes.AddRange(lanes);
        }
    }
}
