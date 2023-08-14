using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaCalculator
{
    public class Uma
    {
        public BasicValue basicValue { get; set; }
        public FieldLevel field { get; set; }
        public PositionLevel position { get; set; }
        public DistanceLevel distance { get; set; }
        public int starRating { get; set; }
        public int inherentSkillLevel { get; set; }
        public int inheritedSkillCount { get; set; }
        public List<Skill> skills { get; set; }

        public Uma(BasicValue basicValue, FieldLevel field, PositionLevel position, DistanceLevel distance, int starRating, int inherentSkillLevel, int inheritedSkillCount, List<Skill> skills)
        {
            this.basicValue = basicValue;
            this.field = field;
            this.position = position;
            this.distance = distance;
            this.starRating = starRating;
            this.inherentSkillLevel = inherentSkillLevel;
            this.inheritedSkillCount = inheritedSkillCount;
            this.skills = skills;
        }
    }

    /// <summary>
    /// 基础数值
    /// </summary>
    public class BasicValue
    {
        public int speed { get; set; }
        public int stamina { get; set; }
        public int strength { get; set; }
        public int willpower { get; set; }
        public int intellect { get; set; }

        public BasicValue(int speed, int stamina, int strength, int willpower, int intellect)
        {
            this.speed = speed;
            this.stamina = stamina;
            this.strength = strength;
            this.willpower = willpower;
            this.intellect = intellect;
        }
    }

    /// <summary>
    /// 场地适应性
    /// </summary>
    public class FieldLevel
    {
        public UmaLevel turfLevel { get; set; }
        public UmaLevel dirtLevel { get; set; }

        public FieldLevel(UmaLevel turfLevel, UmaLevel dirtLevel)
        {
            this.turfLevel = turfLevel;
            this.dirtLevel = dirtLevel;
        }
    }

    /// <summary>
    /// 位置适应性
    /// </summary>
    public class PositionLevel
    {
        public UmaLevel leadingLevel { get; set; }
        public UmaLevel frontLevel { get; set; }
        public UmaLevel middleLevel { get; set; }
        public UmaLevel backLevel { get; set; }

        public PositionLevel(UmaLevel leadingLevel, UmaLevel frontLevel, UmaLevel middleLevel, UmaLevel backLevel)
        {
            this.leadingLevel = leadingLevel;
            this.frontLevel = frontLevel;
            this.middleLevel = middleLevel;
            this.backLevel = backLevel;
        }
    }

    /// <summary>
    /// 距离适应性
    /// </summary>
    public class DistanceLevel
    {
        public UmaLevel sprintLevel { get; set; }
        public UmaLevel mileLevel { get; set; }
        public UmaLevel intermediateLevel { get; set; }
        public UmaLevel longLevel { get; set; }

        public DistanceLevel(UmaLevel sprintLevel, UmaLevel mileLevel, UmaLevel intermediateLevel, UmaLevel longLevel)
        {
            this.sprintLevel = sprintLevel;
            this.mileLevel = mileLevel;
            this.intermediateLevel = intermediateLevel;
            this.longLevel = longLevel;
        }
    }

    /// <summary>
    /// 等级
    /// </summary>
    public enum UmaLevel
    {
        G,
        F,
        E,
        D,
        C,
        B,
        A,
        S,
    }
}
