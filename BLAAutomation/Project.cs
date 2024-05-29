using System.Collections.Generic;

namespace BLAAutomation
{
    public class Project
    {
        public List<Compartment> Compartments { get; set; }
        public List<Position> Positions { get; set; }
        public List<AntennaPosition> Antennas { get; set; }

        public Project()
        {
            Compartments = new List<Compartment>();
            Positions = new List<Position>();
            Antennas = new List<AntennaPosition>();
        }
    }

    public class AntennaPosition
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
    }
}
