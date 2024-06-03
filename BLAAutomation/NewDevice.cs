using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewDevice : MaterialForm
    {
        private string _connectionString;

        public NewDevice(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewDevice_Load(object sender, EventArgs e)
        {
            try
            {
                // Инициализация значений по умолчанию для текстовых полей
                textBoxName.Text = "Device1";

                // Настройка обработчиков событий для элементов управления
                buttonAddDevice.Click += buttonAddDevice_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string name = textBoxName.Text;
                    double power = 500.0;
                    double weight = 40.0;
                    double noiseImmunity = 300.0;
                    Device.AddDevice(connection, name, power, weight, noiseImmunity);
                    MessageBox.Show("Устройство успешно добавлено!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.buttonAddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // buttonAddDevice
            // 
            this.buttonAddDevice.Depth = 0;
            this.buttonAddDevice.Location = new System.Drawing.Point(12, 145);
            this.buttonAddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Primary = true;
            this.buttonAddDevice.Size = new System.Drawing.Size(260, 36);
            this.buttonAddDevice.TabIndex = 1;
            this.buttonAddDevice.Text = "Add Device";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // NewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 195);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewDevice";
            this.Text = "New Device";
            this.Load += new System.EventHandler(this.NewDevice_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddDevice;
    }
}
