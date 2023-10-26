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

        public void SelectShip(int shipIndex)
        {
            List<int> avaliablePorts = ShipNavigatorService.GetAvaliablePorts(_model.Ships[shipIndex], _model.Ports);

            _model.CopyWith(selectedShip: shipIndex, avaliablePorts: avaliablePorts);
        }

        public void SelectPort(int portIndex)
        {
            RouteInfo newRouteInfo = ShipNavigatorService.GetRouteInfo(_model.Ships[_model.SelectedShip], _model.Ports[portIndex]);

            _model.CopyWith(selectedPort: portIndex, routeInfo: newRouteInfo);
        }

        public void Deselect()
        {
            _model.CopyWith(-1, -1, new List<int>(), RouteInfo.Empty);
        }
    }
}
