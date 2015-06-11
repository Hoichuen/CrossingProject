using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;


namespace ProCP
{
    
    class Simulation
    {
        public int TotalNumberCars { get; set; }
        int TotalNumberPedestrians { get; set; }
        System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();

        private List<Crossing> crossings;
        private Car car;
        private List<Car> cars;
        private bool saved;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Saved
        {
            get { return saved; }
            set { saved = value; }
        }

        public List<Crossing> Crossings
        {
            get { return crossings; }
            set { crossings = value; }
        }

        public Simulation(string name = "")
        {
            Crossings = new List<Crossing>();
            Name = name;
            Saved = true;
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
            Watch.Start();
            CreateCars();
        }
        public void Stop() { Watch.Stop(); }

        public bool AddCrossing(Crossing Crossing)
        {
            if (Crossings.Count < 12)
            {
                Crossings.Add(Crossing);
                Saved = false;
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
                if (Crossings.Find(x => x.CrossingId == (i.CrossingId) + 1) == null || (i.CrossingId % 4 == 0))
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

                if (Crossings.Find(x => x.CrossingId == (i.CrossingId) - 1) == null || (i.CrossingId % 4 == 1))
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
        }

        public void EditCrossing(int id, int numCars, int time, string style)
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
                cr1.style = style;
                cr1.CreatePedestrians();
            }

        }

        private int whichPedStyle(string style)
        {
            if (style == "Quiet") return 1;
            if (style == "Busy") return 2;
            else return -1; 
        }

        public void getProperties(int id, ref int nCars, ref int time, ref string style)
        {
            Crossing cr = Crossings.Find(x => x.CrossingId == (id));

            nCars = cr.NumCars;
            time = cr.Time.Seconds;

            if (cr.GetType() == typeof(Crossing_B))
            {
                Crossing_B cr1 = (Crossing_B)cr;
                //nPed = cr1.NumPeds;
                style = cr1.style;
            }

        }

        public bool CrossingExist(int id)
        {
            return Crossings.Exists(x => x.CrossingId == (id));
        }

        public void RemoveCrossing(int id)
        {
            Crossings.Remove(Crossings.Find(x => x.CrossingId == (id)));
            Saved = false;
        }

        public void CreateCars()
        {
            cars = new List<Car>();
            List<TrafficLane> tmp = new List<TrafficLane>();
            Random rnd = new Random();
            Color c;
            int count=1;

            foreach (Crossing item in Crossings)
            {
                tmp.AddRange(item.Lanes.FindAll(x => x.LaneType == true));

                for (int i = 0; i < item.NumCars; i++)
                {
                    c = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                    
                    // car = new Car(count, c, item); // DEBUG
                    car = new Car(count, c, tmp.ElementAt(rnd.Next(tmp.Count())));

                    cars.Add(car);
                    count++;
                }
                tmp = new List<TrafficLane>();
                /*
                for (int i = 0; i < item.NumCars; i++)
                {
                    Random random = new Random();
                    car = new Car(count, Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)), tmp.ElementAt(rnd.Next(tmp.Count())));
                    cars.Add(car);
                    count++;
                }
                */
            }
        }

        public Crossing getCrossing(int id)
        {
            return Crossings.Find(x => x.CrossingId == (id));
        }

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

        /// <summary>
        /// Save the simulation to a file
        /// </summary>
        /// <param name="filename">The name of the file to which to save the simulation</param>
        public void SaveAs(string filename)
        {
            Saved = true;

            FileStream writer = new FileStream(filename, FileMode.Create);
            DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(Simulation));
            dataContractSerializer.WriteObject(writer, this);
            

            writer.Close();
        }

        /// <summary>
        /// Returns true when loaded, passes new loaded BaseBate list to the exisiting BaseGate list.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Simulation Load(string filename)
        {
            Simulation ret;

            FileStream fs = new FileStream(filename, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(Simulation));
            ret = (Simulation)ser.ReadObject(reader, true);

            reader.Close();
            fs.Close();

            return ret;
        }

        public bool Surrounded(int id)
        {
            if ((crossings.Exists(x => x.CrossingId == id - 4)) && ((crossings.Exists(x => x.CrossingId == id - 1) || (crossings.Find(x=>x.CrossingId == id).CrossingId % 4 == 1)))
                && (crossings.Exists(x => x.CrossingId == id + 4)) && ((crossings.Exists(x => x.CrossingId == id + 1) || (crossings.Find(x => x.CrossingId == id).CrossingId % 4 == 0))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
