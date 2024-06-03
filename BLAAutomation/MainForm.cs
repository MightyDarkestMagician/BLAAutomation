using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class MainForm : MaterialForm
    {
        private readonly string _connectionString;

        public MainForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Your logic here
        }

        private void btnCreateFuselage_Click(object sender, EventArgs e)
        {
            var form = new NewFuselage(_connectionString);
            form.ShowDialog();
        }

        private void btnCreateProject_Click(object sender, EventArgs e)
        {
            var form = new NewProject(_connectionString);
            form.ShowDialog();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            var form = new NewDevice(_connectionString);
            form.ShowDialog();
        }

        private void btnAddAntenna_Click(object sender, EventArgs e)
        {
            var form = new NewAntenna(_connectionString);
            form.ShowDialog();
        }

        private void btnViewProjects_Click(object sender, EventArgs e)
        {
            var form = new ViewProjects(_connectionString);
            form.ShowDialog();
        }
    }
}
