using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewProject : MaterialForm
    {
        private SQLiteConnection _connection;

        public NewProject(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            comboBoxFuselages.Items.AddRange(Fuselage.GetFuselages(_connection));
            comboBoxFuselages.DisplayMember = "Name";
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) || comboBoxFuselages.SelectedItem == null)
            {
                MessageBox.Show("Please enter a project name and select a fuselage.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedFuselage = (Fuselage)comboBoxFuselages.SelectedItem;
            Project.AddProject(_connection, textBoxName.Text, selectedFuselage.Id);
            MessageBox.Show("Project added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void InitializeComponent()
        {
            this.textBoxName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.comboBoxFuselages = new System.Windows.Forms.ComboBox();
            this.buttonAddProject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Depth = 0;
            this.textBoxName.Hint = "Project Name";
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
            // comboBoxFuselages
            // 
            this.comboBoxFuselages.FormattingEnabled = true;
            this.comboBoxFuselages.Location = new System.Drawing.Point(12, 145);
            this.comboBoxFuselages.Name = "comboBoxFuselages";
            this.comboBoxFuselages.Size = new System.Drawing.Size(260, 21);
            this.comboBoxFuselages.TabIndex = 1;
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Depth = 0;
            this.buttonAddProject.Location = new System.Drawing.Point(12, 212);
            this.buttonAddProject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Primary = true;
            this.buttonAddProject.Size = new System.Drawing.Size(260, 36);
            this.buttonAddProject.TabIndex = 2;
            this.buttonAddProject.Text = "Add Project";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // NewProject
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonAddProject);
            this.Controls.Add(this.comboBoxFuselages);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewProject";
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private System.Windows.Forms.ComboBox comboBoxFuselages;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddProject;
    }
}
