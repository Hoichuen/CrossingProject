using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ProCP
{
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
<<<<<<< HEAD
        /// <param name="iD"></param>
        /// <param name="points"></param>
=======
        public bool IsFull
        {
            get { return isFull; }
            set { isFull = value; }
        }

        //Constructor
>>>>>>> origin/master
        public Lane(int iD, List<Point> points)
        {
            this.ID = iD++;
            this.Points = points;
<<<<<<< HEAD
=======

          
>>>>>>> origin/master
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
