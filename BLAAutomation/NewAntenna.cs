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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxLength.Text, out double length) &&
                double.TryParse(textBoxAmperage.Text, out double amperage) &&
                double.TryParse(textBoxPower.Text, out double power) &&
                double.TryParse(textBoxFrequency.Text, out double frequency))
            {
                Antenna.AddAntenna(_connection, textBoxName.Text, length, amperage, power, frequency);
                MessageBox.Show("Аntenna added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid numerical values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.textBoxName.Hint = "Name";
            this.textBoxName.Location = new System.Drawing.Point(12, 78);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(260, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Hint = "Length";
            this.textBoxLength.Location = new System.Drawing.Point(12, 107);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(260, 23);
            this.textBoxLength.TabIndex = 1;
            // 
            // textBoxAmperage
            // 
            this.textBoxAmperage.Hint = "Amperage";
            this.textBoxAmperage.Location = new System.Drawing.Point(12, 136);
            this.textBoxAmperage.Name = "textBoxAmperage";
            this.textBoxAmperage.Size = new System.Drawing.Size(260, 23);
            this.textBoxAmperage.TabIndex = 2;
            // 
            // textBoxPower
            // 
            this.textBoxPower.Hint = "Power";
            this.textBoxPower.Location = new System.Drawing.Point(12, 165);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(260, 23);
            this.textBoxPower.TabIndex = 3;
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Hint = "Frequency";
            this.textBoxFrequency.Location = new System.Drawing.Point(12, 194);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(260, 23);
            this.textBoxFrequency.TabIndex = 4;
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxLength;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxAmperage;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPower;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxFrequency;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;
    }
}
