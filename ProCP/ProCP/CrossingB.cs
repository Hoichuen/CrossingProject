using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace ProCP
{
    [DataContract(Name = "Crossing_B")]
    class Crossing_B : Crossing
    {
        public List<PedestrianLane> pLanes;
        public List<Pedestrian> pedestrians;
        public string style;
        List<TrafficLane> lanes;
        List<TrafficLane> tLanes;
        int numpeds;

        /// <summary>
        /// Total number of pedestrians for current crossing of type B
        /// </summary>
        public int NumPeds
        {
            get { return numpeds; }
            set { numpeds = value; }
        }

        /// <param name="crossingId">The Id of the crossing</param>
        /// <param name="position"></param>
        public Crossing_B(int crossingId)
            : base(crossingId)
        {


            lanes = new List<TrafficLane>();
            tLanes = new List<TrafficLane>();
            Light lightNORTH = new Light(false);
            Light lightEAST = new Light(false);
            Light lightSOUTH = new Light(false);
            Light lightWEST = new Light(false);


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
            PedestrianLight pLight = new PedestrianLight(false, false);

            pLanes.Add(new PedestrianLane(1, CalculatePedestrianLanePoints(1), pLight, this));
            //bottom lane
            pLight = new PedestrianLight(false, false);

            pLanes.Add(new PedestrianLane(2, CalculatePedestrianLanePoints(2), pLight, this));

        }
        /// <summary>
        /// Calculates the points for pedestrian lanes
        /// </summary>
        /// <param name="ID">which lane is it (top or bot)</param>
        /// <returns></returns>
        private List<Point> CalculatePedestrianLanePoints(int ID)
        {

            List<Point> points = new List<Point>();
            int row, column, x, y;
            row = this.CrossingId / 4;
            column = (this.CrossingId % 4) - 1;
            x = column * 225; y = row * 160;

            int tempX = 0;
            int tempY = 0;

            if (ID == 1)//this is for the top lane
            {
                for (int i = 0; i < 4; i++)
                {
                    points.Add(new Point(tempX + 45, tempY + 20));
                    tempX += 45;
                }
            }
            else //this is for the bottom
            {
                for (int i = 0; i < 4; i++)
                {
                    points.Add(new Point(tempX + 45, tempY + 135));
                    tempX += 45;
                }
            }
            return points;
        }
        /// <summary>
        /// A method that creates a number of pedestrians based on the crossing style
        /// </summary>
        public void CreatePedestrians()
        {
            int howMany = 0;
            if (style == "Quiet") howMany = 15; if (style == "Busy") howMany = 50;
            for (int i = 0; i < howMany; i++)
            {
                pedestrians.Add(new Pedestrian(i, this));
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
