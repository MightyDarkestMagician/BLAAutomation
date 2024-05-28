using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SQLiteDatabaseHelper.InitializeDatabase();
        }

        private void проектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectForm projectForm = new ProjectForm();
            projectForm.Show();
        }

        private void данныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataForm dataForm = new DataForm();
            dataForm.Show();
        }

        private void алгоритмToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlgorithmForm algorithmForm = new AlgorithmForm();
            algorithmForm.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void buttonOpenAlgorithmForm_Click(object sender, EventArgs e)
        {
            AlgorithmForm algorithmForm = new AlgorithmForm();
            algorithmForm.Show();
        }
    }
}
