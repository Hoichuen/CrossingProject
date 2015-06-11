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
    public partial class AboutGUI : Form
    {
        public AboutGUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// writes the info when the form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutGUI_Load(object sender, EventArgs e)
        {
            string lineBreak = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            string programmers = "\nJoao Barbosa\nJean Chan\nDragan Draganov\nLoic Motheu\nBen Umbach";

            this.rTBAbout.AppendText(lineBreak+"\nTraffic Simulator\n\n   Version 1.0\n\n\tThis product is licensed under the Mircosoft Software License Terms to:\n\n\t\tGroup E:"+programmers+"\n"+lineBreak);
        }
    }
}
