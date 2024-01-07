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
                (int)BodyConditionEnum.high_blood_pressure => "高血壓",
                (int)BodyConditionEnum.normal => "體重正常",
                (int)BodyConditionEnum.hyperlipidemia => "高血脂",
                (int)BodyConditionEnum.high_blood_sugar => "高血糖",
                (int)BodyConditionEnum.type1_kidney_disease => "第一期腎臟病",
                (int)BodyConditionEnum.type2_kidney_disease => "第二期腎臟病",
                (int)BodyConditionEnum.sarcopenia => "肌少症",
            };
        }
    }
}

