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

        private const int LIGHT_BOX_WIDTH = 7;
        private const int LIGHT_BOX_HEIGHT = 5;

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_A = { 51, 58, 160, 160, 160, 167, 42, 42 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_A = { 30, 30, 37, 42, 112, 112, 112, 117 };

        private readonly int[] LIGHT_STRUCT_X_SPOTS_CROSSING_B = { 51, 58, 160, 160, 160, 167, 42, 42 };
        private readonly int[] LIGHT_STRUCT_Y_SPOTS_CROSSING_B = { 30, 30, 37, 42, 112, 112, 112, 117 };

        PaintEventArgs painter;

        public Artist(PaintEventArgs e)
        {
            painter = e;
        }

        #region Lights

        public void drawLightBaseCrossingB()
        {
            drawLightStructureCrossingA();
        }

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

            LIGHT_STRUCT_X_SPOTS_CROSSING_A.CopyTo(xSpots, 0);
            LIGHT_STRUCT_Y_SPOTS_CROSSING_A.CopyTo(ySpots, 0);

            // Pre-draw
            if (t.Equals(typeof(Crossing_B)))
            {
                LIGHT_STRUCT_X_SPOTS_CROSSING_B.CopyTo(xSpots, 0);
                LIGHT_STRUCT_X_SPOTS_CROSSING_B.CopyTo(ySpots, 0);
            }

            bool vertical = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (vertical) {
                        drawEmptyRect(
                            LIGHT_STRUCTURE_COLOR,
                            xSpots[i],
                            ySpots[i] + (j * 5),
                            LIGHT_BOX_WIDTH,
                            LIGHT_BOX_HEIGHT);
                    }
                    else
                    {
                        drawEmptyRect(
                            LIGHT_STRUCTURE_COLOR,
                            xSpots[i] + (j * 7),
                            ySpots[i],
                            LIGHT_BOX_WIDTH,
                            LIGHT_BOX_HEIGHT);
                    }
                }

                if (i % 2 != 0)
                {
                    if (vertical)
                        vertical = false;
                    else
                        vertical = true;
                }
            }
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
