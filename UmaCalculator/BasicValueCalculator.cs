using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaCalculator
{
    public class BasicValueCalculator
    {
        public static int ComputeScore(BasicValue basicValue)
        {
            string json = File.ReadAllText("score.json");
            BasicValueMap basicValueMap = JsonConvert.DeserializeObject<BasicValueMap>(json);
            Dictionary<int, int> map = basicValueMap.basicValue.Zip(basicValueMap.basicValueScore, (k, v) => new { key = k, value = v }).ToDictionary(item => item.key, item => item.value);
            
            int score = 0;
            score += map[basicValue.speed];
            score += map[basicValue.stamina];
            score += map[basicValue.strength];
            score += map[basicValue.willpower];
            score += map[basicValue.intellect];

            return score;
        }

        public class BasicValueMap
        {
            public List<int> basicValue { get; set; }
            public List<int> basicValueScore { get; set; }
        }
    }
}
