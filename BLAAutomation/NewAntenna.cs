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
            this.SuspendLayout();
            // 
            // NewAntenna
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "NewAntenna";
            this.Load += new System.EventHandler(this.NewAntenna_Load_1);
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

        private void NewAntenna_Load_1(object sender, EventArgs e)
        {

        }
    }
}
