using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaCalculator
{
    public class InheritedCalculator
    {
        public static int ComputeScore(Tuple<int, int, int> others)
        {
            int score = 0;
            int starRating = others.Item1;
            int inherentSkillLevel = others.Item2;
            int inheritedSkillCount = others.Item3;

            if (starRating >= 1 && starRating <= 2)
                score += lowRankScoreMap[inherentSkillLevel];
            else
                score += highRankScoreMap[inherentSkillLevel];
            score += inheritedSkillCount * 180;

            return score;
        }

        public static Dictionary<int, int> lowRankScoreMap = new Dictionary<int, int>()
        {
            { 1, 120 },
            { 2, 240 },
            { 3, 360 },
            { 4, 480 },
            { 5, 600 },
        };

        public static Dictionary<int, int> highRankScoreMap = new Dictionary<int, int>()
        {
            { 1, 170 },
            { 2, 340 },
            { 3, 510 },
            { 4, 680 },
            { 5, 850 },
            { 6, 1020 },
        };
    }
}
