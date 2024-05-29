using System.Collections.Generic;

namespace BLAAutomation
{
    public class Project
    {
        public List<Compartment> Compartments { get; set; }
        public List<Position> Positions { get; set; }
        public List<Antenna> Antennas { get; set; }

        public Project()
        {
            Compartments = new List<Compartment>();
            Positions = new List<Position>();
            Antennas = new List<Antenna>();
        }
    }

    public class Compartment
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Carrying { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
    }

    public class Antenna
    {
        public int Id { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double CoordinateZ { get; set; }
    }
}
