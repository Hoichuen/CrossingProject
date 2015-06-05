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
    public partial class HelpGUI : Form
    {
        public HelpGUI()
        {
            InitializeComponent();
        }

        private void HelpGUI_Load(object sender, EventArgs e)
        {
            rTBHelp.Clear();

            string lineBreak = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n";
            string help = "\tSelect an item from the drop down list!";

            this.rTBHelp.AppendText(lineBreak+help+lineBreak+updateHelp(this.cBoxHelpItems.SelectedIndex));

        }

        public string updateHelp(int index)
        {
            this.cBoxHelpItems.SelectedIndex = index;

            switch (index)
            {
                //How to?
                case 0: return "How to use this application!";
                //Crossing types
                case 1: return "There are two crossing types.\nCrossing A: A 3x3 crossing.\nCrossing B: A 3x2 crossing with pedestrians.";
                //Crossing settings
                case 2: return "'Number of Cars': Amount of cars that will spawn at a crossing.\n'Green Time': Amount of green time for all lights on selected crossing.\n'Pedestrian Traffic': Quiet: A few pedestrian per red light.\nBusy: A lot of pedestrian per red light.";
                //Add Crossing
                case 3: return "Click desired crossing and drag and finally release on grid.";
                //Remove Crossing
                case 4: return "Select desire crossing and click remove.";
                //Lock Crossing
                case 5: return "Select desired crossing and edit the settings, by pressing this button you will save those values for the crossing.";
                //Lock Grid
                case 6: return "This locks the grid to make crossing settings available.";
                //Toggle Light
                case 7: return "Switches the state of the lights.";
                //Play Simulation
                case 8: return "Initiates the simulation.";
                //Stop Simulation
                case 9: return "Interrupts the Simulation.";
                default: return "";
            }
               
            

            

        }
    }
}
