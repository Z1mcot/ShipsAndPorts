using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Domain.Models
{
    public class RouteInfo
    {
        private static readonly RouteInfo _emptyInstance = new RouteInfo(null, null);
        public static RouteInfo Empty => _emptyInstance;

        private readonly TimeSpan? _timeEnRoute;
        private readonly double? _distance;
        private readonly bool _isValid;

        public RouteInfo(TimeSpan? timeEnRoute, double? distance)
        {
            _timeEnRoute = timeEnRoute;
            _distance = distance;
            _isValid = timeEnRoute != null && distance != null;
        }

        public TimeSpan TimeEnRoute => _timeEnRoute ?? new TimeSpan();

        public double Distance => _distance ?? 0;

        public bool IsValid { get => _isValid; }
    }
}
