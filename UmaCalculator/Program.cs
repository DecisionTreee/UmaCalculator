using Newtonsoft.Json;

namespace UmaCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {           
            ComputeScore();
        }

        public static BasicValue RequireBasicValue()
        {
            int speed, stamina, strength, willpower, intellect;
            string basicValue_str;
            do
            {
                Console.WriteLine("依次输入速度, 耐力, 力量, 意志力, 智力 (使用空格分隔) ");
                basicValue_str = Console.ReadLine();
            }
            while (basicValue_str == string.Empty);

            string[] basicValues_str = basicValue_str.Split(" ");
            try
            {
                speed = int.Parse(basicValues_str[0]);
                stamina = int.Parse(basicValues_str[1]);
                strength = int.Parse(basicValues_str[2]);
                willpower = int.Parse(basicValues_str[3]);
                intellect = int.Parse(basicValues_str[4]);
                return new BasicValue(speed, stamina, strength, willpower, intellect);
            }
            catch (Exception e)
            {
                Console.WriteLine("非法输入");
                Console.WriteLine(e.Message);
                RequireBasicValue();
                return new BasicValue(0, 0, 0, 0, 0);
            }
        }

        public static FieldLevel RequireFieldLevel()
        {
            string fieldLevel_str;
            do
            {
                Console.WriteLine("依次输入草地, 沙地的适应性 (使用空格分隔) ");
                fieldLevel_str = Console.ReadLine();
            }
            while (fieldLevel_str == string.Empty);

            string[] fieldLevels_str = fieldLevel_str.Split(" ");
            try
            {
                UmaLevel turfLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), fieldLevels_str[0]);
                UmaLevel dirtLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), fieldLevels_str[1]);
                FieldLevel fieldLevel = new FieldLevel(turfLevel, dirtLevel);
                return fieldLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine("非法输入");
                Console.WriteLine(e.Message);
                RequireFieldLevel();
                return new FieldLevel(UmaLevel.G, UmaLevel.G);
            }
        }

        public static PositionLevel RequirePositionLevel()
        {
            string positionLevel_str;
            do
            {
                Console.WriteLine("依次输入领头, 前列, 居中, 后追的适应性 (使用空格分隔) ");
                positionLevel_str = Console.ReadLine();
            }
            while (positionLevel_str == string.Empty);

            string[] positionLevels_str = positionLevel_str.Split(" ");
            try
            {
                UmaLevel leadingLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), positionLevels_str[0]);
                UmaLevel frontLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), positionLevels_str[1]);
                UmaLevel middleLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), positionLevels_str[2]);
                UmaLevel backLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), positionLevels_str[3]);
                PositionLevel positionLevel = new PositionLevel(leadingLevel, frontLevel, middleLevel, backLevel);
                return positionLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine("非法输入");
                Console.WriteLine(e.Message);
                RequirePositionLevel();
                return new PositionLevel(UmaLevel.G, UmaLevel.G, UmaLevel.G, UmaLevel.G);
            }
        }

        public static DistanceLevel RequireDistanceLevel()
        {
            string distanceLevel_str;
            do
            {
                Console.WriteLine("依次输入短距离, 英里, 中距离, 长距离的适应性 (使用空格分隔) ");
                distanceLevel_str = Console.ReadLine();
            }
            while (distanceLevel_str == string.Empty);

            string[] distanceLevels_str = distanceLevel_str.Split(" ");
            try
            {
                UmaLevel sprintLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), distanceLevels_str[0]);
                UmaLevel mileLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), distanceLevels_str[1]);
                UmaLevel intermediateLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), distanceLevels_str[2]);
                UmaLevel longLevel = (UmaLevel)Enum.Parse(typeof(UmaLevel), distanceLevels_str[3]);
                DistanceLevel distanceLevel = new DistanceLevel(sprintLevel, mileLevel, intermediateLevel, longLevel);
                return distanceLevel;
            }
            catch (Exception e)
            {
                Console.WriteLine("非法输入");
                Console.WriteLine(e.Message);
                RequirePositionLevel();
                return new DistanceLevel(UmaLevel.G, UmaLevel.G, UmaLevel.G, UmaLevel.G);
            }
        }

        public static Tuple<int, int, int> RequireOthers()
        {
            string starRating_str;
            do
            {
                Console.WriteLine("输入角色星数");
                starRating_str = Console.ReadLine();
            }
            while (starRating_str == string.Empty);

            string inherentSkillLevel_str;
            do
            {
                Console.WriteLine("输入角色固有技能等级");
                inherentSkillLevel_str = Console.ReadLine();
            }
            while (inherentSkillLevel_str == string.Empty);

            string inheritedSkillCount_str;
            do
            {
                Console.WriteLine("输入角色学习的固有技能数量 (不包括自己的固有) ");
                inheritedSkillCount_str = Console.ReadLine();
            }
            while (inheritedSkillCount_str == string.Empty);

            int starRating, inherentSkillLevel, inheritedSkillCount;
            try
            {
                starRating = int.Parse(starRating_str);
                inherentSkillLevel = int.Parse(inherentSkillLevel_str);
                inheritedSkillCount = int.Parse(inheritedSkillCount_str);
                return new Tuple<int, int, int>(starRating, inherentSkillLevel, inheritedSkillCount);
            }
            catch(Exception e) 
            {
                Console.WriteLine("非法输入");
                Console.WriteLine(e.Message);
                RequireOthers();
                return new Tuple<int, int, int>(0, 0, 0);
            }
        }

        public static Skill RequireSkill(List<Skill> allSkills)
        {
            string skillName;
            Console.WriteLine("输入技能名称 (支持模糊搜索, 不包括固有技能, 如果有上位技能请不要输入它的子技能 (如弧线的教授和弯道灵巧), 输入exit结束)");
            skillName = Console.ReadLine();

            if (skillName.ToLower() == "exit")
                return null;

            List<Skill> precise = allSkills.Where(item => item.name_traditional == skillName || item.name_simplified == skillName).ToList();
            if (precise.Count > 0)
                return precise[0];
            else
            {
                List<Skill> fuzzy = allSkills.Where(item => item.name_traditional.Contains(skillName) || item.name_simplified.Contains(skillName)).ToList();
                if (fuzzy.Count > 0)
                {
                    Console.WriteLine("序号   类型   繁中名   简中名   场地条件   位置条件   距离条件");
                    for (int i = 0; i < fuzzy.Count; i++)
                    {

                        Console.WriteLine($"[{i}]  {fuzzy[i].PrintSkill()}");
                    }
                a:
                    string num_str;
                    int num;
                    Console.WriteLine("输入序号");
                    num_str = Console.ReadLine();
                    try
                    {
                        num = int.Parse(num_str);
                        return fuzzy[num];
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("非法输入");
                        Console.WriteLine(e.Message);
                        goto a;
                    }
                }
                else
                {
                    Console.WriteLine("未找到对应的技能");
                    RequireSkill(allSkills);
                    return null;
                }
            }
        }

        public static List<Skill> RequireSkills()
        {
            string json = File.ReadAllText("skill.json");
            List<Skill> allSkills = JsonConvert.DeserializeObject<List<Skill>>(json);

            List<Skill> skills = new List<Skill>();
            while (true)
            {
                Skill skill = RequireSkill(allSkills);
                if (skill == null)
                    break;
                else
                    skills.Add(skill);
            }
            return skills;
        }

        public static void ComputeScore()
        {
            int score = 0;
            int basicValueScore = 0;
            int inheritedScore = 0;
            int skillScore = 0;

            BasicValue basicValue = RequireBasicValue();
            basicValueScore = BasicValueCalculator.ComputeScore(basicValue);
            Console.WriteLine($"基础分小计: {basicValueScore}");

            FieldLevel fieldLevel = RequireFieldLevel();
            PositionLevel positionLevel = RequirePositionLevel();
            DistanceLevel distanceLevel = RequireDistanceLevel();
            Tuple<int, int, int> others = RequireOthers();
            inheritedScore = InheritedCalculator.ComputeScore(others);
            Console.WriteLine($"固有分小计: {inheritedScore}");

            List<Skill> skills = RequireSkills();
            skillScore = SkillCalculator.ComputeScore(fieldLevel, positionLevel, distanceLevel, skills);
            Console.WriteLine($"技能分小计: {skillScore}");

            score = basicValueScore + inheritedScore + skillScore;
            Console.WriteLine($"总分: {score}");
        }
    }
}