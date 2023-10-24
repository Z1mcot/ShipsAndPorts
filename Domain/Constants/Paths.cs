using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipsAndPorts.Domain.Constants
{
    internal class Paths
    {
        private const string _ioDirectory = "../../IO";

        public static string ShipsFile = _ioDirectory + "/ships.xml";
        public static string PortsFile = _ioDirectory + "/ports.xml";
    }
}
