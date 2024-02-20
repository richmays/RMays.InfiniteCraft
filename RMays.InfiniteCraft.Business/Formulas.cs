using System.ComponentModel;

namespace RMays.InfiniteCraft.Business
{
    public class Formulas
    {
        /// <summary>
        /// Key: The word itself
        /// Value: Tuple of (word ID, level).
        ///   Level is the minimum number of matches needed to create it.
        ///   Water, Fire, Wind, and Earth are level 0.
        ///   Plant, Lava, Dust, Mountain, Wave, Smoke, Tornado, Steam, Volcano, and Lake are level 1.
        /// </summary>
        private Dictionary<string, Tuple<int, int>> Words { get; set; }

        /// <summary>
        /// Key: Tuple of (source word 1, source word 2).
        /// Value: word ID of the target word.
        /// Because of this data structure, both (item1, item2) and (item2, item1) are keys that point to the same value.
        /// </summary>
        private Dictionary<Tuple<int, int>, int> CreatedBy { get; set; }

        public Formulas()
        {
            // 'Nothing' is a special word that Can be combined, but can't be a selectable word,
            // so in the normal game, we can't use 'Nothing'.
            // All other words (and short phrases) are fair game.

            Words = new Dictionary<string, Tuple<int, int>>
            {
                { "Nothing", new Tuple<int, int>(-1, 0) },
                { "Water", new Tuple<int, int>(0, 0) },
                { "Fire", new Tuple<int, int>(1, 0) },
                { "Wind", new Tuple<int, int>(2, 0) },
                { "Earth", new Tuple<int, int>(3, 0) },
            };

            CreatedBy = new Dictionary<Tuple<int, int>, int>();
        }

        /// <summary>
        /// Returns the word's ID given a word.
        /// If it's not found, return -1.
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private int GetWordId(string word)
        {
            return Words.ContainsKey(word) ? Words[word].Item1 : -1;
        }

        public bool AddFormula(string input1, string input2, string result)
        {
            int word1Id = GetWordId(input1);
            int word2Id = GetWordId(input2);
            int resultId = GetWordId(result);
            if (word1Id == -1) return false;
            if (word2Id == -1) return false;

            // Check if the formula exists.
            if (CreatedBy.ContainsKey(new Tuple<int, int>(word1Id, word2Id)))
            {
                // Jump out; this formula already exists.
                return false;
            }

            // Add it, this is new!
            // Yes, if we get 'nothing', this is a valid result.
            CreatedBy.Add(new Tuple<int, int>(word1Id, word2Id), resultId);
            CreatedBy.Add(new Tuple<int, int>(word2Id, word1Id), resultId);

            return true;
        }
    }
}
