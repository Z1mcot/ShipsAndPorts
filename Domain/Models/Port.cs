using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Domain.Models
{
    public class Port
    {
        private static readonly Port _emptyInstance = new Port(null, Point.Empty);
        public static Port Empty => _emptyInstance;

        private readonly string _name;
        private readonly Point _coordinates;

        public Port(string name, Point coordinates)
        {
            _name = name;
            _coordinates = coordinates;
        }

        public Port()
        {
            _name = "f";
            _coordinates = Point.Empty;
        }

        public string Name => _name;

        public Point Coordinates => _coordinates;
    }
}
