using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewFuselage : MaterialForm
    {
        private string _connectionString;

        public NewFuselage(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void NewFuselage_Load(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("Loading NewFuselage");

                // Инициализация значений по умолчанию для текстовых полей
                textBoxName.Text = "Fuselage1";
                textBoxLength.Text = "10";
                textBoxWeight.Text = "500";

                // Настройка обработчиков событий для элементов управления
                buttonAddFuselage.Click += buttonAddFuselage_Click;

                Console.WriteLine("NewFuselage loaded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void buttonAddFuselage_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string name = textBoxName.Text;
                    double length = double.Parse(textBoxLength.Text);
                    double weight = double.Parse(textBoxWeight.Text);
                    Fuselage.AddFuselage(connection, name, length, weight);
                    MessageBox.Show("Фюзеляж успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.textBoxLength = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxWeight = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonAddFuselage = new MaterialSkin.Controls.MaterialRaisedButton();
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
            // textBoxLength
            // 
            this.textBoxLength.Depth = 0;
            this.textBoxLength.Hint = "Length";
            this.textBoxLength.Location = new System.Drawing.Point(12, 107);
            this.textBoxLength.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.PasswordChar = '\0';
            this.textBoxLength.SelectedText = "";
            this.textBoxLength.SelectionLength = 0;
            this.textBoxLength.SelectionStart = 0;
            this.textBoxLength.Size = new System.Drawing.Size(260, 23);
            this.textBoxLength.TabIndex = 1;
            this.textBoxLength.UseSystemPasswordChar = false;
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Depth = 0;
            this.textBoxWeight.Hint = "Weight";
            this.textBoxWeight.Location = new System.Drawing.Point(12, 136);
            this.textBoxWeight.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.PasswordChar = '\0';
            this.textBoxWeight.SelectedText = "";
            this.textBoxWeight.SelectionLength = 0;
            this.textBoxWeight.SelectionStart = 0;
            this.textBoxWeight.Size = new System.Drawing.Size(260, 23);
            this.textBoxWeight.TabIndex = 2;
            this.textBoxWeight.UseSystemPasswordChar = false;
            // 
            // buttonAddFuselage
            // 
            this.buttonAddFuselage.Depth = 0;
            this.buttonAddFuselage.Location = new System.Drawing.Point(12, 165);
            this.buttonAddFuselage.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddFuselage.Name = "buttonAddFuselage";
            this.buttonAddFuselage.Primary = true;
            this.buttonAddFuselage.Size = new System.Drawing.Size(260, 36);
            this.buttonAddFuselage.TabIndex = 3;
            this.buttonAddFuselage.Text = "Add Fuselage";
            this.buttonAddFuselage.UseVisualStyleBackColor = true;
            this.buttonAddFuselage.Click += new System.EventHandler(this.buttonAddFuselage_Click);
            // 
            // NewFuselage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 215);
            this.Controls.Add(this.buttonAddFuselage);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewFuselage";
            this.Text = "New Fuselage";
            this.Load += new System.EventHandler(this.NewFuselage_Load);
            this.ResumeLayout(false);
        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxLength;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxWeight;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddFuselage;
    }
}
