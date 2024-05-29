using System;
using System.Drawing;
using System.Windows.Forms;

namespace BLAAutomation
{
    public class DrawScheme
    {
        private const double ScaleCoeff = 2.5;
        private Size DeviceSize = new Size(40, 30);
        private Size AntennaSize = new Size(30, 30);
        private Project SelectedProject;
        private Bitmap Image;

        public DrawScheme(Project project, Bitmap image)
        {
            SelectedProject = project;
            Image = image;
        }

        public void DrawProject()
        {
            DrawCompartments();
            DrawPositions();
            DrawAntennas();
        }

        private void DrawCompartments()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                foreach (var compartment in SelectedProject.Compartments)
                {
                    Rectangle rect = new Rectangle(
                        (int)((compartment.CoordinateX - compartment.Length / 2.0) * ScaleCoeff),
                        (int)((compartment.CoordinateY - compartment.Width / 2.0) * ScaleCoeff),
                        (int)(compartment.Length * ScaleCoeff),
                        (int)(compartment.Width * ScaleCoeff));

                    g.FillRectangle(Brushes.LightGray, rect);
                    g.DrawRectangle(Pens.Black, rect);
                    g.DrawString($"Отсек {compartment.Id}", SystemFonts.DefaultFont, Brushes.Black, rect.Location);
                }
            }
        }

        private void DrawPositions()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                foreach (var position in SelectedProject.Positions)
                {
                    Rectangle rect = new Rectangle(
                        (int)((position.CoordinateX - DeviceSize.Width / 2.0) * ScaleCoeff),
                        (int)((position.CoordinateY - DeviceSize.Height / 2.0) * ScaleCoeff),
                        DeviceSize.Width,
                        DeviceSize.Height);

                    g.FillRectangle(Brushes.LightGreen, rect);
                    g.DrawRectangle(Pens.DarkGreen, rect);
                    g.DrawString($"P{position.Id}", SystemFonts.DefaultFont, Brushes.Black, rect.Location);
                }
            }
        }

        private void DrawAntennas()
        {
            using (Graphics g = Graphics.FromImage(Image))
            {
                foreach (var antenna in SelectedProject.Antennas)
                {
                    Rectangle rect = new Rectangle(
                        (int)((antenna.CoordinateX - AntennaSize.Width / 2.0) * ScaleCoeff),
                        (int)((antenna.CoordinateY - AntennaSize.Height / 2.0) * ScaleCoeff),
                        AntennaSize.Width,
                        AntennaSize.Height);

                    g.FillRectangle(Brushes.LightBlue, rect);
                    g.DrawRectangle(Pens.Blue, rect);
                    g.DrawString($"A{antenna.Id}", SystemFonts.DefaultFont, Brushes.Black, rect.Location);
                }
            }
        }

        public void DisplayOnForm(Form form)
        {
            PictureBox pictureBox = new PictureBox
            {
                Image = Image,
                SizeMode = PictureBoxSizeMode.AutoSize
            };
            form.Controls.Add(pictureBox);
        }
    }
}
