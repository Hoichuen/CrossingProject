using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP
{
    class Simulation
    {
        private int time;
        
        
        //private Crossing[] Crossings;

        private List<Crossing> Crossings;

        public Simulation()
        {
            Crossings = new List<Crossing>();
        }

        public void Start() { }
        public void Stop() { }
        public void AddCrossing(Crossing Crossing)
        {
            Crossings.Add(Crossing);
        }

        /// <summary>
        /// Will determine whether lanes are sink or feeders or normal lanes.
        /// </summary>
        public void MarkLanes()
        {
            foreach (Crossing i in Crossings)
            {
                //NORTH
                if (Crossings.Find(x => x.CrossingId == (i.CrossingId)-4)==null)
                {
                    foreach (TrafficLane j in i.Lanes)
                    {
                        if (j.Direction == Direction.NORTH && (!j.ToFromCross))
                        {
                            j.LaneType = false;
                        }
                        if (j.Direction == Direction.SOUTH && (j.ToFromCross))
                        {
                             j.LaneType = true;
                        }

                    }
                }

                //EAST
                if (Crossings.Find(x => x.CrossingId == (i.CrossingId) + 1) == null)
                {
                    foreach (TrafficLane j in i.Lanes)
                    {
                        if (j.Direction == Direction.EAST && (!j.ToFromCross))
                        {
                            j.LaneType = false;
                        }
                        if (j.Direction == Direction.WEST && (j.ToFromCross))
                        {
                            j.LaneType = true;
                        }
                    }
                }

                //SOUTH

                if (Crossings.Find(x => x.CrossingId == (i.CrossingId) + 4) == null)
                {
                    foreach (TrafficLane j in i.Lanes)
                    {
                        if (j.Direction == Direction.SOUTH && (!j.ToFromCross))
                        {
                            j.LaneType = false;
                        }
                        if (j.Direction == Direction.NORTH && (j.ToFromCross))
                        {
                            j.LaneType = true;
                        }
                    }
                }

                //WEST

                if (Crossings.Find(x => x.CrossingId == (i.CrossingId) - 1) == null)
                {
                    foreach (TrafficLane j in i.Lanes)
                    {
                        if (j.Direction == Direction.WEST && (!j.ToFromCross))
                        {
                            j.LaneType = false;
                        }
                        if (j.Direction == Direction.EAST && (j.ToFromCross))
                        {
                            j.LaneType = true;
                        }
                    }
                }

            }
        }

        public void LaneCrossingConnection()
        {
            foreach (Crossing i in Crossings)
            {
                foreach (TrafficLane j in i.Lanes)
                {
                    if (!(j.ToFromCross) && (j.LaneType==null))
                    {
                        if (j.Direction == Direction.NORTH)
                        {
                            j.Lanes.AddRange(Crossings.Find(x => x.CrossingId == i.CrossingId - 4).LanesInDirection(j.Direction));
                        }
                        if (j.Direction == Direction.EAST)
                        {
                            j.Lanes.AddRange(Crossings.Find(x => x.CrossingId == i.CrossingId + 1).LanesInDirection(j.Direction));
                        }
                        if (j.Direction == Direction.SOUTH)
                        {
                            j.Lanes.AddRange(Crossings.Find(x => x.CrossingId == i.CrossingId + 4).LanesInDirection(j.Direction));
                        }
                        if (j.Direction == Direction.WEST)
                        {
                            j.Lanes.AddRange(Crossings.Find(x => x.CrossingId == i.CrossingId - 1).LanesInDirection(j.Direction));
                        }
                    }
                }
                Console.Write("Haha");
            }
        }
    }
}
