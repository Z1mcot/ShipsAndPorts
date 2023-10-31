using ShipsAndPorts.Domain.Constants;
using ShipsAndPorts.Domain.Enums;
using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShipsAndPorts.Services
{
    public static class DataLoader
    {
        private readonly static Dictionary<string, Func<string[], object>> _factories = new Dictionary<string, Func<string[], object>>
        {
            { Paths.PortsFile, Port.FromTxtFile },
            { Paths.ShipsFile, Ship.FromTxtFile },
        };

        private readonly static Dictionary<Type, string> _paths = new Dictionary<Type, string>
        {
            { typeof(Port), Paths.PortsFile },
            { typeof(Ship), Paths.ShipsFile },
        };

        // Все пути есть в классе Domain.Consts.Paths
        public static List<T> LoadData<T>()
        {
            List<T> result = new List<T>();
            var path = _paths[typeof(T)];
            var factory = _factories[path];

            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] rawData = sr.ReadLine().Split(';').ToArray();
                    T newObj = (T)factory.Invoke(rawData);
                    result.Add(newObj);
                }
            }

            return result;
        }

        public static void Mock()
        {
            List<Ship> ships = new List<Ship>();
            List<Port> ports = new List<Port>();
            using (var sw = new StreamWriter(Paths.ShipsFile))
            {
                foreach (var item in ships)
                {
                    sw.WriteLine(item);
                }

            }
            using (var sp = new StreamWriter(Paths.PortsFile))
            {
                foreach (var item in ports)
                {
                    sp.WriteLine(item);
                }
            }
  
        }
    }
}
