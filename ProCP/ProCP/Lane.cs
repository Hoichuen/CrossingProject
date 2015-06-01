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
        bool isFull;
        List<Point> points;

        //Properties
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public List<Point> Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Are all the points filled on the lane?
        /// </summary>
        public bool IsFull
        {
            get { return isFull; }
            set { isFull = value; }
        }


        //Constructor
        public Lane(int iD, List<Point> points, bool isFull)
        {
            this.ID = iD++;
            this.Points = new List<Point>();
            this.IsFull = IsFull;
            //Need to figure out the lists
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
