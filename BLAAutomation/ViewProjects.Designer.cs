namespace BLAAutomation
{
    partial class ViewProjects
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxProjects;

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
            this.listBoxProjects = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxProjects
            // 
            this.listBoxProjects.FormattingEnabled = true;
            this.listBoxProjects.Location = new System.Drawing.Point(12, 70);
            this.listBoxProjects.Name = "listBoxProjects";
            this.listBoxProjects.Size = new System.Drawing.Size(260, 200);
            this.listBoxProjects.TabIndex = 0;
            // 
            // ViewProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.listBoxProjects);
            this.Name = "ViewProjects";
            this.Text = "View Projects";
            this.Load += new System.EventHandler(this.ViewProjects_Load);
            this.ResumeLayout(false);
        }
    }
}
