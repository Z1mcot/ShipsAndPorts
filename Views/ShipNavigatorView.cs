using ShipsAndPorts.Controllers;
using ShipsAndPorts.Domain.Models;
using ShipsAndPorts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndPorts.Views
{
    public partial class ShipNavigatorView : Form
    {
        private readonly ShipNavigatorController _controller;

        public ShipNavigatorView(ShipNavigatorController controller)
        {
            InitializeComponent();

            _controller = controller;
            _controller.SubscribeToModelNotifications(UpdateForm);
        }

        // TODO дописать обновление формы после обновления модели
        private void UpdateForm(ShipNavigatorModel model)
        {
            if (model.SelectedShip == -1)
                UpdateDeselect();

            UpdateSelectedShip(model.SelectedShip);

            UpdatePorts(model.AvaliablePorts, model.SelectedPort);

            UpdateRouteInfo(model.RouteInfo);
        }

        private void UpdateDeselect()
        {
            for (int i = 0; i < listView_Ships.Items.Count; i++)
            {
                if (listView_Ships.Items[i].BackColor != Color.Blue)
                    continue;

                listView_Ships.Items[i].BackColor = Color.Transparent;
                break;
            }

            for (int i = 0; i < listView_Ports.Items.Count; i++)
                listView_Ports.Items[i].BackColor = Color.Transparent;

            textBox_RouteInfo.Text = "";

            return;
        }

        private void UpdateSelectedShip(int selectedShip)
            => listView_Ships.Items[selectedShip].BackColor = Color.Blue;

        private void UpdatePorts(List<int> avaliablePorts, int selectedPort)
        {
            for (int i = 0; i < listView_Ports.Items.Count; i++)
            {
                if (avaliablePorts.Contains(i))
                    listView_Ports.Items[i].BackColor = Color.Green;
                else
                    listView_Ports.Items[i].BackColor = Color.Red;
            }

            if (selectedPort == -1)
                return;

            listView_Ports.Items[selectedPort].BackColor = Color.Blue;
        }

        private void UpdateRouteInfo(RouteInfo routeInfo)
        {
            if (routeInfo== null || routeInfo == RouteInfo.Empty)
                return;

            textBox_RouteInfo.Text = routeInfo.ToString();
        }

        private void OnShipClick(object sender, EventArgs e)
            => _controller.SelectShip(listView_Ships.SelectedIndices[0]);

        private void OnPortClick(object sender, EventArgs e)
            => _controller.SelectPort(listView_Ports.SelectedIndices[0]);

        private void OnFormClick(object sender, EventArgs e)
            => _controller.Deselect();

    }
}
