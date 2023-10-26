using ShipsAndPorts.Domain.Constants;
using ShipsAndPorts.Domain.Enums;
using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace ShipsAndPorts.Services
{
    public static class DataLoader
    {
        // Все пути есть в классе Domain.Consts.Paths
        public static List<T> LoadData<T>(string path)
        {
            List<T> data = new List<T>();
            if (path == Convert.ToString(Paths.ShipsFile))
            {
                using (var sr = new StreamReader(path))
                {
                    List<Ship> dataShip = new List<Ship>();
                    string[] l = sr.ReadToEnd().Split(' ').ToArray();
                    var shipType = (ShipTypeEnum)Enum.Parse(typeof(ShipTypeEnum), l[1]);
                    Ship ship = new Ship(l[0], shipType, l[2], Convert.ToDouble(l[3]), Convert.ToDouble(l[4]));
                    dataShip.Add(ship);
                    data = dataShip.Cast<T>().ToList();
                }
            }
            else
            {
                using (var sr = new StreamReader(path))
                {
                    List<Port> dataPort = new List<Port>();
                    string[] l = sr.ReadToEnd().Split(' ').ToArray();
                    Port port = new Port(l[0], new Point(Convert.ToInt32(l[1]), Convert.ToInt32(l[2])));
                    dataPort.Add(port);
                    data = dataPort.Cast<T>().ToList();
                }
            }

            return data;
            //throw new NotImplementedException();
        }
    }
}
