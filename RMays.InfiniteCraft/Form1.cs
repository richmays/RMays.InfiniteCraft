using RMays.InfiniteCraft.Business;

namespace RMays.InfiniteCraft
{
    public partial class Form1 : Form
    {
        private ItemMixer itemMixer = new ItemMixer();
        private int MaxLevelCalculated = 0;
        private static string FormulasFilename => "formulas.txt";
        private FormulaRepo formulaRepo = new FormulaRepo(FormulasFilename);

        public Form1()
        {
            InitializeComponent();
            Log("Started up.");
            Log("Loading known formulas...");
            string result = formulaRepo.LoadFormulasFromFile();
            Log(result);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Do a cross...thing for all the words.
            List<Tuple<string, string>> allWordCombos = formulaRepo.GetAllWordCombos();

            // Go through each pair!
            foreach (var item in allWordCombos)
            {
                if (formulaRepo.FormulaExists(item.Item1, item.Item2)) continue;

                var task = Task.Run(() => formulaRepo.Mix(item.Item1, item.Item2));
                task.Wait();
                Log($"Mixing '{item.Item1}' and '{item.Item2}' created '{task.Result.result}'");
            }
        }

        private void Log(string message)
        {
            txtLog.Text += message + Environment.NewLine;
        }
    }
}