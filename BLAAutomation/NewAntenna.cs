using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewAntennaForm : MaterialForm
    {
        private SQLiteConnection _connection;

        public NewAntennaForm(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewAntennaForm_Load(object sender, EventArgs e)
        {
            // Initialization logic
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                double length = double.Parse(textBoxLength.Text);
                double amperage = double.Parse(textBoxAmperage.Text);
                double power = double.Parse(textBoxPower.Text);
                double frequency = double.Parse(textBoxFrequency.Text);
                double coordinateX = double.Parse(textBoxCoordinateX.Text); // Поле для ввода координаты X
                double coordinateY = double.Parse(textBoxCoordinateY.Text); // Поле для ввода координаты Y
                double coordinateZ = double.Parse(textBoxCoordinateZ.Text); // Поле для ввода координаты Z

                Antenna.AddAntenna(_connection, name, length, amperage, power, frequency, coordinateX, coordinateY, coordinateZ);
                MessageBox.Show("Antenna added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding antenna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.textBoxName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxLength = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxAmperage = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxPower = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxFrequency = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxCoordinateX = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxCoordinateY = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxCoordinateZ = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonAddAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Depth = 0;
            this.textBoxName.Hint = "Name";
            this.textBoxName.Location = new System.Drawing.Point(12, 78);
            this.textBoxName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PasswordChar = '\0';
            this.textBoxName.SelectedText = "";
            this.textBoxName.SelectionLength = 0;
            this.textBoxName.SelectionStart = 0;
            this.textBoxName.Size = new System.Drawing.Size(260, 23);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.UseSystemPasswordChar = false;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Depth = 0;
            this.textBoxLength.Hint = "Length";
            this.textBoxLength.Location = new System.Drawing.Point(12, 107);
            this.textBoxLength.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.PasswordChar = '\0';
            this.textBoxLength.SelectedText = "";
            this.textBoxLength.SelectionLength = 0;
            this.textBoxLength.SelectionStart = 0;
            this.textBoxLength.Size = new System.Drawing.Size(260, 23);
            this.textBoxLength.TabIndex = 1;
            this.textBoxLength.UseSystemPasswordChar = false;
            // 
            // textBoxAmperage
            // 
            this.textBoxAmperage.Depth = 0;
            this.textBoxAmperage.Hint = "Amperage";
            this.textBoxAmperage.Location = new System.Drawing.Point(12, 136);
            this.textBoxAmperage.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxAmperage.Name = "textBoxAmperage";
            this.textBoxAmperage.PasswordChar = '\0';
            this.textBoxAmperage.SelectedText = "";
            this.textBoxAmperage.SelectionLength = 0;
            this.textBoxAmperage.SelectionStart = 0;
            this.textBoxAmperage.Size = new System.Drawing.Size(260, 23);
            this.textBoxAmperage.TabIndex = 2;
            this.textBoxAmperage.UseSystemPasswordChar = false;
            // 
            // textBoxPower
            // 
            this.textBoxPower.Depth = 0;
            this.textBoxPower.Hint = "Power";
            this.textBoxPower.Location = new System.Drawing.Point(12, 165);
            this.textBoxPower.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.PasswordChar = '\0';
            this.textBoxPower.SelectedText = "";
            this.textBoxPower.SelectionLength = 0;
            this.textBoxPower.SelectionStart = 0;
            this.textBoxPower.Size = new System.Drawing.Size(260, 23);
            this.textBoxPower.TabIndex = 3;
            this.textBoxPower.UseSystemPasswordChar = false;
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Depth = 0;
            this.textBoxFrequency.Hint = "Frequency";
            this.textBoxFrequency.Location = new System.Drawing.Point(12, 194);
            this.textBoxFrequency.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.PasswordChar = '\0';
            this.textBoxFrequency.SelectedText = "";
            this.textBoxFrequency.SelectionLength = 0;
            this.textBoxFrequency.SelectionStart = 0;
            this.textBoxFrequency.Size = new System.Drawing.Size(260, 23);
            this.textBoxFrequency.TabIndex = 4;
            this.textBoxFrequency.UseSystemPasswordChar = false;
            // 
            // textBoxCoordinateX
            // 
            this.textBoxCoordinateX.Depth = 0;
            this.textBoxCoordinateX.Hint = "Coordinate X";
            this.textBoxCoordinateX.Location = new System.Drawing.Point(12, 223);
            this.textBoxCoordinateX.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCoordinateX.Name = "textBoxCoordinateX";
            this.textBoxCoordinateX.PasswordChar = '\0';
            this.textBoxCoordinateX.SelectedText = "";
            this.textBoxCoordinateX.SelectionLength = 0;
            this.textBoxCoordinateX.SelectionStart = 0;
            this.textBoxCoordinateX.Size = new System.Drawing.Size(260, 23);
            this.textBoxCoordinateX.TabIndex = 5;
            this.textBoxCoordinateX.UseSystemPasswordChar = false;
            // 
            // textBoxCoordinateY
            // 
            this.textBoxCoordinateY.Depth = 0;
            this.textBoxCoordinateY.Hint = "Coordinate Y";
            this.textBoxCoordinateY.Location = new System.Drawing.Point(12, 252);
            this.textBoxCoordinateY.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCoordinateY.Name = "textBoxCoordinateY";
            this.textBoxCoordinateY.PasswordChar = '\0';
            this.textBoxCoordinateY.SelectedText = "";
            this.textBoxCoordinateY.SelectionLength = 0;
            this.textBoxCoordinateY.SelectionStart = 0;
            this.textBoxCoordinateY.Size = new System.Drawing.Size(260, 23);
            this.textBoxCoordinateY.TabIndex = 6;
            this.textBoxCoordinateY.UseSystemPasswordChar = false;
            // 
            // textBoxCoordinateZ
            // 
            this.textBoxCoordinateZ.Depth = 0;
            this.textBoxCoordinateZ.Hint = "Coordinate Z";
            this.textBoxCoordinateZ.Location = new System.Drawing.Point(12, 281);
            this.textBoxCoordinateZ.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCoordinateZ.Name = "textBoxCoordinateZ";
            this.textBoxCoordinateZ.PasswordChar = '\0';
            this.textBoxCoordinateZ.SelectedText = "";
            this.textBoxCoordinateZ.SelectionLength = 0;
            this.textBoxCoordinateZ.SelectionStart = 0;
            this.textBoxCoordinateZ.Size = new System.Drawing.Size(260, 23);
            this.textBoxCoordinateZ.TabIndex = 7;
            this.textBoxCoordinateZ.UseSystemPasswordChar = false;
            // 
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.Depth = 0;
            this.buttonAddAntenna.Location = new System.Drawing.Point(12, 310);
            this.buttonAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Primary = true;
            this.buttonAddAntenna.Size = new System.Drawing.Size(260, 36);
            this.buttonAddAntenna.TabIndex = 8;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = true;
            this.buttonAddAntenna.Click += new System.EventHandler(this.buttonAddAntenna_Click);
            // 
            // NewAntennaForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.buttonAddAntenna);
            this.Controls.Add(this.textBoxCoordinateZ);
            this.Controls.Add(this.textBoxCoordinateY);
            this.Controls.Add(this.textBoxCoordinateX);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.textBoxPower);
            this.Controls.Add(this.textBoxAmperage);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewAntennaForm";
            this.Text = "New Antenna";
            this.Load += new System.EventHandler(this.NewAntennaForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxLength;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxAmperage;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPower;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxFrequency;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCoordinateX;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCoordinateY;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCoordinateZ;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;
    }
}
