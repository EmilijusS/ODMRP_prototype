using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ODMRPprototype
{
    public partial class MainWindow : Form
    {
        Simulation simulation;
        Visualisation visualisation;

        public MainWindow()
        {
            InitializeComponent();
            simulation = new Simulation();
            visualisation = new Visualisation(simulation.Nodes, simulation.Packets);
            visualisation.Show();
            visualisation.Update();
        }

        private void AddNodeButton_Click(object sender, EventArgs e)
        {
            new AddNode(simulation).Show();
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            DataSentBox.Text = ((Source)simulation.Nodes[0]).DataSent;
            DataReceivedBox.Text = ((Receiver)simulation.Nodes[1]).Data;

            simulation.Update();
            visualisation.Refresh();
            Console.WriteLine(simulation.Packets.Count);
        }
    }
}
