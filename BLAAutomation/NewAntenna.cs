using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BLAAutomation
{
    public partial class NewAntenna : MaterialForm
    {
        private SQLiteConnection _connection;

        public NewAntenna(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
        }

        private void NewAntenna_Load(object sender, EventArgs e)
        {
            // Initialization logic
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                double length = double.Parse(textBoxLength.Text);
                double amperage = double.Parse(textBoxAmperage.Text);
                double power = double.Parse(textBoxPower.Text);
                double frequency = double.Parse(textBoxFrequency.Text);

                Antenna.AddAntenna(_connection, name, length, amperage, power, frequency);
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
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.Depth = 0;
            this.buttonAddAntenna.Location = new System.Drawing.Point(12, 223);
            this.buttonAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Primary = true;
            this.buttonAddAntenna.Size = new System.Drawing.Size(260, 36);
            this.buttonAddAntenna.TabIndex = 5;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = true;
            this.buttonAddAntenna.Click += new System.EventHandler(this.buttonAddAntenna_Click);
            // 
            // NewAntenna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.buttonAddAntenna);
            this.Controls.Add(this.textBoxFrequency);
            this.Controls.Add(this.textBoxPower);
            this.Controls.Add(this.textBoxAmperage);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewAntenna";
            this.Text = "New Antenna";
            this.Load += new System.EventHandler(this.NewAntenna_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxLength;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxAmperage;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPower;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxFrequency;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;

        private void NewAntenna_Load(object sender, EventArgs e)
        {

        }
    }
}
