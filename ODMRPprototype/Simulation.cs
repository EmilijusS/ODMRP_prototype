using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
    class Simulation
    {
        private Coordinates[] InitialNodes = {new Coordinates(5, 10), new Coordinates(17, 8), new Coordinates(20, 2), new Coordinates(27, 30)
        , new Coordinates(40, 31), new Coordinates(50, 12), new Coordinates(22, 78), new Coordinates(69, 35), new Coordinates(80, 67), new Coordinates(95, 41)
        , new Coordinates(71, 64), new Coordinates(90, 84), new Coordinates(12, 51), new Coordinates(93, 3), new Coordinates(41, 68), new Coordinates(14, 72)};

        public List<Node> Nodes;
        public List<Packet> Packets;
        public List<int> MulticastGroups;

        public Simulation()
        {
            Nodes = new List<Node>();
            Packets = new List<Packet>();
            MulticastGroups = new List<int>();

            Nodes.Add(new Source(new Coordinates(0, 0), new List<Node>()));
            MulticastGroups.Add(((Source)Nodes[0]).MulticastGroup);
            Nodes.Add(new Receiver(new Coordinates(100, 100), new List<Node>(), MulticastGroups[0]));
            AddInitialNodes();
        }

        void AddInitialNodes()
        {
            foreach(var c in InitialNodes)
            {
                AddNode(new Node(c));
            }
        }

        void AddNode(Node node)
        {

        }

        public void Update()
        {
            foreach(var p in Packets)
            {
                p.UpdatePosition();
                if (p.TimeToTarget == 0)
                {
                    p.Target.IncomingData(p);
                    Packets.Remove(p);
                }
            }

            foreach(var n in Nodes)
            {
                Packets.AddRange(n.Update());
            }
        }
    }
}
