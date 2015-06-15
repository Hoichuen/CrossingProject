using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;
namespace ProCP
{
    [DataContract(Name = "Lane")]
    class Lane
    {
        //Fields
        int iD;
        List<Point> points;

        //Properties
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        /// <summary>
        /// List of points the cars use
        /// </summary>
        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Constructor of the Lane class for the ped lane
        /// </summary>
        public Lane(int iD, List<Point> points)
        {
            this.ID = iD++;
            this.Points = points;
        }

        /// <summary>
        /// Constructor of the Lane class for the traffic lane
        /// </summary>
        /// <param name="iD"></param>
        public Lane(int iD)
        {
            this.ID = iD++;
        }

        //Methods

        /// <summary>
        /// Returns the crossing this lane is on
        /// </summary>
        /// <returns></returns>
        public Crossing GetCrossing()
        {
            return null;
        }
    }
}
