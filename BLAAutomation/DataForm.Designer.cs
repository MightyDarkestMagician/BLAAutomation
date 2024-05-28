namespace BLAAutomation
{
    partial class DataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDeleteCompartment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddCompartment = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewCompartments = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDeleteDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewDevices = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewAntennas = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompartments)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAntennas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Depth = 0;
            this.tabControl1.Location = new System.Drawing.Point(50, 89);
            this.tabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 315);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeleteCompartment);
            this.tabPage1.Controls.Add(this.buttonAddCompartment);
            this.tabPage1.Controls.Add(this.dataGridViewCompartments);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 289);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Отсеки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCompartment
            // 
            this.buttonDeleteCompartment.Depth = 0;
            this.buttonDeleteCompartment.Location = new System.Drawing.Point(256, 20);
            this.buttonDeleteCompartment.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDeleteCompartment.Name = "buttonDeleteCompartment";
            this.buttonDeleteCompartment.Primary = true;
            this.buttonDeleteCompartment.Size = new System.Drawing.Size(144, 23);
            this.buttonDeleteCompartment.TabIndex = 2;
            this.buttonDeleteCompartment.Text = "Удалить Отсек";
            this.buttonDeleteCompartment.UseVisualStyleBackColor = true;
            this.buttonDeleteCompartment.Click += new System.EventHandler(this.buttonDeleteCompartment_Click);
            // 
            // buttonAddCompartment
            // 
            this.buttonAddCompartment.Depth = 0;
            this.buttonAddCompartment.Location = new System.Drawing.Point(58, 20);
            this.buttonAddCompartment.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddCompartment.Name = "buttonAddCompartment";
            this.buttonAddCompartment.Primary = true;
            this.buttonAddCompartment.Size = new System.Drawing.Size(144, 23);
            this.buttonAddCompartment.TabIndex = 1;
            this.buttonAddCompartment.Text = "Добавить Отсек";
            this.buttonAddCompartment.UseVisualStyleBackColor = true;
            this.buttonAddCompartment.Click += new System.EventHandler(this.buttonAddCompartment_Click);
            // 
            // dataGridViewCompartments
            // 
            this.dataGridViewCompartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCompartments.Location = new System.Drawing.Point(58, 49);
            this.dataGridViewCompartments.Name = "dataGridViewCompartments";
            this.dataGridViewCompartments.Size = new System.Drawing.Size(342, 219);
            this.dataGridViewCompartments.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDeleteDevice);
            this.tabPage2.Controls.Add(this.buttonAddDevice);
            this.tabPage2.Controls.Add(this.dataGridViewDevices);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 289);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Устройства";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteDevice
            // 
            this.buttonDeleteDevice.Depth = 0;
            this.buttonDeleteDevice.Location = new System.Drawing.Point(256, 25);
            this.buttonDeleteDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDeleteDevice.Name = "buttonDeleteDevice";
            this.buttonDeleteDevice.Primary = true;
            this.buttonDeleteDevice.Size = new System.Drawing.Size(144, 36);
            this.buttonDeleteDevice.TabIndex = 5;
            this.buttonDeleteDevice.Text = "Удалить Устройство";
            this.buttonDeleteDevice.UseVisualStyleBackColor = true;
            this.buttonDeleteDevice.Click += new System.EventHandler(this.buttonDeleteDevice_Click);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Depth = 0;
            this.buttonAddDevice.Location = new System.Drawing.Point(58, 25);
            this.buttonAddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Primary = true;
            this.buttonAddDevice.Size = new System.Drawing.Size(144, 36);
            this.buttonAddDevice.TabIndex = 4;
            this.buttonAddDevice.Text = "Добавить Устройство";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // dataGridViewDevices
            // 
            this.dataGridViewDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevices.Location = new System.Drawing.Point(58, 67);
            this.dataGridViewDevices.Name = "dataGridViewDevices";
            this.dataGridViewDevices.Size = new System.Drawing.Size(342, 201);
            this.dataGridViewDevices.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonDeleteAntenna);
            this.tabPage3.Controls.Add(this.buttonAddAntenna);
            this.tabPage3.Controls.Add(this.dataGridViewAntennas);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(458, 289);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Антенны";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAntenna
            // 
            this.buttonDeleteAntenna.Depth = 0;
            this.buttonDeleteAntenna.Location = new System.Drawing.Point(256, 20);
            this.buttonDeleteAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDeleteAntenna.Name = "buttonDeleteAntenna";
            this.buttonDeleteAntenna.Primary = true;
            this.buttonDeleteAntenna.Size = new System.Drawing.Size(144, 23);
            this.buttonDeleteAntenna.TabIndex = 5;
            this.buttonDeleteAntenna.Text = "Удалить Антенну";
            this.buttonDeleteAntenna.UseVisualStyleBackColor = true;
            this.buttonDeleteAntenna.Click += new System.EventHandler(this.buttonDeleteAntenna_Click);
            // 
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.Depth = 0;
            this.buttonAddAntenna.Location = new System.Drawing.Point(58, 20);
            this.buttonAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Primary = true;
            this.buttonAddAntenna.Size = new System.Drawing.Size(144, 23);
            this.buttonAddAntenna.TabIndex = 4;
            this.buttonAddAntenna.Text = "Добавить Антенну";
            this.buttonAddAntenna.UseVisualStyleBackColor = true;
            this.buttonAddAntenna.Click += new System.EventHandler(this.buttonAddAntenna_Click);
            // 
            // dataGridViewAntennas
            // 
            this.dataGridViewAntennas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAntennas.Location = new System.Drawing.Point(58, 49);
            this.dataGridViewAntennas.Name = "dataGridViewAntennas";
            this.dataGridViewAntennas.Size = new System.Drawing.Size(342, 219);
            this.dataGridViewAntennas.TabIndex = 3;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "DataForm";
            this.Text = "EquipmentForm";
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCompartments)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevices)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAntennas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridViewCompartments;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddCompartment;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDeleteCompartment;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDeleteDevice;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddDevice;
        private System.Windows.Forms.DataGridView dataGridViewDevices;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDeleteAntenna;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;
        private System.Windows.Forms.DataGridView dataGridViewAntennas;
    }
}
