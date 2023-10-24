using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using ShipsAndPorts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Controllers
{
    public class ShipNavigatorController
    {
        private readonly ShipNavigatorModel _model;

        public ShipNavigatorController(ShipNavigatorModel model)
        {
            _model = model;
        }

        public void SubscribeToModelNotifications(Action<ShipNavigatorModel> formUpdateAction)
        {
            _model.UpdateViewFunc = formUpdateAction;
        }

        public void SelectShip(string shipName)
        {
            if (_model.SelectedShip.Name == shipName)
                return;
            

            Ship newlySelectedShip = _model.Ships.SingleOrDefault(s => s.Name == shipName);
            _model.CopyWith(selectedShip:  newlySelectedShip ?? Ship.Empty);
        }

        public void SelectPort(string portName)
        {
            if (_model.SelectedPort.Name == portName || _model.SelectedShip == null || _model.SelectedShip == Ship.Empty)
                return;

            Port newlySelectedPort = _model.Ports.SingleOrDefault(s => s.Name == portName);
            RouteInfo newRouteInfo = ShipNavigatorService.GetRouteInfo(_model.SelectedShip, newlySelectedPort);

            _model.CopyWith(selectedPort: newlySelectedPort, routeInfo: newRouteInfo);
        }
    }
}
