using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP
{
    class Artist
    {
		/// <summary>
		/// Car dimensions
		/// </summary>
        private const int CAR_WIDTH = 13;
        private const int CAR_HEIGHT = 10;

		/// <summary>
		/// Pedestrian Dimensions
		/// </summary>
        private const int PED_WIDTH = 7;
        private const int PED_HEIGHT = 7;

		/// <summary>
		/// Light structure color
		/// </summary>
        private readonly Color LIGHT_STRUCTURE_COLOR = Color.Black;

		/// <summary>
		/// Traffic light size
		/// </summary>
        private const int TRAFFIC_LIGHT_BOX_WIDTH = 7;
        private const int TRAFFIC_LIGHT_BOX_HEIGHT = 5;
        private const int TRAFFIC_LIGHT_WIDTH = 6;
        private const int TRAFFIC_LIGHT_HEIGHT = 4;

		/// <summary>
		/// Number of traffic lights 
		/// </summary>
        private const int NUM_TRAFFIC_LIGHTS_A = 8;
        private const int NUM_TRAFFIC_LIGHTS_B = 6;
        private const int NUM_TRAFFIC_LIGHTS_SPOTS = 3;


		/// <summary>
		/// Points about traffic and pedestrian lights
		/// </summary>
        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_A = { 51, 58, 160, 160, 160, 167, 42, 42 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_A = { 30, 30, 37, 42, 112, 112, 117, 112 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B = { 55, 159, 159, 156, 41, 41 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B = { 0, 36, 41, 142, 111, 116 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS = { 52, 157, 52, 157 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS = { 30, 28, 126, 124 };

        PaintEventArgs painter;

		/// <summary>
		/// Constructor
		/// </summary>
        public Artist(PaintEventArgs e)
        {
            painter = e;
        }

        #region Lights

		/// <summary>
		/// Draw traffic lights
		/// </summary>
		/// <param name="lane">Traffic Lane</param>
		/// <param name="state">Current state of the traffic light</param>
        public void drawTrafficLight(TrafficLane lane, bool state)
        {
            Rectangle r;
            SolidBrush brush = new SolidBrush(Color.Red);

            if (state)
                brush.Color = Color.Green;

            Point point = getCoordinatesForTrafficLight(lane, state);

            r = new Rectangle(point.X, point.Y, TRAFFIC_LIGHT_WIDTH, TRAFFIC_LIGHT_HEIGHT);

            painter.Graphics.FillRectangle(brush, r);
		}

		/// <summary>
		/// Get the coordinates to draw the traffic lights
		/// </summary>
		/// <param name="lane">Traffic Lane</param>
		/// <param name="state">Current state of the traffic light</param>
		/// <returns>Point with the correct coordinates</returns>
        private Point getCoordinatesForTrafficLight(TrafficLane l, bool state)
        {
            Crossing c = l.Parent;
            bool isVertical = false;
            int x = 0;
            int y = 0;

            if (c is Crossing_A)
            {
                x = LIGHT_STRUCT_X_SPOTS_CROSSING_A[l.ID - 4] + 1;
                y = LIGHT_STRUCT_Y_SPOTS_CROSSING_A[l.ID - 4] + 1;

                switch (l.ID)
                {
                    case 4:
                    case 5:
                    case 8:
                    case 9:
                        isVertical = true;
                        break;
                    default:
                        isVertical = false;
                        break;
                }
            }
            else
            {
                x = LIGHT_STRUCT_X_SPOTS_CROSSING_B[l.ID - 4] + 1;
                y = LIGHT_STRUCT_Y_SPOTS_CROSSING_B[l.ID - 4] + 1;

                switch (l.ID)
                {
                    case 4:
                    case 7:
                        isVertical = true;
                        break;
                    default:
                        isVertical = false;
                        break;
                }
            }

            if (state)
            {
                if (isVertical) {
                    y += TRAFFIC_LIGHT_BOX_HEIGHT * 2;
                }
                else
                {
                    x += TRAFFIC_LIGHT_BOX_WIDTH * 2;
                }
            }

            return new Point(x, y);
        }

		/// <summary>
		/// Draws pedestrian lights
		/// </summary>
		/// <param name="lane">Pedestrian Lane</param>
		/// <param name="state">Current state of the pedestrian light</param>
        public void drawPedestrianLight(PedestrianLane lane, bool state)
        {
            Rectangle r;
            SolidBrush brush = new SolidBrush(Color.Red);

            if (state)
                brush.Color = Color.Green;

            Point[] points = getCoordinatesForPedestrianLights(lane, state);

            foreach (Point p in points)
            {
                r = new Rectangle(p.X, p.Y, TRAFFIC_LIGHT_WIDTH, TRAFFIC_LIGHT_HEIGHT);

                painter.Graphics.FillRectangle(brush, r);
            }
        }
			
		/// <summary>
		/// Get coordinates to draw pedestrian lights
		/// </summary>
		/// <param name="lane">Pedestrian Lane</param>
		/// <param name="state">Current state of the pedestrian light</param>
		/// <returns>List of Points with the correct coordinates</returns>
        private Point[] getCoordinatesForPedestrianLights(PedestrianLane l, bool state)
        {
            Point[] points = new Point[2];
            int x = 0;
            int y = 0;
            int x2 = 0;
            int y2 = 0;

            if (l.ID == 1)
            {
                x = LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS[0];
                x2 = LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS[1];

                y = LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS[0];
                y2 = LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS[1];
            }
            else
            {
                x = LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS[2];
                x2 = LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS[3];

                y = LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS[2];
                y2 = LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS[3];
            }

            if (state)
            {
                x += 7;
                x2 += 7;
            }

            points[0] = new Point(x, y);
            points[1] = new Point(x2, y2);

            return points;
        }
			
		/// <summary>
		/// Draw pedestrians
		/// </summary>
		/// <param name="lane">Traffic Lane</param>
		/// <param name="state">Current state of the traffic light</param>
		/// <returns>Point with the correct coordinates</returns>
        public void drawPedestrians(PedestrianLane lane, string pStyle) {
            Rectangle r;
            SolidBrush brush;
            Color c;
            Random random = new Random();

            foreach (Point p in lane.Points)
            {
                switch (random.Next(4))
                {
                    case 1:
                        c = Color.Red;
                        break;
                    case 2:
                        c = Color.Blue;
                        break;
                    default: 
                        c = Color.Orange;
                        break;
                }

                brush = new SolidBrush(c);
                r = new Rectangle(p.X, p.Y, PED_WIDTH, PED_HEIGHT);
                painter.Graphics.FillRectangle(brush, r);
            }
        }

        #endregion

        #region Cars

		/// <summary>
		/// Draw cars
		/// </summary>
		/// <param name="c">Car instance</param>
		/// <param name="d">Direction the car is heading to</param>
		public void drawCar(Car c, Direction d)
        {
            Rectangle r;
            SolidBrush brush = new SolidBrush(c.Color);

            if (d == Direction.WEST || d == Direction.EAST)
                r = new Rectangle(c.CurPoint.X, c.CurPoint.Y, CAR_WIDTH, CAR_HEIGHT);
            else
                r = new Rectangle(c.CurPoint.X, c.CurPoint.Y, CAR_HEIGHT, CAR_WIDTH);

            painter.Graphics.FillRectangle(brush, r);
        }

        #endregion

        #region General-use Methods

		/// <summary>
		/// Draw empty rectangles
		/// </summary>
		/// <param name="c">Color to draw</param>
		/// <param name="x">X axis</param>
		/// <param name="y">Y axis</param>
		/// <param name="w">Width</param>
		/// <param name="h">Height</param>
        private void drawEmptyRect(Color c, int x, int y, int w, int h)
        {
            painter.Graphics.DrawRectangle(new Pen(c, 1), x, y, w, h);
        }

        #endregion

		/// <summary>
		/// Draw the outline when selecting a cross
		/// </summary>
        public void paintSelectionOutline()
        {
            painter.Graphics.DrawRectangle(new Pen(Color.Red, 3), 1, 1, 220, 155);
        }
    }
}
