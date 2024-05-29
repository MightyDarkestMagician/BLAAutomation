using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class Devices : MaterialForm
    {
        private SQLiteConnection _connection;

        public Devices(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Devices_Load(object sender, EventArgs e)
        {
            UpdateTable();
            dataGridViewDevices.ContextMenuStrip = contextMenuStripDevices;
        }

        private void UpdateTable()
        {
            string query = "SELECT Id as 'ID', Name as 'Name', Weight as 'Weight', NoiseImmunity as 'Noise Immunity' FROM Device;";
            DataSet dataSetDevices = SQLiteDatabaseHelper.SQLiteCustomCommandSelect(_connection, query);
            dataGridViewDevices.DataSource = dataSetDevices.Tables[0];
        }

        private void AddDeviceMenuItem_Click(object sender, EventArgs e)
        {
            using (var newDeviceForm = new NewDevice(_connection))
            {
                if (newDeviceForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateTable();
                }
            }
        }

        private void DeleteDeviceMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewDevices.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dataGridViewDevices.SelectedRows[0].Cells["ID"].Value);
                Device.RemoveDevice(_connection, selectedId);
                UpdateTable();
            }
            else
            {
                MessageBox.Show("Please select a device to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.contextMenuStripDevices = new System.Windows.Forms.ContextMenuStrip();
            this.AddDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDeviceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            this.contextMenuStripDevices.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.ContextMenuStrip = this.contextMenuStripDevices;
            this.dataGridViewDevices.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDevices.Size = new System.Drawing.Size(776, 360);
            this.dataGridViewDevices.TabIndex = 0;
            // 
            // contextMenuStripDevices
            // 
            this.contextMenuStripDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDeviceMenuItem,
            this.DeleteDeviceMenuItem});
            this.contextMenuStripDevices.Name = "contextMenuStripDevices";
            this.contextMenuStripDevices.Size = new System.Drawing.Size(181, 70);
            // 
            // AddDeviceMenuItem
            // 
            this.AddDeviceMenuItem.Name = "AddDeviceMenuItem";
            this.AddDeviceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.AddDeviceMenuItem.Text = "Add Device";
            this.AddDeviceMenuItem.Click += new System.EventHandler(this.AddDeviceMenuItem_Click);
            // 
            // DeleteDeviceMenuItem
            // 
            this.DeleteDeviceMenuItem.Name = "DeleteDeviceMenuItem";
            this.DeleteDeviceMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteDeviceMenuItem.Text = "Delete Device";
            this.DeleteDeviceMenuItem.Click += new System.EventHandler(this.DeleteDeviceMenuItem_Click);
            // 
            // Devices
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewDevices);
            this.Name = "Devices";
            this.Text = "Devices";
            this.Load += new System.EventHandler(this.Devices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            this.contextMenuStripDevices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDevices;
        private System.Windows.Forms.ToolStripMenuItem AddDeviceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteDeviceMenuItem;
    }
}
