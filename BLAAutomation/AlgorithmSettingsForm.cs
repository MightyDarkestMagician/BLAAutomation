using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class AlgorithmSettingsForm : MaterialForm
    {
        public AlgorithmSettingsForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void buttonRunAlgorithm_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBoxPopulationSize.Text, out int populationSize) || populationSize <= 0)
                {
                    MessageBox.Show("Неверное значение размера популяции. Введите положительное целое число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBoxGenerations.Text, out int generations) || generations <= 0)
                {
                    MessageBox.Show("Неверное значение количества поколений. Введите положительное целое число.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxMutationRate.Text, out double mutationRate) || mutationRate < 0 || mutationRate > 1)
                {
                    MessageBox.Show("Неверное значение вероятности мутации. Введите число от 0 до 1.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!double.TryParse(textBoxCrossoverRate.Text, out double crossoverRate) || crossoverRate < 0 || crossoverRate > 1)
                {
                    MessageBox.Show("Неверное значение вероятности кроссовера. Введите число от 0 до 1.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int geneLength = 10; // Пример длины гена

                GeneticAlgorithm ga = new GeneticAlgorithm(populationSize, generations, mutationRate, crossoverRate, geneLength);
                ga.Run();

                Individual bestIndividual = ga.GetBestIndividual();
                MessageBox.Show($"Лучший индивидуум: {string.Join(",", bestIndividual.Genes)} с приспособленностью {bestIndividual.Fitness}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Визуализация результатов
                Bitmap image = new Bitmap(800, 450); // Пример размера
                DrawScheme drawScheme = new DrawScheme(ga.GetProject(), image);
                drawScheme.DrawProject();
                drawScheme.DisplayOnForm(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AlgorithmForm_Load(object sender, EventArgs e)
        {
            // Логика, выполняемая при загрузке формы
        }
    }
}
