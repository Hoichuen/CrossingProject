using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Crossing_A:Crossing
    {
        List<TrafficLane> lanes;
        List<TrafficLane> tLanes;
        List<TrafficLane> tempLanes;

        /// <summary>
        /// The crossing type A constructor
        /// </summary>
        public Crossing_A(int crossingId, Point position) : base(crossingId, position)
        {
            lanes = new List<TrafficLane>();
            tempLanes = new List<TrafficLane>();
            tLanes = new List<TrafficLane>();

            for (int i = 0; i < 4; i++)
            {
                lanes.Add(new TrafficLane(i, false, (Direction)i, null, tempLanes, this));
            }

            //Adding the list of lanes that a certain lane can go to, as well as creating the lanes.

            //For South
            tLanes.Add(lanes.ElementAt(3));
            lanes.Add(new TrafficLane(4, true, Direction.SOUTH, null, tLanes, this));
            tLanes.Clear();

            tLanes.AddRange((new TrafficLane[] { lanes.ElementAt(1), lanes.ElementAt(2) }).ToList<TrafficLane>());
            lanes.Add(new TrafficLane(5, true, Direction.SOUTH, null, tLanes, this));
            tLanes.Clear();

            //For West
            tLanes.Add(lanes.ElementAt(0));
            lanes.Add(new TrafficLane(6, true, Direction.WEST, null, tLanes, this));
            tLanes.Clear();

            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(2), lanes.ElementAt(3) });
            lanes.Add(new TrafficLane(7, true, Direction.WEST, null, tLanes, this));
            tLanes.Clear();

            //For North
            tLanes.Add(lanes.ElementAt(1));
            lanes.Add(new TrafficLane(8, true, Direction.NORTH, null, tLanes, this));
            tLanes.Clear();

            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(0), lanes.ElementAt(3) });
            lanes.Add(new TrafficLane(9, true, Direction.NORTH, null, tLanes, this));
            tLanes.Clear();

            //For East
            tLanes.Add(lanes.ElementAt(2));
            lanes.Add(new TrafficLane(10, true, Direction.EAST, null, tLanes, this));
            tLanes.Clear();

            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(0), lanes.ElementAt(1) });
            lanes.Add(new TrafficLane(11, true, Direction.EAST, null, tLanes, this));
            tLanes.Clear();

            base.Lanes.AddRange(lanes);
        }
    }
}
