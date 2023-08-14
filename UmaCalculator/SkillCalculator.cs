using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UmaCalculator
{
    public class SkillCalculator
    {
        public static int ComputeScore(FieldLevel fieldLevel, PositionLevel positionLevel, DistanceLevel distanceLevel, List<Skill> skills)
        {
            int score = 0;
            foreach (Skill skill in skills) 
            {
                if (skill.field == SkillField.General && skill.position == SkillPosition.General && skill.distance == SkillDistance.General)
                    score += skill.score;
                else if (skill.field != SkillField.General)
                    switch (skill.field)
                    {
                        case SkillField.Dirt:
                            score += (int)Math.Round(skill.score * (1f + levelMap[fieldLevel.dirtLevel]));
                            break;
                    }
                else if (skill.position != SkillPosition.General)
                    switch (skill.position)
                    {
                        case SkillPosition.Leading:
                            score += (int)Math.Round(skill.score * (1f + levelMap[positionLevel.leadingLevel]));
                            break;
                        case SkillPosition.Front:
                            score += (int)Math.Round(skill.score * (1f + levelMap[positionLevel.frontLevel]));
                            break;
                        case SkillPosition.Middle:
                            score += (int)Math.Round(skill.score * (1f + levelMap[positionLevel.middleLevel]));
                            break;
                        case SkillPosition.Back:
                            score += (int)Math.Round(skill.score * (1f + levelMap[positionLevel.backLevel]));
                            break;
                    }
                else if (skill.distance != SkillDistance.General)
                    switch (skill.distance)
                    {
                        case SkillDistance.Sprint:
                            score += (int)Math.Round(skill.score * (1f + levelMap[distanceLevel.sprintLevel]));
                            break;
                        case SkillDistance.Mile:
                            score += (int)Math.Round(skill.score * (1f + levelMap[distanceLevel.mileLevel]));
                            break;
                        case SkillDistance.Intermediate:
                            score += (int)Math.Round(skill.score * (1f + levelMap[distanceLevel.intermediateLevel]));
                            break;
                        case SkillDistance.Long:
                            score += (int)Math.Round(skill.score * (1f + levelMap[distanceLevel.longLevel]));
                            break;
                    }
            }

            return score;
        }

        public static Dictionary<UmaLevel, float> levelMap = new Dictionary<UmaLevel, float>()
        {
            { UmaLevel.S, 0.1f },
            { UmaLevel.A, 0.1f },
            { UmaLevel.B, -0.1f },
            { UmaLevel.C, -0.1f },
            { UmaLevel.D, -0.2f },
            { UmaLevel.E, -0.2f },
            { UmaLevel.F, -0.2f },
            { UmaLevel.G, -0.3f },
        };
    }
}
