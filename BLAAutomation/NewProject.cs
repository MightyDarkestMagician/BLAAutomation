using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewProject : MaterialForm
    {
        private string _connectionString;

        public NewProject(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            try
            {
                // Инициализация значений по умолчанию для текстовых полей
                textBoxName.Text = "Project1";

                // Настройка обработчиков событий для элементов управления
                buttonAddProject.Click += buttonAddProject_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string name = textBoxName.Text;
                    int fuselageId = 1; // Пример Id фюзеляжа
                    Project.AddProject(connection, name, fuselageId);
                    MessageBox.Show("Проект успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.textBoxName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonAddProject = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // buttonAddProject
            // 
            this.buttonAddProject.Depth = 0;
            this.buttonAddProject.Location = new System.Drawing.Point(12, 145);
            this.buttonAddProject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Primary = true;
            this.buttonAddProject.Size = new System.Drawing.Size(260, 36);
            this.buttonAddProject.TabIndex = 1;
            this.buttonAddProject.Text = "Add Project";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // NewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 195);
            this.Controls.Add(this.buttonAddProject);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewProject";
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.NewProject_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddProject;
    }
}