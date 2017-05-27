using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODMRPprototype
{
     public class Packet
    {
        public const int Speed = 2;

        public int InitialTimeToTarget
        {
            get
            {
                return initialTimeToTarget;
            }
            set
            {
                initialTimeToTarget = value;
                TimeToTarget = value;
            }
        }

        public Coordinates InitialCoordinates
        {
            get
            {
                return initialCoordinates;
            }
            set
            {
                initialCoordinates = value;
                Coordinates = value;
            }
        }
        
        int initialTimeToTarget;
        public int TimeToTarget { get; private set; }    
        Coordinates initialCoordinates;
        public Coordinates Coordinates { get; private set; }
        public Node Target { get; set; }
        public int SequenceNumber { get; set; }

        public Packet(int sequenceNumber)
        {
            SequenceNumber = sequenceNumber;
        }

        public void UpdatePosition()
        {
            int newX, newY;
            --TimeToTarget;
            newX = (int)(InitialCoordinates.X - ((InitialCoordinates.X - Target.Coordinates.X) * ((double)(InitialTimeToTarget - TimeToTarget) / InitialTimeToTarget)));
            newY = (int)(InitialCoordinates.Y - ((InitialCoordinates.Y - Target.Coordinates.Y) * ((double)(InitialTimeToTarget - TimeToTarget) / InitialTimeToTarget)));
            Coordinates = new Coordinates(newX, newY);
        }
    }
}
