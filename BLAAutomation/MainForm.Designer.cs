namespace BLAAutomation
{
    partial class MainForm
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

        private MaterialSkin.Controls.MaterialRaisedButton buttonAddAntenna;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddDevice;
        private MaterialSkin.Controls.MaterialRaisedButton buttonAddFuselage;

        private void InitializeComponent()
        {
            this.buttonAddAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddFuselage = new MaterialSkin.Controls.MaterialRaisedButton();
            // 
            // buttonAddAntenna
            // 
            this.buttonAddAntenna.Depth = 0;
            this.buttonAddAntenna.Location = new System.Drawing.Point(12, 78);
            this.buttonAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddAntenna.Name = "buttonAddAntenna";
            this.buttonAddAntenna.Primary = true;
            this.buttonAddAntenna.Size = new System.Drawing.Size(260, 36);
            this.buttonAddAntenna.TabIndex = 0;
            this.buttonAddAntenna.Text = "Add Antenna";
            this.buttonAddAntenna.UseVisualStyleBackColor = true;
            this.buttonAddAntenna.Click += new System.EventHandler(this.buttonAddAntenna_Click);
            // 
            // buttonAddDevice
            // 
            this.buttonAddDevice.Depth = 0;
            this.buttonAddDevice.Location = new System.Drawing.Point(12, 120);
            this.buttonAddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddDevice.Name = "buttonAddDevice";
            this.buttonAddDevice.Primary = true;
            this.buttonAddDevice.Size = new System.Drawing.Size(260, 36);
            this.buttonAddDevice.TabIndex = 1;
            this.buttonAddDevice.Text = "Add Device";
            this.buttonAddDevice.UseVisualStyleBackColor = true;
            this.buttonAddDevice.Click += new System.EventHandler(this.buttonAddDevice_Click);
            // 
            // buttonAddFuselage
            // 
            this.buttonAddFuselage.Depth = 0;
            this.buttonAddFuselage.Location = new System.Drawing.Point(12, 162);
            this.buttonAddFuselage.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddFuselage.Name = "buttonAddFuselage";
            this.buttonAddFuselage.Primary = true;
            this.buttonAddFuselage.Size = new System.Drawing.Size(260, 36);
            this.buttonAddFuselage.TabIndex = 2;
            this.buttonAddFuselage.Text = "Add Fuselage";
            this.buttonAddFuselage.UseVisualStyleBackColor = true;
            this.buttonAddFuselage.Click += new System.EventHandler(this.buttonAddFuselage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.buttonAddFuselage);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.buttonAddAntenna);
            this.Name = "MainForm";
            this.Text = "BLAAutomation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
        }


        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton buttonOpenAlgorithmForm;
    }
}
