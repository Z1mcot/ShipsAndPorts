using ShipsAndPorts.Controllers;
using ShipsAndPorts.Domain.Constants;
using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using ShipsAndPorts.Services;
using ShipsAndPorts.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndPorts
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            var ships = DataLoader.LoadData<Ship>();
            var ports = DataLoader.LoadData<Port>();

            var model = new ShipNavigatorModel(ships, ports);
            var controller = new ShipNavigatorController(model);

            ShipNavigatorView view = new ShipNavigatorView(controller);
            view.Show();
        }
    }
}
