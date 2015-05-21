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
        PictureBox selectedPicBox = null;

        /// <summary>
        /// A list of controls
        /// </summary>
        List<Control> ControlList = new List<Control>();
        Crossing CurrentCrossing;
        Simulation Simulation;

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
                // Styles... 
                return;
            }

            // Styles...
        }

        private void pictureBoxOnClick(object sender, EventArgs e)
        {
            PictureBox self = (PictureBox) sender;
            togglePictureBoxSelection(self);

            return;
        }

        private void removeCrossing(object sender, EventArgs e) {
            if (null == selectedPicBox) {
                MessageBox.Show(
                    "Please, select a crossing before removing it.",
                    "No crossing selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (null == selectedPicBox.Image) {
                MessageBox.Show(
                    "Please, add a crossing to this space before removing it.",
                    "There is no crossing in this tile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            throw new NotImplementedException();
        }
    }
}
