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
    public partial class Visualisation : Form
    {
        const int XOffset = 100;
        const int YOffset = 100;
        // How many pixels is one coordinate
        const int _Scale = 5;
        List<Node> Nodes;
        List<Packet> Packets;

        public Visualisation(List<Node> nodes, List<Packet> packets)
        {
            Nodes = nodes;
            Packets = packets;
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Graphics g = CreateGraphics())
            {
                Pen pen = new Pen(Color.Black, 1);

                foreach(var n in Nodes)
                {
                    SolidBrush brush = new SolidBrush(Color.Black);

                    if (n is Source)
                        brush.Color = Color.Red;

                    if (n is Receiver)
                        brush.Color = Color.LightBlue;

                    g.FillRectangle(brush, new Rectangle(n.Coordinates.X * _Scale + XOffset, n.Coordinates.Y * _Scale + YOffset, _Scale, _Scale));
                    g.DrawString(n.Address.ToString(), new Font("Arial", 12), brush, n.Coordinates.X * _Scale + XOffset + _Scale, n.Coordinates.Y * _Scale + YOffset + _Scale);
                    g.DrawEllipse(pen, new Rectangle(n.Coordinates.X * _Scale + XOffset - Node.VisibilityRange * _Scale, n.Coordinates.Y * _Scale + YOffset - Node.VisibilityRange * _Scale,
                        Node.VisibilityRange * _Scale * 2, Node.VisibilityRange * _Scale * 2));
                }

                Random random = new Random();

                foreach(var p in Packets)
                {
                    SolidBrush brush = new SolidBrush(Color.Black);

                    if (p is JoinRequestPacket)
                        brush.Color = Color.Red;

                    if (p is JoinReplyPacket)
                        brush.Color = Color.LightBlue;

                    g.FillRectangle(brush, new Rectangle(p.Coordinates.X * _Scale + XOffset - 2 + random.Next(5), p.Coordinates.Y * _Scale + YOffset - 2 + random.Next(5), 3, 3));
                }

                pen.Dispose();
            }
        }
    }
}
