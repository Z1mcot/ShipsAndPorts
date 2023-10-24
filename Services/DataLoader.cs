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
            throw new NotImplementedException();
        }
    }
}
