using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AlgoServer.Data.Enums
{
    public enum WeightSuggestionEnum
    {
        underweight = 0,
        normal = 1,
        overweight = 2,
        fat = 3
    }

    public enum BodyConditionEnum
    {
        normal = 0,
        high_blood_pressure = 1,
        hyperlipidemia = 2,
        high_blood_sugar = 3,
        type1_kidney_disease = 4,
        type2_kidney_disease = 5,
        sarcopenia = 6
    }

    public enum StomachConditionEnum
    {
        normal = 0,
        constipate = 1,
        diarria = 2,
        abdominal_bloating = 3,
        nausea = 4,
        vomit = 5
    }

    public enum ExerciseNameEnum
    {
        weight_training = 2,
        stretch = 3,
        cardio = 4
    }



    public static class GetEnumStrings
    {
        public static string ConvertWeightSuggestion(int status)
        {
            return status switch
            {
                (int)WeightSuggestionEnum.underweight => "體重過輕",
                (int)WeightSuggestionEnum.normal => "體重正常",
                (int)WeightSuggestionEnum.overweight => "體重過重",
                (int)WeightSuggestionEnum.fat => "輕度肥胖"
            };
        }

        public static string ConvertBodyCondition(int status)
        {
            return status switch
            {
                (int)BodyConditionEnum.normal => "體重正常",
                (int)BodyConditionEnum.high_blood_pressure => "高血壓",
                (int)BodyConditionEnum.hyperlipidemia => "高血脂",
                (int)BodyConditionEnum.high_blood_sugar => "高血糖",
                (int)BodyConditionEnum.type1_kidney_disease => "第一期腎臟病",
                (int)BodyConditionEnum.type2_kidney_disease => "第二期腎臟病",
                (int)BodyConditionEnum.sarcopenia => "肌少症",
            };
        }

        public static string ConvertStomachCondition(int status)
        {
            return status switch
            {
                (int)StomachConditionEnum.normal => "正常",
                (int)StomachConditionEnum.constipate => "便秘",
                (int)StomachConditionEnum.diarria => "腹瀉",
                (int)StomachConditionEnum.abdominal_bloating => "腹脹",
                (int)StomachConditionEnum.nausea => "噁心",
                (int)StomachConditionEnum.vomit => "嘔吐"
            };
        }

        public static string ConvertExerciseName(int status)
        {
            return status switch
            {
                (int)ExerciseNameEnum.weight_training => "肌力訓練",
                (int)ExerciseNameEnum.stretch => "全身性伸展",
                (int)ExerciseNameEnum.cardio => "有氧運動",
            };
        }

        public static string ConvertMoveVName(int status)
        {
            return status switch
            {
                (int)ExerciseNameEnum.weight_training => "肌力訓練",
                (int)ExerciseNameEnum.stretch => "瑜珈",
                (int)ExerciseNameEnum.cardio => "燃脂有氧高間歇拳擊",
            };
        }

        public static int ConvertExerciseNameToId(string exercise_name)
        {
            return exercise_name switch
            {
                "肌力訓練" => (int)ExerciseNameEnum.weight_training,
                "全身性伸展" => (int)ExerciseNameEnum.stretch,
                "有氧運動" => (int)ExerciseNameEnum.cardio
            };
        }
    }
}

