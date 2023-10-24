using ShipsAndPorts.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Models
{
    public class ShipNavigatorModel
    {
        private Action<ShipNavigatorModel> _updateViewFunc;
        private readonly List<Ship> _ships;
        private readonly List<Port> _ports;

        private List<Port> _avaliablePorts;

        private Ship _selectedShip = null;
        private Port _selectedPort = null;

        private RouteInfo _routeInfo = null;

        public Action<ShipNavigatorModel> UpdateViewFunc { get => _updateViewFunc; set => _updateViewFunc = value; }
        public Ship SelectedShip { get => _selectedShip; private set => _selectedShip = value; }
        public Port SelectedPort { get => _selectedPort; private set => _selectedPort = value; }
        public List<Port> AvaliablePorts { get => _avaliablePorts; private set => _avaliablePorts = value; }
        public RouteInfo RouteInfo { get => _routeInfo; private set => _routeInfo = value; }

        public List<Ship> Ships => _ships;

        public List<Port> Ports => _ports;


        public ShipNavigatorModel(List<Ship> ships, List<Port> ports)
        {
            _ships = ships;
            _ports = ports;

            foreach (var ship in _ships)
            {
                ship.CurrentPort = new Lazy<Port>(() => _ports.Single(x => x.Name == ship.PortId));
            }
        }

        public void CopyWith(Ship selectedShip = null, Port selectedPort = null, List<Port> avaliablePorts = null, RouteInfo routeInfo = null)
        {
            SelectedShip = selectedShip ?? SelectedShip;
            SelectedPort = selectedPort ?? SelectedPort;
            AvaliablePorts = avaliablePorts ?? AvaliablePorts;
            RouteInfo = routeInfo ?? RouteInfo;
            
            NotifyListeners();
        }

        private void NotifyListeners() => _updateViewFunc?.Invoke(this); 
    }
}
