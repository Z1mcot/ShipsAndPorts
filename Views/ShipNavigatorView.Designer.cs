namespace ShipsAndPorts.Views
{
    partial class ShipNavigatorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Ships = new System.Windows.Forms.ListView();
            this.Корабли = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Ports = new System.Windows.Forms.ListView();
            this.Ports = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox_RouteInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listView_Ships
            // 
            this.listView_Ships.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Корабли});
            this.listView_Ships.HideSelection = false;
            this.listView_Ships.Location = new System.Drawing.Point(111, 80);
            this.listView_Ships.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView_Ships.Name = "listView_Ships";
            this.listView_Ships.Size = new System.Drawing.Size(160, 370);
            this.listView_Ships.TabIndex = 0;
            this.listView_Ships.UseCompatibleStateImageBehavior = false;
            this.listView_Ships.View = System.Windows.Forms.View.List;
            this.listView_Ships.SelectedIndexChanged += new System.EventHandler(this.OnShipClick);
            // 
            // Корабли
            // 
            this.Корабли.Text = "";
            // 
            // listView_Ports
            // 
            this.listView_Ports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Ports});
            this.listView_Ports.HideSelection = false;
            this.listView_Ports.Location = new System.Drawing.Point(437, 80);
            this.listView_Ports.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView_Ports.Name = "listView_Ports";
            this.listView_Ports.Size = new System.Drawing.Size(160, 370);
            this.listView_Ports.TabIndex = 1;
            this.listView_Ports.UseCompatibleStateImageBehavior = false;
            this.listView_Ports.View = System.Windows.Forms.View.List;
            this.listView_Ports.SelectedIndexChanged += new System.EventHandler(this.OnPortClick);
            // 
            // Ports
            // 
            this.Ports.Text = "";
            // 
            // textBox_RouteInfo
            // 
            this.textBox_RouteInfo.Location = new System.Drawing.Point(725, 79);
            this.textBox_RouteInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_RouteInfo.Multiline = true;
            this.textBox_RouteInfo.Name = "textBox_RouteInfo";
            this.textBox_RouteInfo.ReadOnly = true;
            this.textBox_RouteInfo.Size = new System.Drawing.Size(281, 370);
            this.textBox_RouteInfo.TabIndex = 2;
            // 
            // ShipNavigatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.textBox_RouteInfo);
            this.Controls.Add(this.listView_Ports);
            this.Controls.Add(this.listView_Ships);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ShipNavigatorView";
            this.Text = "ShipNavigatorView";
            this.Load += new System.EventHandler(this.ShipNavigatorView_Load);
            this.Click += new System.EventHandler(this.OnFormClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Ships;
        private System.Windows.Forms.ColumnHeader Корабли;
        private System.Windows.Forms.ListView listView_Ports;
        private System.Windows.Forms.ColumnHeader Ports;
        private System.Windows.Forms.TextBox textBox_RouteInfo;
    }
}