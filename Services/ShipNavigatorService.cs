using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Services
{
    public static class ShipNavigatorService
    {
        private static double CalculateDistanceToPort(Ship ship, Port destination)
        {
            Point shipCoordinates = ship.CurrentPort.Value.Coordinates;
            double dx = shipCoordinates.X - destination.Coordinates.X;
            double dy = shipCoordinates.Y - destination.Coordinates.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        private static TimeSpan CalculateTimeEnRoute(double distance, Ship ship)
        {
            return TimeSpan.FromHours(distance / ship.Speed);
        }

        public static List<int> GetAvaliablePorts(Ship selectedShip, List<Port> allPorts)
        {
            var ports = new List<int>();
            for (int i = 0; i < allPorts.Count; i++)
            {
                if (CalculateDistanceToPort(selectedShip, allPorts[i]) <= selectedShip.Range)
                    ports.Add(i);
            }
            return ports;
        }

        public static RouteInfo GetRouteInfo(Ship ship, Port destination) 
        {
            double distance = CalculateDistanceToPort(ship, destination);
            if (distance > ship.Range) 
                return RouteInfo.Empty;

            TimeSpan timeEnRoute = CalculateTimeEnRoute(distance, ship);
            return new RouteInfo(timeEnRoute, distance);
        }
    }
}
