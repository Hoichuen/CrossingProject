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
=======
        int TotalNumberCars { get; set; }
        int TotalNumberPedestrians { get; set; }
        System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();
>>>>>>> origin/Driving-Methods

        private List<Crossing> Crossings;
        private List<Car> cars;

        public Simulation()
        {
            Crossings = new List<Crossing>();
        }

        public void Start()
        {
            Watch.Reset();
            foreach (Crossing i in Crossings)
            {
                TotalNumberCars += i.NumCars;
                if (i.GetType() == typeof(Crossing_B))
                {
                    Crossing_B temp = (Crossing_B)i;
                    TotalNumberPedestrians += temp.NumPeds;
                }
            }
            Watch.Start(); }
        public void Stop() { Watch.Stop(); }

        public bool AddCrossing(Crossing Crossing)
        {
            if (Crossings.Count < 12)
            {
                Crossings.Add(Crossing);
                return true;
            }

            MessageBox.Show("Remove a crossing to be able to add another one. You can have only 12 crossings at the same time.", "Crossing limit reached");
            return false;
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
                //hardcode
                //if (i.Lanes.ElementAt(0).LaneType==null)
                //{
                //    i.Lanes.ElementAt(0).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId - 4).Lanes.ElementAt(8));
                //    i.Lanes.ElementAt(0).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId - 4).Lanes.ElementAt(9));
                //}
                //if (i.Lanes.ElementAt(1).LaneType == null)
                //{
                //    i.Lanes.ElementAt(1).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId + 1).Lanes.ElementAt(10));
                //    i.Lanes.ElementAt(1).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId + 1).Lanes.ElementAt(11));
                //}
                //if (i.Lanes.ElementAt(2).LaneType == null)
                //{
                //    i.Lanes.ElementAt(2).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId + 4).Lanes.ElementAt(4));
                //    i.Lanes.ElementAt(2).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId + 4).Lanes.ElementAt(5));
                //}
                //if (i.Lanes.ElementAt(3).LaneType == null)
                //{
                //    i.Lanes.ElementAt(3).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId - 1).Lanes.ElementAt(6));
                //    i.Lanes.ElementAt(3).Lanes.Add(Crossings.Find(x => x.CrossingId == i.CrossingId - 1).Lanes.ElementAt(7));
                //}
                //nested if
                //List<TrafficLane> temp = new List<TrafficLane>();
                //if (i.Lanes.Find(x=>x.ID==0).LaneType == null)
                //{
                //    temp = Crossings.Find(x => x.CrossingId == i.CrossingId - 4).LanesInDirection(Direction.NORTH);
                //    i.Lanes.Find(x => x.ID == 0).Lanes.AddRange(temp);
                //}
                //temp = new List<TrafficLane>();
                //if (i.Lanes.Find(x => x.ID == 1).LaneType == null)
                //{
                //    temp = Crossings.Find(x => x.CrossingId == i.CrossingId + 1).LanesInDirection(Direction.EAST);
                //    i.Lanes.Find(x => x.ID == 1).Lanes.AddRange(temp);
                //}
                //temp = new List<TrafficLane>();
                //if (i.Lanes.Find(x => x.ID == 2).LaneType == null)
                //{
                //    temp = Crossings.Find(x => x.CrossingId == i.CrossingId + 4).LanesInDirection(Direction.NORTH);
                //    i.Lanes.Find(x => x.ID == 2).Lanes.AddRange(temp);
                //}
                //temp = new List<TrafficLane>();
                //if (i.Lanes.Find(x => x.ID == 3).LaneType == null)
                //{
                //    temp = Crossings.Find(x => x.CrossingId == i.CrossingId - 1).LanesInDirection(Direction.EAST);
                //    i.Lanes.Find(x => x.ID == 3).Lanes.AddRange(temp);
                //}
                //for loop
                //for (int j = 0; j < 4; j++)
                //{
                //    if (i.Lanes.ElementAt(j).LaneType==null)
                //    {
                //        if (j==0)
                //        {
                //            List<TrafficLane> temp = new List<TrafficLane>();
                //            temp = Crossings.Find(x => x.CrossingId == i.CrossingId - 4).LanesInDirection(Direction.NORTH);
                //            i.Lanes.ElementAt(j).Lanes.AddRange(temp);
                //            temp = null;
                //        }
                //        else if (j == 1)
                //        {
                //            List<TrafficLane> temp2 = new List<TrafficLane>();
                //            temp2 = Crossings.Find(x => x.CrossingId == i.CrossingId + 1).LanesInDirection(Direction.EAST);
                //            i.Lanes.ElementAt(j).Lanes.AddRange(temp2);
                //            temp2 = null;
                //        }
                //        else if (j == 2)
                //        {
                //            List<TrafficLane> temp3 = new List<TrafficLane>();
                //            temp3 = Crossings.Find(x => x.CrossingId == i.CrossingId + 4).LanesInDirection(Direction.SOUTH);
                //            i.Lanes.ElementAt(j).Lanes.AddRange(temp3);
                //            temp3 = null;
                //        }
                //        else if (j == 3)
                //        {
                //            List<TrafficLane> temp4 = new List<TrafficLane>();
                //            temp4 = Crossings.Find(x => x.CrossingId == i.CrossingId - 1).LanesInDirection(Direction.WEST);
                //            i.Lanes.ElementAt(j).Lanes.AddRange(temp4);
                //            temp4 = null;
                //        }
                //    }
                //}
                //foreach
                foreach (TrafficLane j in i.Lanes)
                {
                    if (!(j.ToFromCross) && (j.LaneType == null))
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
            Console.Write("");
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
                cr1.CreatePedestrians();
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
        }

<<<<<<< HEAD
        public Crossing getCrossing(int id)
        {
            return Crossings.Find(x => x.CrossingId == (id));
        }
=======
        public bool checkCarStatus()
        {
            bool done = true;
            foreach (Crossing i in Crossings)
            {
                if (i.GetType()==typeof(Crossing_B))
                {
                    Crossing_B temp = (Crossing_B)i;
                    if (temp.pedestrians.Count>0)
                    {
                        done = false;
                    }
                }
                foreach (TrafficLane j in i.Lanes)
                {
                    if (j.Cars.Count>0)
                    {
                        done = false;
                    }
                }
            }
            return done;
        }

>>>>>>> origin/Driving-Methods
    }
}
