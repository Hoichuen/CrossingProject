using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProCP
{
    public partial class Form1 : Form
    {
        const int PICTUREBOX_ORIGINAL_WIDTH = 448;
        const int PICTUREBOX_ORIGINAL_HEIGHT = 306;
        PictureBox selectedPicBox = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void togglePictureBoxSelection(PictureBox pBox)
        {
            if (null != selectedPicBox) {
                applyStylesToPicBox(selectedPicBox, false);
                selectedPicBox = null;
                applyStylesToPicBox(pBox, false);
            }

            selectedPicBox = pBox;
            applyStylesToPicBox(pBox, true);
        }

        /*
         * Just for testing, needs to define how the picture box 
         * will look like when selected.
         */
        private void applyStylesToPicBox(PictureBox pBox, Boolean selected)
        {
            if (selected)
            {
                pBox.Width = 150;
                return;
            }

            pBox.Width = PICTUREBOX_ORIGINAL_WIDTH;
        }

        private void pictureBoxOnClick(object sender, EventArgs e)
        {
            PictureBox self = (PictureBox) sender;
            togglePictureBoxSelection(self);
            return;
        }
    }
}
