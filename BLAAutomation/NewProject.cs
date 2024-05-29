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

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                string projectName = textBoxProjectName.Text;
                int fuselageId = Convert.ToInt32(comboBoxFuselages.SelectedValue);

                Project.AddProject(_connection, projectName, fuselageId);
                MessageBox.Show("Проект успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            LoadFuselages();
        }

        private void LoadFuselages()
        {
            var fuselages = Fuselage.GetFuselages(_connection);
            comboBoxFuselages.DataSource = fuselages;
            comboBoxFuselages.DisplayMember = "Name";
            comboBoxFuselages.ValueMember = "Id";
        }

        private void InitializeComponent()
        {
            this.textBoxProjectName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.comboBoxFuselages = new System.Windows.Forms.ComboBox();
            this.buttonAddProject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // textBoxProjectName
            // 
            this.textBoxProjectName.Depth = 0;
            this.textBoxProjectName.Hint = "Project Name";
            this.textBoxProjectName.Location = new System.Drawing.Point(12, 78);
            this.textBoxProjectName.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxProjectName.Name = "textBoxProjectName";
            this.textBoxProjectName.PasswordChar = '\0';
            this.textBoxProjectName.SelectedText = "";
            this.textBoxProjectName.SelectionLength = 0;
            this.textBoxProjectName.SelectionStart = 0;
            this.textBoxProjectName.Size = new System.Drawing.Size(260, 23);
            this.textBoxProjectName.TabIndex = 0;
            this.textBoxProjectName.UseSystemPasswordChar = false;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddProject);
            this.Controls.Add(this.comboBoxFuselages);
            this.Controls.Add(this.textBoxProjectName);
            this.Name = "NewProject";
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxProjectName;
        private System.Windows.Forms.ComboBox comboBoxFuselages;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddProject;
    }
}
