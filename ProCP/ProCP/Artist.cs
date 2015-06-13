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
        private const int NUM_TRAFFIC_LIGHTS_A = 8;
        private const int NUM_TRAFFIC_LIGHTS_B = 6;
        private const int NUM_TRAFFIC_LIGHTS_SPOTS = 3;

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_A = { 51, 58, 160, 160, 160, 167, 42, 42 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_A = { 30, 30, 37, 42, 112, 112, 112, 117 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B = { 55, 159, 159, 156, 41, 41 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B = { 0, 36, 41, 142, 111, 116 };

        PaintEventArgs painter;

        public Artist(PaintEventArgs e)
        {
            painter = e;
        }

        #region Lights

        public void drawLightStructureCrossingA()
        {
            drawLightStructure(typeof(Crossing_A));
        }

        public void drawLightStructureCrossingB()
        {
            drawLightStructure(typeof(Crossing_B));
        }

        public void drawLightStructure(System.Type t)
        {
            int[] xSpots = new int[8];
            int[] ySpots = new int[8];
            int totalTrafficLights = NUM_TRAFFIC_LIGHTS_A;

            LIGHT_STRUCT_X_SPOTS_CROSSING_A.CopyTo(xSpots, 0);
            LIGHT_STRUCT_Y_SPOTS_CROSSING_A.CopyTo(ySpots, 0);

            // Pre-draw
            if (t.Equals(typeof(Crossing_B)))
            {
                LIGHT_STRUCT_X_SPOTS_CROSSING_B.CopyTo(xSpots, 0);
                LIGHT_STRUCT_Y_SPOTS_CROSSING_B.CopyTo(ySpots, 0);

                totalTrafficLights = NUM_TRAFFIC_LIGHTS_B;
            }

            for (int i = 0; i < totalTrafficLights; i++)
            {
                for (int j = 0; j < NUM_TRAFFIC_LIGHTS_SPOTS; j++)
                {
                    if (isNextTrafficLightVertical(t, i))
                    {
                        drawEmptyRect(
                            LIGHT_STRUCTURE_COLOR,
                            xSpots[i],
                            ySpots[i] + (j * TRAFFIC_LIGHT_BOX_HEIGHT),
                            TRAFFIC_LIGHT_BOX_WIDTH,
                            TRAFFIC_LIGHT_BOX_HEIGHT);
                    }
                    else
                    {
                        drawEmptyRect(
                            LIGHT_STRUCTURE_COLOR,
                            xSpots[i] + (j * TRAFFIC_LIGHT_BOX_WIDTH),
                            ySpots[i],
                            TRAFFIC_LIGHT_BOX_WIDTH,
                            TRAFFIC_LIGHT_BOX_HEIGHT);
                    }
                }
            }
        }

        private bool isNextTrafficLightVertical(System.Type t, int index)
        {
            if (t.Equals(typeof(Crossing_A)))
            {
                switch (index)
                {
                    case 0:
                    case 1:
                    case 4:
                    case 5:
                        return true;
                }
            }

            if ((t.Equals(typeof(Crossing_B))) && (index == 0 || index == 3))
                return true;

            return false;
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
