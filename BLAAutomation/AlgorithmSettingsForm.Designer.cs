namespace BLAAutomation
{
    partial class AlgorithmSettingsForm
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
            this.textBoxPopulationSize = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxGenerations = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxMutationRate = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.textBoxCrossoverRate = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.buttonRunAlgorithm = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // textBoxPopulationSize
            // 
            this.textBoxPopulationSize.Depth = 0;
            this.textBoxPopulationSize.Hint = "Размер популяции";
            this.textBoxPopulationSize.Location = new System.Drawing.Point(12, 78);
            this.textBoxPopulationSize.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxPopulationSize.Name = "textBoxPopulationSize";
            this.textBoxPopulationSize.PasswordChar = '\0';
            this.textBoxPopulationSize.SelectedText = "";
            this.textBoxPopulationSize.SelectionLength = 0;
            this.textBoxPopulationSize.SelectionStart = 0;
            this.textBoxPopulationSize.Size = new System.Drawing.Size(260, 23);
            this.textBoxPopulationSize.TabIndex = 0;
            this.textBoxPopulationSize.UseSystemPasswordChar = false;
            // 
            // textBoxGenerations
            // 
            this.textBoxGenerations.Depth = 0;
            this.textBoxGenerations.Hint = "Количество поколений";
            this.textBoxGenerations.Location = new System.Drawing.Point(12, 107);
            this.textBoxGenerations.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxGenerations.Name = "textBoxGenerations";
            this.textBoxGenerations.PasswordChar = '\0';
            this.textBoxGenerations.SelectedText = "";
            this.textBoxGenerations.SelectionLength = 0;
            this.textBoxGenerations.SelectionStart = 0;
            this.textBoxGenerations.Size = new System.Drawing.Size(260, 23);
            this.textBoxGenerations.TabIndex = 1;
            this.textBoxGenerations.UseSystemPasswordChar = false;
            // 
            // textBoxMutationRate
            // 
            this.textBoxMutationRate.Depth = 0;
            this.textBoxMutationRate.Hint = "Вероятность мутации";
            this.textBoxMutationRate.Location = new System.Drawing.Point(12, 136);
            this.textBoxMutationRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxMutationRate.Name = "textBoxMutationRate";
            this.textBoxMutationRate.PasswordChar = '\0';
            this.textBoxMutationRate.SelectedText = "";
            this.textBoxMutationRate.SelectionLength = 0;
            this.textBoxMutationRate.SelectionStart = 0;
            this.textBoxMutationRate.Size = new System.Drawing.Size(260, 23);
            this.textBoxMutationRate.TabIndex = 2;
            this.textBoxMutationRate.UseSystemPasswordChar = false;
            // 
            // textBoxCrossoverRate
            // 
            this.textBoxCrossoverRate.Depth = 0;
            this.textBoxCrossoverRate.Hint = "Вероятность кроссовера";
            this.textBoxCrossoverRate.Location = new System.Drawing.Point(12, 165);
            this.textBoxCrossoverRate.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxCrossoverRate.Name = "textBoxCrossoverRate";
            this.textBoxCrossoverRate.PasswordChar = '\0';
            this.textBoxCrossoverRate.SelectedText = "";
            this.textBoxCrossoverRate.SelectionLength = 0;
            this.textBoxCrossoverRate.SelectionStart = 0;
            this.textBoxCrossoverRate.Size = new System.Drawing.Size(260, 23);
            this.textBoxCrossoverRate.TabIndex = 3;
            this.textBoxCrossoverRate.UseSystemPasswordChar = false;
            // 
            // buttonRunAlgorithm
            // 
            this.buttonRunAlgorithm.Depth = 0;
            this.buttonRunAlgorithm.Location = new System.Drawing.Point(12, 194);
            this.buttonRunAlgorithm.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonRunAlgorithm.Name = "buttonRunAlgorithm";
            this.buttonRunAlgorithm.Primary = true;
            this.buttonRunAlgorithm.Size = new System.Drawing.Size(260, 36);
            this.buttonRunAlgorithm.TabIndex = 4;
            this.buttonRunAlgorithm.Text = "Запустить алгоритм";
            this.buttonRunAlgorithm.UseVisualStyleBackColor = true;
            this.buttonRunAlgorithm.Click += new System.EventHandler(this.buttonRunAlgorithm_Click);
            // 
            // AlgorithmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRunAlgorithm);
            this.Controls.Add(this.textBoxCrossoverRate);
            this.Controls.Add(this.textBoxMutationRate);
            this.Controls.Add(this.textBoxGenerations);
            this.Controls.Add(this.textBoxPopulationSize);
            this.Name = "AlgorithmForm";
            this.Text = "AlgorithmForm";
            this.Load += new System.EventHandler(this.AlgorithmForm_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxPopulationSize;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxGenerations;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxMutationRate;
        private MaterialSkin.Controls.MaterialSingleLineTextField textBoxCrossoverRate;
        private MaterialSkin.Controls.MaterialRaisedButton buttonRunAlgorithm;
    }
}
