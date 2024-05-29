using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class NewFuselage : MaterialForm
    {
        private SQLiteConnection _connection;

        public NewFuselage(SQLiteConnection connection)
        {
            InitializeComponent();
            _connection = connection;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void buttonAddFuselage_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBoxName.Text;
                Fuselage.AddFuselage(_connection, name);
                MessageBox.Show("Фюзеляж успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeComponent()
        {
            this.textBoxName = new MaterialSkin.Controls.MaterialSingleLineTextField();
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
            // buttonAddFuselage
            // 
            this.buttonAddFuselage.Depth = 0;
            this.buttonAddFuselage.Location = new System.Drawing.Point(12, 145);
            this.buttonAddFuselage.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddFuselage.Name = "buttonAddFuselage";
            this.buttonAddFuselage.Primary = true;
            this.buttonAddFuselage.Size = new System.Drawing.Size(260, 36);
            this.buttonAddFuselage.TabIndex = 1;
            this.buttonAddFuselage.Text = "Add Fuselage";
            this.buttonAddFuselage.UseVisualStyleBackColor = true;
            this.buttonAddFuselage.Click += new System.EventHandler(this.buttonAddFuselage_Click);
            // 
            // NewFuselage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddFuselage);
            this.Controls.Add(this.textBoxName);
            this.Name = "NewFuselage";
            this.Text = "New Fuselage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxName;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddFuselage;
    }
}
