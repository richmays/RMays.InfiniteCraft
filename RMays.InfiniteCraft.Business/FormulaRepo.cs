using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RMays.InfiniteCraft.Business
{
    public class FormulaRepo : IFormulaRepo
    {
        // Simple way: Store everything as strings.  No integer lookups.
        private Dictionary<string, string> Formulas { get; set; }
        private HttpClient httpClient { get; set; }
        private string FormulasFilename { get; set; }

        /// <summary>
        /// All the strings that can be mixed.
        /// Key: The word itself
        /// Value: The 'level' of the word.
        ///     0 is a starting word
        ///     1 is any of the 16 that can be formed by combining level 0 words, etc
        ///     -1 is the word 'Nothing' which can't be combined with anything.
        /// </summary>
        private Dictionary<string, int> Words { get; set; }

        public FormulaRepo()
        {
            FormulasFilename = "";
            Words = new Dictionary<string, int>
            {
                { "Nothing", -1 },
                { "Water", 0 },
                { "Fire", 0 },
                { "Wind", 0 },
                { "Earth", 0 },
            };
            Formulas = new Dictionary<string, string>();
            httpClient = new();
        }

        public FormulaRepo(string _formulasFilename) : base()
        {
            FormulasFilename = _formulasFilename;
        }

        public string LoadFormulasFromFile()
        {
            if (string.IsNullOrWhiteSpace(this.FormulasFilename))
            {
                return "No filename name; no formulas will be read.";
            }

            var fileContents = "";
            if (!File.Exists(this.FormulasFilename))
            {
                //Console.WriteLine($"File '{this.FormulasFilename}' not found; no formulas will be read.  Creating file...");
                File.Create(this.FormulasFilename);
                //Console.WriteLine("Done!");
                //return;
                return $"File '{this.FormulasFilename}' not found; no formulas will be read.  Creating file... done!";
            }
                
            using (var reader = new StreamReader(this.FormulasFilename))
            {
                fileContents = reader.ReadToEnd();
            }

            return $"File contents: {fileContents}";
        }

        public bool TryAdd(string item1, string item2, string result)
        {
            var key = GetKey(item1, item2);
            if (Formulas.ContainsKey(key))
            {
                return false;
            }

            Formulas.Add(key, result);
            return true;
        }

        public List<Tuple<string, string>> GetAllWordCombos()
        {
            var allCombos = new List<Tuple<string, string>>();
            foreach (var word1 in Words.Keys.Where(x => x != "Nothing"))
            {
                foreach (var word2 in Words.Keys.Where(x => x != "Nothing"))
                {
                    allCombos.Add(new Tuple<string, string>(word1, word2));
                }
            }

            // Shuffle the list!
            Random rng = new Random(0);
            int n = allCombos.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = allCombos[k];
                allCombos[k] = allCombos[n];
                allCombos[n] = value;
            }

            return allCombos;
        }

        private string GetKey(string item1, string item2)
        {
            return item1.CompareTo(item2) < 0 ? $"{item1}+{item2}" : $"{item2}+{item1}";
        }

        public bool FormulaExists(string item1, string item2)
        {
            return Formulas.ContainsKey(GetKey(item1, item2));
        }

        public async Task<PairResponse> Mix(string item1, string item2)
        {
            //return "Shortcut";

            var key = GetKey(item1, item2);
            if (Formulas.ContainsKey(key))
            {
                Console.WriteLine($"{key}->{Formulas[key]}");
                return new PairResponse(Formulas[key]);
            }

            try
            {
                string? jsonResponse;
                HttpResponseMessage response;
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Get,
                    "https:" + $"//neal.fun/api/infinite-craft/pair?first={item1}&second={item2}"))
                {
                    requestMessage.Headers.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/122.0.0.0 Safari/537.36");
                    requestMessage.Headers.Add("Accept", @"*/*");
                    //requestMessage.Headers.Add("Accept-Encoding", @"gzip, deflate, br, zstd");
                    requestMessage.Headers.Add("Accept-Encoding", @"deflate, br, zstd");
                    requestMessage.Headers.Add("Referer", "https://neal.fun/infinite-craft/");
                    response = await httpClient.SendAsync(requestMessage);

                    response.EnsureSuccessStatusCode();
                    jsonResponse = await response.Content.ReadAsStringAsync();
                }

                Thread.Sleep(500);

                PairResponse pairResponse = new PairResponse();
                try
                {
                    pairResponse = JsonSerializer.Deserialize<PairResponse>(jsonResponse) ?? new PairResponse();
                }
                catch (Exception ex)
                {
                    // Couldn't parse the JSON!
                    pairResponse = new PairResponse { Error = $"Problem parsing JSON. Error: {ex}. Full response: {jsonResponse}" };
                    return pairResponse;
                }

                // Add the new information to the repo (to Words and Formulas).
                if (!Words.ContainsKey(pairResponse.result))
                {
                    int newLevel = Math.Max(Words[item1], Words[item2]) + 1;
                    Words.Add(pairResponse.result, newLevel);
                }

                if (!Formulas.ContainsKey(GetKey(item1, item2)))
                {
                    Formulas.Add(GetKey(item1, item2), pairResponse.result);
                }

                return pairResponse;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return new PairResponse { Error = ex.ToString() };
            }
        }

        private async Task CallMixerAsync(string item1, string item2)
        {
            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync($"?first={item1}&second={item2}");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse.ToString());
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var key in Formulas.Keys.OrderBy(x => x))
            {
                sb.Append($"{key}>{Formulas[key]};");
            }

            return sb.ToString();
        }
    }
}
