namespace BLAAutomation
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        private MaterialSkin.Controls.MaterialRaisedButton btnCreateFuselage;
        private MaterialSkin.Controls.MaterialRaisedButton btnCreateProject;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddDevice;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddAntenna;
        private MaterialSkin.Controls.MaterialRaisedButton btnViewProjects;

        private void InitializeComponent()
        {
            this.btnCreateFuselage = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnCreateProject = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddDevice = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddAntenna = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnViewProjects = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // btnCreateFuselage
            // 
            this.btnCreateFuselage.Depth = 0;
            this.btnCreateFuselage.Location = new System.Drawing.Point(12, 70);
            this.btnCreateFuselage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateFuselage.Name = "btnCreateFuselage";
            this.btnCreateFuselage.Primary = true;
            this.btnCreateFuselage.Size = new System.Drawing.Size(260, 36);
            this.btnCreateFuselage.TabIndex = 0;
            this.btnCreateFuselage.Text = "Создать фюзеляж";
            this.btnCreateFuselage.UseVisualStyleBackColor = true;
            this.btnCreateFuselage.Click += new System.EventHandler(this.btnCreateFuselage_Click);
            // 
            // btnCreateProject
            // 
            this.btnCreateProject.Depth = 0;
            this.btnCreateProject.Location = new System.Drawing.Point(12, 112);
            this.btnCreateProject.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCreateProject.Name = "btnCreateProject";
            this.btnCreateProject.Primary = true;
            this.btnCreateProject.Size = new System.Drawing.Size(260, 36);
            this.btnCreateProject.TabIndex = 1;
            this.btnCreateProject.Text = "Создать проект";
            this.btnCreateProject.UseVisualStyleBackColor = true;
            this.btnCreateProject.Click += new System.EventHandler(this.btnCreateProject_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.Depth = 0;
            this.btnAddDevice.Location = new System.Drawing.Point(12, 154);
            this.btnAddDevice.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Primary = true;
            this.btnAddDevice.Size = new System.Drawing.Size(260, 36);
            this.btnAddDevice.TabIndex = 2;
            this.btnAddDevice.Text = "Добавить устройство";
            this.btnAddDevice.UseVisualStyleBackColor = true;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // btnAddAntenna
            // 
            this.btnAddAntenna.Depth = 0;
            this.btnAddAntenna.Location = new System.Drawing.Point(12, 196);
            this.btnAddAntenna.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddAntenna.Name = "btnAddAntenna";
            this.btnAddAntenna.Primary = true;
            this.btnAddAntenna.Size = new System.Drawing.Size(260, 36);
            this.btnAddAntenna.TabIndex = 3;
            this.btnAddAntenna.Text = "Добавить антенну";
            this.btnAddAntenna.UseVisualStyleBackColor = true;
            this.btnAddAntenna.Click += new System.EventHandler(this.btnAddAntenna_Click);
            // 
            // btnViewProjects
            // 
            this.btnViewProjects.Depth = 0;
            this.btnViewProjects.Location = new System.Drawing.Point(12, 238);
            this.btnViewProjects.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnViewProjects.Name = "btnViewProjects";
            this.btnViewProjects.Primary = true;
            this.btnViewProjects.Size = new System.Drawing.Size(260, 36);
            this.btnViewProjects.TabIndex = 4;
            this.btnViewProjects.Text = "Просмотр проектов";
            this.btnViewProjects.UseVisualStyleBackColor = true;
            this.btnViewProjects.Click += new System.EventHandler(this.btnViewProjects_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.btnViewProjects);
            this.Controls.Add(this.btnAddAntenna);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.btnCreateProject);
            this.Controls.Add(this.btnCreateFuselage);
            this.Name = "MainForm";
            this.Text = "BLAAutomation";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }


        #endregion

    }
}
