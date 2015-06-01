using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ProCP
{
    class Simulation
    {
<<<<<<< HEAD
        private int time;
        
        private Crossing[] Crossings;
        
=======
        //private Crossing[] Crossings;

        private List<Crossing> Crossings;
        private List<Car> cars;

>>>>>>> origin/master
        public Simulation()
        {
            Crossings = new List<Crossing>();
        }

        public void Start() { }
        public void Stop() { }

<<<<<<< HEAD
        public void AddCrossing(Crossing Crossing,int where)
=======
        public void AddCrossing(Crossing Crossing)
>>>>>>> origin/master
        {
            Crossings.Add(Crossing);
        }

<<<<<<< HEAD
        public void RemoveCrossing(int position)
        {
            Array.Clear(Crossings, position - 1, 1); 
        }
=======
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
            }
        }

      
        public void EditCrossing(int id, int numCars, int time, int numPeds)
        {
            Crossing cr = Crossings.Find(x => x.CrossingId == (id));

            if (cr.GetType() == typeof(Crossing_A))
            {
                cr.NumCars = numCars;
                cr.Time = new TimeSpan(0, 0, time);
            }

            else
            {
                Crossing_B cr1 = (Crossing_B)cr;
                cr1.NumCars = numCars;
                cr1.Time = new TimeSpan(0,0,time);
                cr1.NumPeds = numPeds;
 
            }

        }

        public void getProperties(int id, ref int nCars, ref int time, ref int nPed)
        {
            Crossing cr = Crossings.Find(x => x.CrossingId == (id));

            nCars = cr.NumCars;
            time = cr.Time.Seconds;

            if (cr.GetType() == typeof(Crossing_B))
            {
                Crossing_B cr1 = (Crossing_B)cr;
                nPed = cr1.NumPeds;   
            }
            else
            {
                nPed = 0;
            }
        }


        public bool CrossingExist(int id)
        {
         return Crossings.Exists(x => x.CrossingId == (id));
        }

        public void RemoveCrossing(int id)
        {
            Crossings.Remove(Crossings.Find(x => x.CrossingId == (id)));
        }

        public void CreateCars()
        {
            cars = new List<Car>();
            List<TrafficLane> tmp = new List<TrafficLane>();
            Random rnd = new Random();
            int count=1;

            foreach (Crossing item in Crossings)
            {
                tmp.AddRange(item.Lanes.FindAll(x => x.LaneType == true));

                for (int i = 0; i < item.NumCars; i++)
                {
                    cars.Add(new Car(count, Color.FromArgb(rnd.Next()), tmp.ElementAt(rnd.Next(tmp.Count()))));
                    count++;
                }
            }
            Console.WriteLine("Haha");
        }

>>>>>>> origin/master
    }
}
