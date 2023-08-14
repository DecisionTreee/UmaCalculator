using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmaCalculator
{
    public class Skill
    {
        public string name_traditional { get; set; }
        public string name_simplified { get; set; }
        public SkillType type { get; set; }
        public SkillField field { get; set; }
        public SkillPosition position { get; set; }
        public SkillDistance distance { get; set; }
        public int score { get; set; }
        public int pt { get; set; }

        public Skill(string name_traditional, string name_simplified, SkillType type, SkillField field, SkillPosition position, SkillDistance distance, int score, int pt)
        {
            this.name_traditional = name_traditional;
            this.name_simplified = name_simplified;
            this.type = type;
            this.field = field;
            this.position = position;
            this.distance = distance;
            this.score = score;
            this.pt = pt;
        }

        public string PrintSkill()
        {
            string skillType_str = string.Empty;
            switch (type)
            {
                case SkillType.Red:
                    skillType_str = "红";
                    break;
                case SkillType.Yellow:
                    skillType_str = "黄";
                    break;
                case SkillType.Blue:
                    skillType_str = "蓝";
                    break;
                case SkillType.Green:
                    skillType_str = "绿";
                    break;
                case SkillType.Purple:
                    skillType_str = "紫";
                    break;
            }
            string skillField_str = string.Empty;
            switch (field)
            {
                case SkillField.General:
                    skillField_str = "通用";
                    break;
                case SkillField.Dirt:
                    skillField_str = "沙地";
                    break;
            }
            string skillPosition_str = string.Empty;
            switch (position)
            {
                case SkillPosition.General:
                    skillPosition_str = "通用";
                    break;
                case SkillPosition.Leading:
                    skillPosition_str = "领头";
                    break;
                case SkillPosition.Front:
                    skillPosition_str = "前列";
                    break;
                case SkillPosition.Middle:
                    skillPosition_str = "居中";
                    break;
                case SkillPosition.Back:
                    skillPosition_str = "后追";
                    break;
            }
            string skillDistance_str = string.Empty;
            switch (distance)
            {
                case SkillDistance.General:
                    skillDistance_str = "通用";
                    break;
                case SkillDistance.Sprint:
                    skillDistance_str = "短距离";
                    break;
                case SkillDistance.Mile:
                    skillDistance_str = "英里";
                    break;
                case SkillDistance.Intermediate:
                    skillDistance_str = "中距离";
                    break;
                case SkillDistance.Long:
                    skillDistance_str = "长距离";
                    break;
            }

            return $"{skillType_str}  {name_traditional}  {name_simplified}  {skillField_str}  {skillPosition_str}  {skillDistance_str}";
        }
    }

    /// <summary>
    /// 技能类型
    /// </summary>
    public enum SkillType
    {
        Red,
        Yellow,
        Blue,
        Green,
        Purple,
    }

    /// <summary>
    /// 场地条件
    /// </summary>
    public enum SkillField
    {
        General,
        Dirt,
    }

    /// <summary>
    /// 位置条件
    /// </summary>
    public enum SkillPosition
    {
        General,
        Leading,
        Front,
        Middle,
        Back,
    }

    /// <summary>
    /// 距离条件
    /// </summary>
    public enum SkillDistance
    {
        General,
        Sprint,
        Mile,
        Intermediate,
        Long,
    }
}
