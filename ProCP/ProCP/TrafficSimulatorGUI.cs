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
    public partial class TrafficSimulatorGUI : Form
    {
        bool debug = true;

        /// <summary>
        /// A list of controls
        /// </summary>
        List<Control> ControlList = new List<Control>();
        PictureBox selectedPicBox = null;
        Crossing CurrentCrossing;
        Simulation Simulation;

        int selectedID;
        bool isLocked;

        public TrafficSimulatorGUI()
        {
            InitializeComponent();
            GetAllPictureboxes(panel1);
            AddDragDropToPictureBoxes();
            Simulation = new Simulation();

        }
        
        /// <summary>
        /// a method to populate the list of controls with pictureboxes
        /// </summary>
        /// <param name="container"></param>
        private void GetAllPictureboxes(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllPictureboxes(c);
                if (c is PictureBox) ControlList.Add(c);
            }
        }
        
        private int GetNumberOfPicturebox(PictureBox self)
        {
            switch (self.Name)
            {
                case "crossingGrid1": return 1;
                case "crossingGrid2": return 2;
                case "crossingGrid3": return 3;
                case "crossingGrid4": return 4;
                case "crossingGrid5": return 5;
                case "crossingGrid6": return 6;
                case "crossingGrid7": return 7;
                case "crossingGrid8": return 8;
                case "crossingGrid9": return 9;
                case "crossingGrid10": return 10;
                case "crossingGrid11": return 11;
                case "crossingGrid12": return 12;
                case "crossingGrid13": return 13;
                case "crossingGrid14": return 14;
                case "crossingGrid15": return 15;
                case "crossingGrid16": return 16;
                default:return 0;

            
            }
        }
        
        /// <summary>
        /// Adds the drag/drop events and makes the pictureboxes allowing drop
        /// </summary>
        private void AddDragDropToPictureBoxes()
        {
            crossingType1.MouseDown += crossingType1_MouseDown;
            crossingType2.MouseDown += crossingType2_MouseDown;
            
            foreach (Control c in ControlList )
            {
                c.AllowDrop = true;
                c.DragDrop += c_DragDrop;
                c.DragEnter += c_DragEnter;
            }
           
        }

        void c_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;                
        }

        void c_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox self = (PictureBox)sender;

            if (self.Image == null)
            {
                bool result = false;
                int picBoxNumber = GetNumberOfPicturebox(self);

                if ((Image)e.Data.GetData(DataFormats.Bitmap) == crossingType1.Image)
                {
                    result = Simulation.AddCrossing(new Crossing_A(picBoxNumber, new Point(self.Location.X, self.Location.Y)));
                }
                else 
                {
                    result = Simulation.AddCrossing(new Crossing_B(picBoxNumber, new Point(self.Location.X, self.Location.Y)));
                }

                if (result)
                    self.Image = (Image)e.Data.GetData(DataFormats.Bitmap);

                return;
            }
            
            MessageBox.Show("Remove the crossing first to be able to add another one on this tile", "There is already a crossing there");
        }

        void crossingType2_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(crossingType2.Image, DragDropEffects.Copy);
        }

        void crossingType1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(crossingType1.Image, DragDropEffects.Copy);  
        }

        private void togglePictureBoxSelection(PictureBox pBox)
        {
            if (null != selectedPicBox)
            {
                applyStylesToPicBox(selectedPicBox, false);
                selectedPicBox = null;
                applyStylesToPicBox(pBox, false);
            }

            selectedPicBox = pBox;
            applyStylesToPicBox(pBox, true);
        }

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
            int x = 1;
            int y = 2;
            int z = 3;

            PictureBox self = (PictureBox)sender;
            togglePictureBoxSelection(self);

            selectedID = GetNumberOfPicturebox(self);

            if (!Simulation.CrossingExist(selectedID))
            {
                selectedID = 0;
                MessageBox.Show("No crossing selected.");
                return;
            }

            if (!isLocked)
            {
                return;
            }

            if (self.Image == crossingType1.Image)
            {
                Simulation.getProperties(selectedID, ref x, ref y, ref z);
                numericCars.Value = x;
                numericTrafficTime.Value = y;
                numericPedestrians.Enabled = false;
            }
            else
            {
                Simulation.getProperties(selectedID, ref x, ref y, ref z);
                numericCars.Value = x;
                numericTrafficTime.Value = y;
                numericPedestrians.Value = z;
                numericPedestrians.Enabled = true;
            }

            return;
        }

        private void btnFinishCrossing_Click(object sender, EventArgs e)
        {
            Simulation.EditCrossing(selectedID, (int)numericCars.Value, (int)numericTrafficTime.Value, (int)numericPedestrians.Value);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (null == selectedPicBox)
            {
                MessageBox.Show(
                    "Please, select a crossing before removing it.",
                    "No crossing selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (null == selectedPicBox.Image)
            {
                MessageBox.Show(
                    "Please, add a crossing to this space before removing it.",
                    "There is no crossing in this tile",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            PictureBox picBox = selectedPicBox;

            picBox.Image = null;
            Simulation.RemoveCrossing(GetNumberOfPicturebox(picBox));
        }

        private void btLock_Click(object sender, EventArgs e)
        {
            Simulation.MarkLanes();
            Simulation.LaneCrossingConnection();
            isLocked = true;

            this.numericCars.Enabled = true;
            this.numericPedestrians.Enabled = true;
            this.numericTrafficTime.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Simulation.CreateCars();
        }

        private void pictureBoxOnPaint(object sender, PaintEventArgs e)
        {
            // enable/disable in the beginning of the class
            if (debug)
            {
                PictureBox self = (PictureBox)sender;
                int picBoxNum = GetNumberOfPicturebox(self);

                bool test = Simulation.CrossingExist(picBoxNum);

                if (Simulation.CrossingExist(picBoxNum))
                {
                    Crossing crossing = Simulation.getCrossing(picBoxNum);
                    List<TrafficLane> lanes = new List<TrafficLane>(crossing.Lanes);

                    foreach(TrafficLane t in lanes) 
                    {
                        foreach (Point p in t.Points)
                        {
                            e.Graphics.DrawEllipse(new Pen(Color.Red, 2), p.X, p.Y, 2, 2);
                        }
                    }
                }
            }
        }
    }
}
