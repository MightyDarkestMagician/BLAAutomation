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
                Console.WriteLine("Loading NewDevice");

                // Инициализация значений по умолчанию для текстовых полей
                textBoxName.Text = "Device1";
                textBoxWeight.Text = "5";
                textBoxNoiseImmunity.Text = "10";

                // Настройка обработчиков событий для элементов управления
                buttonAddDevice.Click += buttonAddDevice_Click;

                Console.WriteLine("NewDevice loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}\n{ex.StackTrace}");
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
                    if (!double.TryParse(textBoxWeight.Text, out double weight) || weight <= 0)
                    {
                        MessageBox.Show("Неверное значение веса. Введите положительное число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!double.TryParse(textBoxNoiseImmunity.Text, out double noiseImmunity) || noiseImmunity < 0)
                    {
                        MessageBox.Show("Неверное значение помехоустойчивости. Введите неотрицательное число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    Device.AddDevice(connection, name, weight, noiseImmunity);
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
            this.textBoxWeight = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxNoiseImmunity = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            // textBoxWeight
            // 
            this.textBoxWeight.Depth = 0;
            this.textBoxWeight.Hint = "Weight";
            this.textBoxWeight.Location = new System.Drawing.Point(12, 145);
            this.textBoxWeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.PasswordChar = '\0';
            this.textBoxWeight.SelectedText = "";
            this.textBoxWeight.SelectionLength = 0;
            this.textBoxWeight.SelectionStart = 0;
            this.textBoxWeight.Size = new System.Drawing.Size(260, 23);
            this.textBoxWeight.TabIndex = 1;
            this.textBoxWeight.UseSystemPasswordChar = false;
            // 
            // textBoxNoiseImmunity
            // 
            this.textBoxNoiseImmunity.Depth = 0;
            this.textBoxNoiseImmunity.Hint = "Noise Immunity";
            this.textBoxNoiseImmunity.Location = new System.Drawing.Point(12, 212);
            this.textBoxNoiseImmunity.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxNoiseImmunity.Name = "textBoxNoiseImmunity";
            this.textBoxNoiseImmunity.PasswordChar = '\0';
            this.textBoxNoiseImmunity.SelectedText = "";
            this.textBoxNoiseImmunity.SelectionLength = 0;
            this.textBoxNoiseImmunity.SelectionStart = 0;
            this.textBoxNoiseImmunity.Size = new System.Drawing.Size(260, 23);
            this.textBoxNoiseImmunity.TabIndex = 2;
            this.textBoxNoiseImmunity.UseSystemPasswordChar = false;
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Depth = 0;
            this.buttonAddDevice.Location = new System.Drawing.Point(12, 279);
            this.buttonAddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Primary = true;
            this.buttonAddDevice.Size = new System.Drawing.Size(260, 36);
            this.buttonAddDevice.TabIndex = 3;
            this.buttonAddDevice.Text = "Add Device";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // NewDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 364);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.textBoxNoiseImmunity);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewDevice";
            this.Text = "New Device";
            this.Load += new System.EventHandler(this.NewDevice_Load);
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxWeight;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxNoiseImmunity;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddDevice;

        
    }
}
