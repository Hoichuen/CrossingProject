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
       
       
        public Form1()
        {
            
            InitializeComponent();
            pictureBox1.AllowDrop = true;
            pictureBox2.AllowDrop = true;
            pictureBox3.AllowDrop = true;
            pictureBox4.AllowDrop = true;
            pictureBox5.AllowDrop = true;
            pictureBox6.AllowDrop = true;
            pictureBox7.AllowDrop = true;
            pictureBox8.AllowDrop = true;
            pictureBox9.AllowDrop = true;
            pictureBox10.AllowDrop = true;
            pictureBox11.AllowDrop = true;
            pictureBox12.AllowDrop = true;
            pictureBox13.AllowDrop = true;
            pictureBox14.AllowDrop = true;
            pictureBox15.AllowDrop = true;
            pictureBox16.AllowDrop = true;
        }
        private void pictureBox17_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox17.DoDragDrop(pictureBox17.Image,DragDropEffects.Copy);
         
        }
        void pictureBox18_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            pictureBox17.DoDragDrop(pictureBox18.Image, DragDropEffects.Copy);
        }
        void pictureBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox1.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox2_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox2_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox2.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox3_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox3_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox3.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox4_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox4_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox4.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox5_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox5_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox5.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox6_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox6_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox6.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox7_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox7_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox7.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox8_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox8_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox8.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox9_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox9_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox9.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox10_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox10_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox10.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox11_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox11_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox11.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox12_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox12_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox12.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox13_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox13_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox13.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox14_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox14_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox14.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox15_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox15_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox15.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
        void pictureBox16_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        void pictureBox16_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            pictureBox16.Image = e.Data.GetData(DataFormats.Bitmap) as Image;
        }
    }
}
