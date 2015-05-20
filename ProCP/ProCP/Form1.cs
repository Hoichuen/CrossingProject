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
        /// <summary>
        /// A list of controls
        /// </summary>
        List<Control> ControlList = new List<Control>();
        Crossing CurrentCrossing;
        Simulation Simulation;
        
        
        public Form1()
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
                case "pictureBox1": return 1;
                case "pictureBox2": return 2;
                case "pictureBox3": return 3;
                case "pictureBox4": return 4;
                case "pictureBox5": return 5;
                case "pictureBox6": return 6;
                case "pictureBox7": return 7;
                case "pictureBox8": return 8;
                case "pictureBox9": return 9;
                case "pictureBox10": return 10;
                case "pictureBox11": return 11;
                case "pictureBox12": return 12;
                case "pictureBox13": return 13;
                case "pictureBox14": return 14;
                case "pictureBox15": return 15;
                case "pictureBox16": return 16;
                default:return 0;

            
            }
        }
        /// <summary>
        /// Adds the drag/drop events and makes the pictureboxes allowing drop
        /// </summary>
        private void AddDragDropToPictureBoxes()
        {
            pictureBox17.MouseDown += pictureBox17_MouseDown;
            pictureBox18.MouseDown += pictureBox18_MouseDown;
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
                self.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
              if ((Image)e.Data.GetData(DataFormats.Bitmap) == pictureBox17.Image)
              {
                  Simulation.AddCrossing(new Crossing_A(GetNumberOfPicturebox(self),
                                                      new Point(self.Location.X, self.Location.Y)));
              }
              else {
                  Simulation.AddCrossing(new Crossing_B(GetNumberOfPicturebox(self),
                                                         new Point(self.Location.X, self.Location.Y)));
              }
            }
            else MessageBox.Show("Remove the crossing first to be able to add another one on this tile",
                "There is already a crossing there");
        }

        void pictureBox18_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(pictureBox18.Image, DragDropEffects.Copy);
        }

        void pictureBox17_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(pictureBox17.Image, DragDropEffects.Copy);
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Simulation.MarkLanes();
            Simulation.LaneCrossingConnection();
        }

    }
}
