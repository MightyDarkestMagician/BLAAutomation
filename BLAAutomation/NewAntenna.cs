using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewAntenna : MaterialForm
    {
        private string _connectionString;

        public NewAntenna(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewAntenna_Load(object sender, EventArgs e)
        {
            try
            {
                // Инициализация значений по умолчанию для текстовых полей
                textBoxName.Text = "Antenna1";

                // Настройка обработчиков событий для элементов управления
                buttonAddAntenna.Click += buttonAddAntenna_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddAntenna_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string name = textBoxName.Text;
                    double length = 1.5;
                    double amperage = 0.2;
                    double power = 10.0;
                    double frequency = 2.4e9;
                    double coordinateX = 10.0;
                    double coordinateY = 20.0;
                    double coordinateZ = 30.0;
                    int compartmentId = 1;
                    Antenna.AddAntenna(connection, name, length, amperage, power, frequency, coordinateX, coordinateY, coordinateZ, compartmentId);
                    MessageBox.Show("Антенна успешно добавлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.Depth = 0;
            this.buttonAddAntenna.Location = new System.Drawing.Point(12, 145);
            this.buttonAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Primary = true;
            this.buttonAddAntenna.Size = new System.Drawing.Size(260, 36);
            this.buttonAddAntenna.TabIndex = 1;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = true;
            this.buttonAddAntenna.Click += new System.EventHandler(this.buttonAddAntenna_Click);
            // 
            // NewAntenna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 195);
            this.Controls.Add(this.buttonAddAntenna);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewAntenna";
            this.Text = "New Antenna";
            this.Load += new System.EventHandler(this.NewAntenna_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;
    }
}
