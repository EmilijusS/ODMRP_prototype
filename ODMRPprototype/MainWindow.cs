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

        private void button1_Click(object sender, EventArgs e)
        {
            simulation.Update();
            visualisation.Refresh();
            Console.WriteLine(simulation.Packets.Count);
        }
    }
}
