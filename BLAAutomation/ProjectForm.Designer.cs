namespace BLAAutomation
{
    partial class ProjectForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonCreateProject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.buttonDeleteProject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.dataGridViewProjects = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateProject
            // 
            this.buttonCreateProject.Depth = 0;
            this.buttonCreateProject.Location = new System.Drawing.Point(12, 80);
            this.buttonCreateProject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCreateProject.Name = "buttonCreateProject";
            this.buttonCreateProject.Primary = true;
            this.buttonCreateProject.Size = new System.Drawing.Size(200, 36);
            this.buttonCreateProject.TabIndex = 0;
            this.buttonCreateProject.Text = "Создать проект";
            this.buttonCreateProject.UseVisualStyleBackColor = true;
            this.buttonCreateProject.Click += new System.EventHandler(this.buttonCreateProject_Click);
            // 
            // buttonDeleteProject
            // 
            this.buttonDeleteProject.Depth = 0;
            this.buttonDeleteProject.Location = new System.Drawing.Point(218, 80);
            this.buttonDeleteProject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDeleteProject.Name = "buttonDeleteProject";
            this.buttonDeleteProject.Primary = true;
            this.buttonDeleteProject.Size = new System.Drawing.Size(200, 36);
            this.buttonDeleteProject.TabIndex = 1;
            this.buttonDeleteProject.Text = "Удалить проект";
            this.buttonDeleteProject.UseVisualStyleBackColor = true;
            this.buttonDeleteProject.Click += new System.EventHandler(this.buttonDeleteProject_Click);
            // 
            // dataGridViewProjects
            // 
            this.dataGridViewProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProjects.Location = new System.Drawing.Point(12, 134);
            this.dataGridViewProjects.Name = "dataGridViewProjects";
            this.dataGridViewProjects.Size = new System.Drawing.Size(406, 304);
            this.dataGridViewProjects.TabIndex = 2;
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 450);
            this.Controls.Add(this.dataGridViewProjects);
            this.Controls.Add(this.buttonDeleteProject);
            this.Controls.Add(this.buttonCreateProject);
            this.Name = "ProjectForm";
            this.Text = "ProjectForm";
            this.Load += new System.EventHandler(this.ProjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProjects)).EndInit();
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialRaisedButton buttonCreateProject;
        private MaterialSkin.Controls.MaterialRaisedButton buttonDeleteProject;
        private System.Windows.Forms.DataGridView dataGridViewProjects;
    }
}
