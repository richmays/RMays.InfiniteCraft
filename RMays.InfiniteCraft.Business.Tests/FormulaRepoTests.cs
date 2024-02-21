namespace RMays.InfiniteCraft.Business.Tests
{
    public class FormulaRepoTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TryAdd_DontAllowDupes()
        {
            IFormulaRepo formulaRepo = new FormulaRepo();
            bool result = formulaRepo.TryAdd("Earth", "Earth", "Mountain");
            Assert.IsTrue(result);
            result = formulaRepo.TryAdd("Earth", "Earth", "Mountain");
            Assert.IsFalse(result);
        }

        /// <summary>
        /// When we add a formula, the order of the first 2 items doesn't matter.
        /// So, make sure we don't allow swapping of the first two items.
        /// </summary>
        [Test]
        public void TryAdd_CheckForSwaps()
        {
            IFormulaRepo formulaRepo = new FormulaRepo();
            bool result = formulaRepo.TryAdd("Earth", "Fire", "Volcano");
            Assert.IsTrue(result);
            result = formulaRepo.TryAdd("Fire", "Earth", "Volcano");
            Assert.IsFalse(result);
        }

        [Test]
        public void ShowAllFormulas()
        {
            IFormulaRepo formulaRepo = new FormulaRepo();
            formulaRepo.TryAdd("Earth", "Earth", "Mountain");
            formulaRepo.TryAdd("Earth", "Fire", "Volcano");
            var repoAsString = formulaRepo.ToString();
            Assert.AreEqual("Earth+Earth>Mountain;Earth+Fire>Volcano;", repoAsString);
        }
    }
}