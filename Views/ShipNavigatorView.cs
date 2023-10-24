using ShipsAndPorts.Controllers;
using ShipsAndPorts.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipsAndPorts.Views
{
    public partial class ShipNavigatorView : Form
    {
        private readonly ShipNavigatorController _controller;

        // TODO дописать обновление формы после обновления модели
        private void UpdateForm(ShipNavigatorModel model) { } 

        public ShipNavigatorView(ShipNavigatorController controller)
        {
            InitializeComponent();

            _controller = controller;
            _controller.SubscribeToModelNotifications(UpdateForm);
        }
    }
}
