using MaterialSkin;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public class Antenna : BasicObject
    {
        public double Length { get; set; }
        public double Amperage { get; set; }
        public double Power { get; set; }
        public double Frequency { get; set; }

        public Antenna(int id, SQLiteConnection connection) : base(id)
        {
            DataSet dataSetObject = SQLiteDatabaseHelper.SQLiteCommandSelectWithCustomCondition(connection, "Antenna", "Id = " + id.ToString() + ";");
            Name = dataSetObject.Tables[0].Rows[0]["Name"].ToString();
            Length = double.Parse(dataSetObject.Tables[0].Rows[0]["Length"].ToString());
            Amperage = double.Parse(dataSetObject.Tables[0].Rows[0]["Amperage"].ToString());
            Power = double.Parse(dataSetObject.Tables[0].Rows[0]["Power"].ToString());
            Frequency = double.Parse(dataSetObject.Tables[0].Rows[0]["Frequency"].ToString());
        }

        public static Antenna[] GetAntennas(SQLiteConnection connection)
        {
            DataSet dataSet = SQLiteDatabaseHelper.SQLiteCommandSelectAllFrom(connection, "Antenna");
            Antenna[] antennas = new Antenna[dataSet.Tables[0].Rows.Count];
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                var row = dataSet.Tables[0].Rows[i];
                antennas[i] = new Antenna(int.Parse(row["Id"].ToString()), connection);
            }
            return antennas;
        }

        public static void AddAntenna(SQLiteConnection connection, string name, double length, double amperage, double power, double frequency)
        {
            string[] columns = { "Name", "Length", "Amperage", "Power", "Frequency" };
            string[] values = { name, length.ToString(), amperage.ToString(), power.ToString(), frequency.ToString() };
            SQLiteDatabaseHelper.SQLiteCommandInsertInto(connection, "Antenna", columns, values);
        }

        public static void RemoveAntenna(SQLiteConnection connection, int idAntenna)
        {
            string whereClause = $"WHERE Id = {idAntenna}";
            SQLiteDatabaseHelper.SQLiteCommandDeleteFrom(connection, "Antenna", whereClause);
        }
    }

    public partial class Antennas : MaterialSkin.Controls.MaterialForm
    {
        private SQLiteConnection _connection;

        public Antennas(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Antennas_Load(object sender, EventArgs e)
        {
            UpdateTable();
            dataGridViewAntennas.ContextMenuStrip = contextMenuStripAntennas;
        }

        private void UpdateTable()
        {
            string query = "SELECT Id as 'ID', Name as 'Name', Length as 'Length', Amperage as 'Amperage', Power as 'Power', Frequency as 'Frequency' FROM Antenna;";
            DataSet dataSetAntennas = SQLiteDatabaseHelper.SQLiteCustomCommandSelect(_connection, query);
            dataGridViewAntennas.DataSource = dataSetAntennas.Tables[0];
        }

        private void AddAntennaMenuItem_Click(object sender, EventArgs e)
        {
            using (var newAntennaForm = new NewAntenna(_connection))
            {
                if (newAntennaForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateTable();
                }
            }
        }

        private void DeleteAntennaMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewAntennas.SelectedRows.Count > 0)
            {
                int selectedId = Convert.ToInt32(dataGridViewAntennas.SelectedRows[0].Cells["ID"].Value);
                Antenna.RemoveAntenna(_connection, selectedId);
                UpdateTable();
            }
            else
            {
                MessageBox.Show("Please select an antenna to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeComponent()
        {
            this.dataGridViewAntennas = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAntennas = new System.Windows.Forms.ContextMenuStrip();
            this.AddAntennaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAntennaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAntennas)).BeginInit();
            this.contextMenuStripAntennas.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAntennas
            // 
            this.dataGridViewAntennas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAntennas.ContextMenuStrip = this.contextMenuStripAntennas;
            this.dataGridViewAntennas.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewAntennas.Name = "dataGridViewAntennas";
            this.dataGridViewAntennas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAntennas.Size = new System.Drawing.Size(776, 360);
            this.dataGridViewAntennas.TabIndex = 0;
            // 
            // contextMenuStripAntennas
            // 
            this.contextMenuStripAntennas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAntennaMenuItem,
            this.DeleteAntennaMenuItem});
            this.contextMenuStripAntennas.Name = "contextMenuStripAntennas";
            this.contextMenuStripAntennas.Size = new System.Drawing.Size(153, 70);
            // 
            // AddAntennaMenuItem
            // 
            this.AddAntennaMenuItem.Name = "AddAntennaMenuItem";
            this.AddAntennaMenuItem.Size = new System.Drawing.Size(152, 22);
            this.AddAntennaMenuItem.Text = "Add Antenna";
            this.AddAntennaMenuItem.Click += new System.EventHandler(this.AddAntennaMenuItem_Click);
            // 
            // DeleteAntennaMenuItem
            // 
            this.DeleteAntennaMenuItem.Name = "DeleteAntennaMenuItem";
            this.DeleteAntennaMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteAntennaMenuItem.Text = "Delete Antenna";
            this.DeleteAntennaMenuItem.Click += new System.EventHandler(this.DeleteAntennaMenuItem_Click);
            // 
            // Antennas
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewAntennas);
            this.Name = "Antennas";
            this.Text = "Antennas";
            this.Load += new System.EventHandler(this.Antennas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAntennas)).EndInit();
            this.contextMenuStripAntennas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dataGridViewAntennas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAntennas;
        private System.Windows.Forms.ToolStripMenuItem AddAntennaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteAntennaMenuItem;
    }
}
