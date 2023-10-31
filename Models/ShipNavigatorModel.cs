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
        private Action<ShipNavigatorModel> _initViewFunc;
        private Action<ShipNavigatorModel> _updateViewFunc;
        private readonly List<Ship> _ships;
        private readonly List<Port> _ports;

        private List<int> _avaliablePorts;

        private int _selectedShipIndex = -1;
        private int _selectedPortIndex = -1;

        private RouteInfo _routeInfo = null;

        private bool _isViewInitialized = false;

        public Action<ShipNavigatorModel> UpdateViewFunc { get => _updateViewFunc; set => _updateViewFunc = value; }
        public int SelectedShip => _selectedShipIndex;
        public int SelectedPort => _selectedPortIndex;
        public List<int> AvaliablePorts => _avaliablePorts;
        public RouteInfo RouteInfo => _routeInfo;

        public List<Ship> Ships => _ships;

        public List<Port> Ports => _ports;

        public Action<ShipNavigatorModel> InitViewFunc { get => _initViewFunc; set => _initViewFunc = value; }

        public ShipNavigatorModel(List<Ship> ships, List<Port> ports)
        {
            _ships = ships;
            _ports = ports;

            foreach (var ship in _ships)
            {
                ship.CurrentPort = new Lazy<Port>(() => _ports.Single(x => x.Name == ship.PortId));
            }
        }

        public void CopyWith(int? selectedShip = null, int? selectedPort = null, List<int> avaliablePorts = null, RouteInfo routeInfo = null)
        {
            _selectedShipIndex = selectedShip ?? _selectedShipIndex;
            _selectedPortIndex = selectedPort ?? _selectedPortIndex;
            _avaliablePorts = avaliablePorts ?? AvaliablePorts;
            _routeInfo = routeInfo ?? RouteInfo;
            
            NotifyListeners();
        }

        public void InitView()
        {
            if (_isViewInitialized) return;

            _initViewFunc?.Invoke(this);
            _isViewInitialized = true;
        }

        private void NotifyListeners() => _updateViewFunc?.Invoke(this); 
    }
}
