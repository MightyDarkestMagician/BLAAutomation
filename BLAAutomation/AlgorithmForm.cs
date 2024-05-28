using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BLAAutomation
{
    public partial class AlgorithmForm : MaterialForm
    {
        public AlgorithmForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void buttonRunAlgorithm_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxPopulationSize.Text, out int populationSize))
            {
                MessageBox.Show("Введите корректное значение для размера популяции.");
                return;
            }

            if (!int.TryParse(textBoxGenerations.Text, out int generations))
            {
                MessageBox.Show("Введите корректное значение для количества поколений.");
                return;
            }

            if (!double.TryParse(textBoxMutationRate.Text, out double mutationRate))
            {
                MessageBox.Show("Введите корректное значение для вероятности мутации.");
                return;
            }

            if (!double.TryParse(textBoxCrossoverRate.Text, out double crossoverRate))
            {
                MessageBox.Show("Введите корректное значение для вероятности кроссовера.");
                return;
            }

            int geneLength = 10; // Пример длины гена

            try
            {
                GeneticAlgorithm ga = new GeneticAlgorithm(populationSize, generations, mutationRate, crossoverRate, geneLength);
                ga.Run();

                Individual bestIndividual = ga.GetBestIndividual();
                MessageBox.Show($"Лучший индивидуум: {string.Join(",", bestIndividual.Genes)} с приспособленностью {bestIndividual.Fitness}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void AlgorithmForm_Load(object sender, EventArgs e)
        {
            // Логика, выполняемая при загрузке формы
        }
    }
}
