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

        public static Port FromTxtFile(string[] data)
        {
            int[] coords = data.Skip(1).Select(x => int.Parse(x)).ToArray();
            return new Port(data[0], new Point(coords[1], coords[2]));
        }

        public Port(string name, Point coordinates)
        {
            _name = name;
            _coordinates = coordinates;
        }

        public string Name => _name;

        public Point Coordinates => _coordinates;
    }
}
