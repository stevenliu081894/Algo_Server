using System;
using AlgoServer.Models.Dto;

namespace AlgoServer.Models.Algo
{
    public class ReportModel
    {
        // 基本資料
        public string name { get; set; }
        public string sex { get; set; } // M or W
        public int age { get; set; } 
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public string? WeightCondition { get; set; } = null; // model output
        public float MAC { get; set; }
        public float CC { get; set; }
        public float MNASF { get; set; }
        public string? NutrientCondition { get; set; } = null; // model output
        public float REE { get; set; } = 0; // model output
        public float PAL { get; set; } = 0; // model output
        public float TDEE { get; set; } = 0; // model output
        public List<int> BodyCondition { get; set; } // 0: 正常, 1:高血壓, 2:高血脂, 3:高血糖, 4:第一型腎臟病, 5:第一型腎臟病, 6:肌少症
        // 生化紀錄
        public float HBAIC { get; set; }
        public float FBG { get; set; }
        public float TC { get; set; }
        public float TG { get; set; }
        public float eGFR { get; set; }
        public float UPCR { get; set; }
        public float BUN { get; set; }
        public float CRE { get; set; }
        public string StomachCondition { get; set; }
        public string EdemaCondition { get; set; } //水腫狀況
        // 營養計畫
        public NutrientPlanReport? NutrientPlan { get; set; } = null;
        //運動能力
        public float SARCF { get; set; }
        public float SOF { get; set; }
        public float RPE { get; set; }
        public float GripStrength { get; set; }
        public int ThirtySecondsStand { get; set; }
        public int LeftBicepsArmsTest { get; set; }
        public int RightBicepsArmsTest { get; set; }
        public int LeftHandBackTest { get; set; }
        public int RightHandBackTest { get; set; }
        public int LeftPostureForwardBend { get; set; }
        public int RightPostureForwardBend { get; set; }
        public int ChairSittingAround { get; set; }
        public int StandRaiseKnees { get; set; }
        public string SpecialExerciseSuggestion { get; set; }
        // 運動計畫
        public ExercisePlanReport? ExercisePlan { get; set; } = null;
        public ExerciseSupplement? AfterExerciseSupplement { get; set; } = null;
    }

    public class NutrientPlanReport
    {
        public int MealPerDay { get; set; }
        public string CalorieSuggestion { get; set; }
        public string ProteinSuggestion { get; set; }
        public string WholeGrainPortion { get; set; }
        public string MeatPortion { get; set; }
        public string MilkPortion { get; set; }
        public string FruitPortion { get; set; }
        public string VegePortion { get; set; }
        public string OilNutsPortion { get; set; }
        public string SupplementsSuggestion { get; set; }
        public string SpecialHealthSuggestion { get; set; }
    }

    public class ExercisePlanReport
    {
        public List<ExerciseItemView> Exerciseitems { get; set; }
        public string Notice { get; set; }
    }


    public class ExerciseItemView
    {
        //名稱
        public string Name { get; set; }
        //項次
        public string Type { get; set; }
        //時間
        public string Time { get; set; }
        //熱量消耗
        public string Calories { get; set; }
        //頻率
        public string Frequency { get; set; }
        //強度(THR)
        public string Strength { get; set; }
    }
    public class ExerciseSupplement
    {
        //運動強度
        public string Strength { get; set; }
        //碳水化合物
        public string Carbohydrate { get; set; }
        //蛋白質
        public string Protein { get; set; }
        //備註
        public string Notice { get; set; }
    }
}

