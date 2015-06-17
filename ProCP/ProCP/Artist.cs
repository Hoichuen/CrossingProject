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
        private const int CAR_WIDTH = 13;
        private const int CAR_HEIGHT = 10;

        private readonly Color LIGHT_STRUCTURE_COLOR = Color.Black;

        private const int TRAFFIC_LIGHT_BOX_WIDTH = 7;
        private const int TRAFFIC_LIGHT_BOX_HEIGHT = 5;
        private const int TRAFFIC_LIGHT_WIDTH = 6;
        private const int TRAFFIC_LIGHT_HEIGHT = 4;
        private const int NUM_TRAFFIC_LIGHTS_A = 8;
        private const int NUM_TRAFFIC_LIGHTS_B = 6;
        private const int NUM_TRAFFIC_LIGHTS_SPOTS = 3;

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_A = { 51, 58, 160, 160, 160, 167, 42, 42 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_A = { 30, 30, 37, 42, 112, 112, 117, 112 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B = { 55, 159, 159, 156, 41, 41 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B = { 0, 36, 41, 142, 111, 116 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B_PEDS = { 52, 157, 52, 157 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B_PEDS = { 30, 28, 126, 124 };

        PaintEventArgs painter;

        public Artist(PaintEventArgs e)
        {
            painter = e;
        }

        #region Lights

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

        #endregion

        #region Cars

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

        private void drawEmptyRect(Color c, int x, int y, int w, int h)
        {
            painter.Graphics.DrawRectangle(new Pen(c, 1), x, y, w, h);
        }

        #endregion

        public void paintSelectionOutline()
        {
            painter.Graphics.DrawRectangle(new Pen(Color.Red, 3), 1, 1, 220, 155);
        }
    }
}
