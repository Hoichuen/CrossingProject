using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProCP
{
    class Crossing_B:Crossing
    {
        public List<PedestrianLane> pLanes;
        public List<Pedestrian> pedestrians;
        public string style;
        List<TrafficLane> lanes;
        List<TrafficLane> tLanes;

        int numPeds;

        public int NumPeds
        {
            get { return numPeds; }
            set { numPeds = value; }
        }

        /// <summary>
        /// The crossing type B constructor
        /// </summary>
        public Crossing_B(int crossingId, Point position) : base(crossingId, position)
        {
            this.NumPeds = 0;

            lanes = new List<TrafficLane>();
            tLanes = new List<TrafficLane>();
            Light lightNORTH = new Light(Time, false);
            Light lightEAST = new Light(Time, false);
            Light lightSOUTH = new Light(Time, false);
            Light lightWEST = new Light(Time, false);


            for (int i = 0; i < 4; i++)
            {
                lanes.Add(new TrafficLane(i, false, (Direction)i, null, tLanes, this));
                tLanes = new List<TrafficLane>();
            }

            //Adding the list of lanes that a certain lane can go to, as well as creating the lanes.

            //For South
            tLanes.Add(lanes.ElementAt(2));
            lanes.Add(new TrafficLane(4, true, Direction.SOUTH, lightSOUTH, tLanes, this));
            tLanes = new List<TrafficLane>();

            //For West
            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(0), lanes.ElementAt(3) });
            lanes.Add(new TrafficLane(5, true, Direction.WEST, lightWEST, tLanes, this));
            tLanes = new List<TrafficLane>();
            
            tLanes.Add(lanes.ElementAt(2));
            lanes.Add(new TrafficLane(6, true, Direction.WEST, lightWEST, tLanes, this));
            tLanes = new List<TrafficLane>();

            //For North
            tLanes.Add(lanes.ElementAt(0));
            lanes.Add(new TrafficLane(7, true, Direction.NORTH, lightNORTH, tLanes, this));
            tLanes = new List<TrafficLane>();

            //For East
            tLanes.AddRange(new TrafficLane[] { lanes.ElementAt(1), lanes.ElementAt(2) });
            lanes.Add(new TrafficLane(8, true, Direction.EAST, lightEAST, tLanes, this));
            tLanes = new List<TrafficLane>();

            tLanes.Add(lanes.ElementAt(0));
            lanes.Add(new TrafficLane(9, true, Direction.EAST, lightEAST, tLanes, this));
            tLanes = new List<TrafficLane>();

            base.Lanes.AddRange(lanes);

            //Adding the list of pedestrians
            pedestrians = new List<Pedestrian>();
            //Adding the pedestrian lane list and the pedestrian lights
            pLanes = new List<PedestrianLane>();
            //top lane
            PedestrianLight pLight = new PedestrianLight(0, new TimeSpan(), false, false);//this needs to be fixed after we figure out the timings
            pLanes.Add(new PedestrianLane(1, CalculatePedestrianLanePoints(1), false, pLight));
            //bottom lane
            pLight = new PedestrianLight(0, new TimeSpan(), false, false);
            pLanes.Add(new PedestrianLane(2, CalculatePedestrianLanePoints(2), false, pLight));
            
        }
        private List<Point> CalculatePedestrianLanePoints(int ID)
        {
            ///225;160
            /// /4 = rows to add %4 column
            List<Point> points = new List<Point>();
            int row, column, x, y;
            row = this.CrossingId / 4;
            column = (this.CrossingId % 4) - 1;
            x = column * 225; y = row * 160;
            if (ID == 1)//for the top lane;
            {

                for (int i = 0; i < 4; i++)
                {
                    points.Add(new Point(x + 45, y + 20));
                    x += 45;

                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    points.Add(new Point(x + 45, y + 135));
                    x += 45;

                }
            }
            return points;
        }
        public void CreatePedestrians()
        {
            for (int i = 0; i < numPeds; i++)
            {
                pedestrians.Add(new Pedestrian(i, Color.Black, 1, this)); //pedid and color are not needed as far as i can see 
                // but i left them just in case
            }
        }
        /// <summary>
        /// Calculates how many pedestrians need to move
        /// </summary>
        public int GetNumberOfPedesToMove()
        {
            if (style == "Busy")
            {
                if (pedestrians.Count >= 20)
                    return 20;
                else return pedestrians.Count;
            }
            else
            {
                if (pedestrians.Count >= 5)
                    return 5;
                else return pedestrians.Count;
            }
        }
    }
}
