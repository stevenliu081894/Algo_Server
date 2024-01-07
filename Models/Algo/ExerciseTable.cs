using System;
using Org.BouncyCastle.Utilities;
using System.Xml.Linq;
using AlgoServer.Models.Dto;

namespace AlgoServer.Models.Algo
{
    public class ExercisePlanItem
    {
        public string Name { get; set; }
        // 0:低強度 1:中強度 2:高強度 
        public List<string> Time { get; set; }
        public List<string> Frequency { get; set; }
        public List<double> CaloriesPerWeight { get; set; }
    }

    public class ExerciseTable
    {
      
        public List<ExercisePlanItem> Items { get; set; }
        public string Name;

        public ExerciseTable()
        {
            Items = new List<ExercisePlanItem>();
        }

    }

    public class Aerobics : ExerciseTable
    {
        public Aerobics()
        {
            Name = "有氧運動";
            Items = new List<ExercisePlanItem>
            {
                new ExercisePlanItem
                {
                    Name = "慢走",
                    Time = new List<string> { "30分鐘", "45分鐘", "60分鐘"},
                    CaloriesPerWeight = new List<double> {1.75, 2.625, 3.5},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"},
                },
                new ExercisePlanItem
                {
                    Name = "健走",
                    Time = new List<string> { "30分鐘", "45分鐘", "60分鐘"},
                    CaloriesPerWeight = new List<double> {2.75, 4.125, 5.5},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"},
                },
                new ExercisePlanItem
                {
                    Name = "慢跑",
                    Time = new List<string> { "30分鐘", "45分鐘", "60分鐘"},
                    CaloriesPerWeight = new List<double> {4.1, 6.5, 8.1},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"},
                }
            };
        }
    }

    public class WeightTraining : ExerciseTable
    {
        public WeightTraining()
        {
            Name = "肌力訓練";
            Items = new List<ExercisePlanItem>
            {
                new ExercisePlanItem
                {
                    Name = "深蹲",
                    Time = new List<string> { "8下3組", "10下3組", "12下3組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "墊腳尖",
                    Time = new List<string> { "12下3組", "15下3組", "20下3組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "勾腳尖",
                    Time = new List<string> { "12下3組", "15下3組", "20下3組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "腹部核心",
                    Time = new List<string> { "8下3組", "10 下 3 組", "12 下 3 組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "二頭彎舉",
                    Time = new List<string> { "10 下 3 組", "12 下 3 組", "15 下 3 組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "站姿伏地挺身",
                    Time = new List<string> { "10下3組", "12下3組", "15下3組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                 new ExercisePlanItem
                {
                    Name = "夾背訓練",
                    Time = new List<string> { "10下3組", "12下3組", "15下3組" },
                    CaloriesPerWeight = new List<double> {3, 4.5, 6},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                }
            };
        }
    }

    public class WholeBodyStretch : ExerciseTable
    { 
        public WholeBodyStretch()
        {
            Name = "全身性伸展";
            Items = new List<ExercisePlanItem>
            {
                new ExercisePlanItem
                {
                    Name = "頸部(上下左右)",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "肩部外側",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "三頭肌",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "上背部",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "擴胸",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                new ExercisePlanItem
                {
                    Name = "前臂",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                 new ExercisePlanItem
                {
                    Name = "股四頭肌",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                },
                   new ExercisePlanItem
                {
                    Name = "腿後肌群",
                    Time = new List<string> { "30 秒 3 組", "45 秒 3 組", "60 秒 3 組" },
                    CaloriesPerWeight = new List<double> {1.15, 1.725, 2.3},
                    Frequency = new List<string> { "一週 3-5 天", "一週 3-5 天", "一週 3-5 天"}
                }
            };
        }
    }
}

