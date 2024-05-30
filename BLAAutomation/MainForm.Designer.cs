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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenAlgorithmForm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // buttonOpenAlgorithmForm
            // 
            this.buttonOpenAlgorithmForm.Depth = 0;
            this.buttonOpenAlgorithmForm.Location = new System.Drawing.Point(12, 79);
            this.buttonOpenAlgorithmForm.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonOpenAlgorithmForm.Name = "buttonOpenAlgorithmForm";
            this.buttonOpenAlgorithmForm.Primary = true;
            this.buttonOpenAlgorithmForm.Size = new System.Drawing.Size(200, 36);
            this.buttonOpenAlgorithmForm.TabIndex = 0;
            this.buttonOpenAlgorithmForm.Text = "Открыть Algorithm Form";
            this.buttonOpenAlgorithmForm.UseVisualStyleBackColor = true;
            this.buttonOpenAlgorithmForm.Click += new System.EventHandler(this.buttonOpenAlgorithmForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 389);
            this.Controls.Add(this.buttonOpenAlgorithmForm);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialRaisedButton buttonOpenAlgorithmForm;
    }
}
