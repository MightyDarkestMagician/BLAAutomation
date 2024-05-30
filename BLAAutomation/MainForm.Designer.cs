﻿namespace BLAAutomation
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
        private MaterialSkin.Controls.MaterialRaisedButton buttonOpenAlgorithmForm;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDrawScheme;

        private void InitializeComponent()
        {
            this.buttonAddAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonAddFuselage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonOpenAlgorithmForm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonDrawScheme = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
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
            // buttonOpenAlgorithmForm
            // 
            this.buttonOpenAlgorithmForm.Depth = 0;
            this.buttonOpenAlgorithmForm.Location = new System.Drawing.Point(12, 204);
            this.buttonOpenAlgorithmForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenAlgorithmForm.Name = "buttonOpenAlgorithmForm";
            this.buttonOpenAlgorithmForm.Primary = true;
            this.buttonOpenAlgorithmForm.Size = new System.Drawing.Size(260, 36);
            this.buttonOpenAlgorithmForm.TabIndex = 3;
            this.buttonOpenAlgorithmForm.Text = "Open Algorithm Form";
            this.buttonOpenAlgorithmForm.UseVisualStyleBackColor = true;
            this.buttonOpenAlgorithmForm.Click += new System.EventHandler(this.buttonOpenAlgorithmForm_Click);
            // 
            // buttonDrawScheme
            // 
            this.buttonDrawScheme.Depth = 0;
            this.buttonDrawScheme.Location = new System.Drawing.Point(12, 246);
            this.buttonDrawScheme.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDrawScheme.Name = "buttonDrawScheme";
            this.buttonDrawScheme.Primary = true;
            this.buttonDrawScheme.Size = new System.Drawing.Size(260, 36);
            this.buttonDrawScheme.TabIndex = 4;
            this.buttonDrawScheme.Text = "Draw Scheme";
            this.buttonDrawScheme.UseVisualStyleBackColor = true;
            this.buttonDrawScheme.Click += new System.EventHandler(this.buttonDrawScheme_Click);
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(12, 357);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(260, 36);
            this.materialRaisedButton1.TabIndex = 5;
            this.materialRaisedButton1.Text = "Draw Scheme";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 405);
            this.Controls.Add(this.materialRaisedButton1);
            this.Controls.Add(this.buttonDrawScheme);
            this.Controls.Add(this.buttonOpenAlgorithmForm);
            this.Controls.Add(this.buttonAddFuselage);
            this.Controls.Add(this.buttonAddDevice);
            this.Controls.Add(this.buttonAddAntenna);
            this.Name = "MainForm";
            this.Text = "BLAAutomation";
            this.ResumeLayout(false);

        }


        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
    }
}
