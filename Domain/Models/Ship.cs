using ShipsAndPorts.Domain.Enums;
using ShipsAndPorts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShipsAndPorts.Models
{
    public class Ship
    {
        private static readonly Ship _emptyInstance = new Ship(null, ShipTypeEnum.Passenger, null, 0, 0);
        public static Ship Empty => _emptyInstance;

        private readonly string _name;
        private readonly ShipTypeEnum _type;

        // Будем считать, что названия портов уникальны и следовательно их название и есть их Id
        private readonly string _portId;
        private Lazy<Port> _currentPort;
        
        private readonly double _range;
        private readonly double _speed;

        public string Name => _name;

        public ShipTypeEnum Type => _type;

        public double Range => _range;

        public double Speed => _speed;

        public Lazy<Port> CurrentPort { get => _currentPort; set => _currentPort = value; }

        public string PortId => _portId;

        public static Ship FromTxtFile(string[] data)
        {
            var type = (ShipTypeEnum)Enum.Parse(typeof(ShipTypeEnum), data[1]);
            return new Ship(data[0], type, data[2], double.Parse(data[3]), double.Parse(data[4]));
        }

        public Ship(string name, ShipTypeEnum type, string portId, double range, double speed)
        {
            _name = name;
            _type = type;
            _portId = portId;
            _range = range;
            _speed = speed;
        }
    }
}
