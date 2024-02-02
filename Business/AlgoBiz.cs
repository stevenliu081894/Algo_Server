using System;
using System.Text;
using AlgoServer.Models.Algo;
using AlgoServer.Models.MemberOp;
using AlgoServer.Services;
using Models.Dto;
using AlgoServer.Models.Dto;
using Newtonsoft.Json;
using AlgoServer.Data.Enums;
using System.Text.Json;
using AlgoServer.Internal;
using AlgoServer.Libs;
using static AlgoServer.Models.Algo.TLCDietTable;

namespace AlgoServer.Business
{
    public class AlgoBiz
    {
        public static ReportModel CalculateReport(ReportModel report)
        {
            //ReportModel report = GetSampleReportModel();
            report.WeightCondition = GetWeightCondition(report);
            report.NutrientCondition = GetNutrientCondition(report);
            report.REE = GetREE(report);
            report.PAL = GetPAL(report); // how to get career
            report.TDEE = report.REE * report.PAL;

            string calorieSuggestion = GetCalorieSuggestion(report).Item1;
            float lowCalorieSuggestion = GetCalorieSuggestion(report).Item2;
            float highCalorieSuggestion = GetCalorieSuggestion(report).Item3;
            DietTable dietTable = GetDietTable(report);
            dietTable.GetRecommendIdx((highCalorieSuggestion + lowCalorieSuggestion)/2, report.gender);


            report.NutrientPlan = new NutrientPlanReport
            {
                CalorieSuggestion = calorieSuggestion,
                ProteinSuggestion = GetProteinSuggestion(report),
                WholeGrainPortion = dietTable.WholeGrain[dietTable.recommendIdx],
                MeatPortion = dietTable.Meat[dietTable.recommendIdx],
                FruitPortion = dietTable.Fruit[dietTable.recommendIdx],
                MilkPortion = dietTable.Milk[dietTable.recommendIdx],
                OilNutsPortion = dietTable.OilNuts[dietTable.recommendIdx],
                VegePortion = dietTable.Vege[dietTable.recommendIdx],
                MealPerDay = 3,
                SupplementsSuggestion = dietTable.supplementSuggestion,
                SpecialHealthSuggestion = dietTable.specialHealthSuggestion,
            };

            report.ExercisePlan = GetExercisePlan(report);
            report.AfterExerciseSupplement = GetAfterExerciseSupplement(report);
            if (MemberService.Find(report.id) != null)
            {
                NutrientReportService.FindPkAfterInsert(new NutrientReportDto
                {
                    user_id = report.id,
                    data = JsonConvert.SerializeObject(report),
                    measure_time = DateTime.Now
                });
            }

            return report;
        }

        public static ExerciseSupplement GetAfterExerciseSupplement(ReportModel report)
        {
            int intensity = GetIntensity(report);

            if (intensity == 1)
            {
                return new ExerciseSupplement
                {
                    Strength = "低強度",
                    Carbohydrate = $"{report.Weight * 1.2} g",
                    Protein = $"{report.Weight * 0.2} g",
                    Notice = ""
                };
            }
            else if (intensity == 2)
            {
                return new ExerciseSupplement
                {
                    Strength = "中強度",
                    Carbohydrate = $"{report.Weight * 1.4} g",
                    Protein = $"{report.Weight * 0.4} g",
                    Notice = ""
                };
            }
            else
            {
                return new ExerciseSupplement
                {
                    Strength = "高強度",
                    Carbohydrate = $"{report.Weight * 1.6} g",
                    Protein = $"{report.Weight * 0.5} g",
                    Notice = ""
                };
            }
        }

       
        public static int GetIntensity(ReportModel report)
        {
            int intensity = 1;
            if ((report.SARCF >= 4 && report.SARCF <= 7) || report.SOF == 2)
            {
                intensity = 2;
            }
            else if ((report.SARCF >= 8 || report.SARCF <= 10) || report.SOF <= 1)
            {
                intensity = 3;
            }
            return intensity;
        }

        public static ExercisePlanReport GetExercisePlan(ReportModel report)
        {


            int intensity = GetIntensity(report);

            List<ExerciseItemDto> exerciseItemDto =  ExerciseItemService.FindByStength(intensity);

            var groupExerciseItem = exerciseItemDto.GroupBy(item => item.name);
            List<ExerciseItemDto> suggestExerciseItems = new List<ExerciseItemDto>();

            foreach (var group in groupExerciseItem)
            {
                suggestExerciseItems.Add(group.ElementAt(new Random().Next(group.Count())));
            }


            List<ExerciseItemView> exerciseItemViews = suggestExerciseItems.Select(suggestExerciseItem =>
            {
                return new ExerciseItemView
                {
                    Name = suggestExerciseItem.name,
                    Type = suggestExerciseItem.type,
                    Time = suggestExerciseItem.time,
                    Calories = $"{report.Weight * (float)suggestExerciseItem.calories_per_weight} (kcal) ",
                    Frequency = suggestExerciseItem.frequency,
                    Strength =  GetExerciseStrengthStr(report),
                    MoveV = GetMoveV(suggestExerciseItem.name)
                };
            }).ToList();

            string notice = GetExerciseNotice(report);

            return new ExercisePlanReport
            {
                Exerciseitems = exerciseItemViews,
                Notice = notice
            };


        }

        public static string GetExerciseNotice(ReportModel model)
        {
            string notice = "";
            if (model.BodyCondition.Contains(1))
            {
                notice.Concat("運動必須慢慢加強運動強度、充分熱身、佩戴心跳監測器等 等。如果在運動過程中出現頭暈、面紅、不適等情況，必須 立即停止運動並尋求醫療協助。在開始運動前，需要量側血 壓情況，只有當血壓正常時才可以開始運動。如果收縮壓超 過 160mmHg、舒張壓高於 100mmHg，都不宜運動。 \n 高血壓人士禁止頭部向下/低於心臟的訓練動作、運動時閉 氣以及運動後立停下，應作輕鬆緩步行，深呼吸和伸展。運 動中時常監察血壓狀況，適時減小運動強度，運動時出現不 適症狀要立即停止運動，並尋求醫生協助。另外，高血壓患 者在選擇運動場所時，應避免在高溫，潮濕的環境中進行運 動，以免血壓升高。在運動時，要避免過度疲勞和長時間的 運動，以免影響身體的恢復和健康。");
            }
            if (model.BodyCondition.Contains(3))
            {
                notice.Concat("餐後 1-2 小時運動 \n 每週至少運動 5 次 \n 需注意是否有血糖過低現象");
            }
            return notice;
        }

        public static string GetMoveV(string exercise_type)
        {
            if (exercise_type == "有氧運動")
            {
                return "燃脂, 有氧, 高強度間歇, 拳擊";
            }

            if (exercise_type == "肌力訓練")
            {
                return "肌力訓練";
            }

            if (exercise_type == "全身性伸展")
            {
                return "瑜珈";
            }

            return "無對應項目";

        }


        public static string GetExerciseStrengthStr(ReportModel model)
        {
            int suggestbpm = 0;
            Random random = new Random();
            if (model.age <= 20)
            {
                suggestbpm = random.Next(100, 171);
            }
            else if (model.age > 20 && model.age <= 30)
            {
                suggestbpm = random.Next(95, 162);
            }
            else if (model.age > 30 && model.age <= 35)
            {
                suggestbpm = random.Next(93, 157);
            }
            else if (model.age > 35 && model.age <= 40)
            {
                suggestbpm = random.Next(90, 153);
            }
            else if (model.age > 40 && model.age <= 45)
            {
                suggestbpm = random.Next(88, 149);
            }
            else if (model.age > 45 && model.age <= 50)
            {
                suggestbpm = random.Next(85, 145);
            }
            else if (model.age > 50 && model.age <= 55)
            {
                suggestbpm = random.Next(83, 140);
            }
            else if (model.age > 55 && model.age <= 60)
            {
                suggestbpm = random.Next(80, 136);
            }
            else if (model.age > 60 && model.age <= 65)
            {
                suggestbpm = random.Next(78, 132);
            }
            else
            {
                suggestbpm = random.Next(75, 128);
            }

            return $"{suggestbpm} bpm";
        }

        public static DietTable GetDietTable(ReportModel model)
        {
            List<int> bodyCondition = model.BodyCondition;
            if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease) || bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease)))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure))
            {
                return new HighBloodPressureDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia))
            {
                return new TLCDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new HighBloodSugarDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease))
            {
                return new Type1KidneyDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease))
            {
                return new Type2KidneyDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.sarcopenia))
            {
                return new SarcopeniaDietTable(model.gender);
            }
            else
            {
                return new NormalDietTable(model.gender);
            }
        }

        public static DietTable GetExerciseTable(ReportModel model)
        {
            List<int> bodyCondition = model.BodyCondition;
            if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease) || bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease)))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new ComplexDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure))
            {
                return new HighBloodPressureDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia))
            {
                return new TLCDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar))
            {
                return new HighBloodSugarDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease))
            {
                return new Type1KidneyDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease))
            {
                return new Type2KidneyDiseaseDietTable(model.gender);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.sarcopenia))
            {
                return new SarcopeniaDietTable(model.gender);
            }
            else
            {
                return new NormalDietTable(model.gender);
            }
        }


        public static ReportModel GetSampleReportModel()
        {
            var path = "sample_model.json";
            string json = File.ReadAllText(path, Encoding.UTF8);
            ReportModel sampleReport = JsonConvert.DeserializeObject<ReportModel>(json);
            return sampleReport;
        }

        public static string GetWeightCondition(ReportModel model)
        {

            if (model.BMI < 18.5)
            {
                return GetEnumStrings.ConvertWeightSuggestion((int)WeightSuggestionEnum.underweight);
            }
            else if (model.BMI > 18.5 && model.BMI <= 24)
            {
                return GetEnumStrings.ConvertWeightSuggestion((int)WeightSuggestionEnum.normal);
            }
            else if (model.BMI > 24 && model.BMI <= 27)
            {
                return GetEnumStrings.ConvertWeightSuggestion((int)WeightSuggestionEnum.overweight);
            }
            else
            {
                return GetEnumStrings.ConvertWeightSuggestion((int)WeightSuggestionEnum.fat);
            }
        }

        public static string GetNutrientCondition(ReportModel model)
        {
            float BMI = model.BMI;
            float MNASF = model.MNASF;
            if (BMI <= 18.5 || MNASF < 7)
            {
                return "營養不良";
            }
            else
            {
                return "正常";
            }
        }

        public static float GetREE(ReportModel model)
        {
            if (model.gender == "female")
            {
                return (float)(10 * model.Weight + 6.25 * model.Height - 5 * model.age - 161);
            }
            else
            {
                return (float)(10 * model.Weight + 6.25 * model.Height - 5 * model.age + 5);
            }
        }

        public static float GetPAL(ReportModel model)
        {
            // how to get career
            if (model.gender == "female")
            {
                return (float)(10 * model.Weight + 6.25 * model.Height - 5 * model.age - 161);
            }
            else
            {
                return (float)(10 * model.Weight + 6.25 * model.Height - 5 * model.age + 5);
            }
        }


        public static (string, float, float) GetCalorieSuggestion(ReportModel model)
        {
            float low_calorie = 0;
            float high_calorie = 0;

            if (model.BMI < 18.5)
            {
                low_calorie = model.TDEE + 300;
                high_calorie = model.TDEE + 500;
                return ($"{low_calorie}~{high_calorie} (kcal)", low_calorie, high_calorie) ;
            }
            else if (model.BMI >= 18.5 && model.BMI < 27)
            {
                return ($"{model.TDEE} (kcal)", model.TDEE, model.TDEE);
            }
            else
            {
                high_calorie = model.TDEE - 300;
                low_calorie = model.TDEE - 500;

                if (high_calorie < 1200)
                {
                    high_calorie = 1200;
                    low_calorie = 1000;
                }
                return ($"{low_calorie}~{high_calorie} (kcal)", low_calorie, high_calorie);
            }
        }


        public static string calculateGeneralDiseaseProtein(ReportModel model, float calorieSuggestion)
        {
            float low_protein = 0;
            float high_protein = 0;
            if (model.BMI < 18.5)
            {
                low_protein = (float)(calorieSuggestion * 0.18 / 4);
                high_protein = (float)(calorieSuggestion * 0.2 / 4);
            }
            else if (model.BMI >= 18.5 && model.BMI < 27)
            {
                low_protein = (float)(calorieSuggestion * 0.15 / 4);
                high_protein = (float)(calorieSuggestion * 0.17 / 4);
            }
            else
            {
                low_protein = (float)(calorieSuggestion * 0.13 / 4);
                high_protein = (float)(calorieSuggestion * 0.15 / 4);
            }
            return $"{low_protein}~{high_protein} (g)";
        }

        

        public static string GetProteinSuggestion(ReportModel model)
        {
            float low_protein = 0;
            float high_protein = 0;
            List<int> bodyCondition = model.BodyCondition;
            float BMI = model.BMI;

            var calorieSuggetion = GetCalorieSuggestion(model);

            if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar)) {
                return calculateGeneralDiseaseProtein(model, calorieSuggetion.Item2);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure) && (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease) || bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease))) {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(0.9* model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(0.8 * model.Weight);
                }
                else
                {
                    low_protein = (float)(0.8 * model.Weight);
                }
                return $"{low_protein} (g)";
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia) && bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar)) {
                return calculateGeneralDiseaseProtein(model, calorieSuggetion.Item2);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_pressure)) {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(1.2 * model.Weight);
                    high_protein = (float)(1.5 * model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1.2 * model.Weight);
                }
                else
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                return $"{low_protein}~{high_protein} (g)";
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.hyperlipidemia)) {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(1.2 * model.Weight);
                    high_protein = (float)(1.5 * model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1.2 * model.Weight);
                }
                else
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                return $"{low_protein}~{high_protein} (g)";
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.high_blood_sugar)) {
                return calculateGeneralDiseaseProtein(model, calorieSuggetion.Item2);
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type1_kidney_disease)) {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                else
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                return $"{low_protein}~{high_protein} (g)";
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.type2_kidney_disease)) {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(0.9 * model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(0.8 * model.Weight);
                }
                else
                {
                    low_protein = (float)(0.8 * model.Weight);
                }
                return $"{low_protein} (g)";
            }
            else if (bodyCondition.Contains((int)BodyConditionEnum.sarcopenia)) {
                return calculateGeneralDiseaseProtein(model, calorieSuggetion.Item2);
            }
            else {
                if (model.BMI < 18.5)
                {
                    low_protein = (float)(1.3 * model.Weight);
                    high_protein = (float)(1.5 * model.Weight);
                }
                else if (model.BMI >= 18.5 && model.BMI < 27)
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1.2 * model.Weight);
                }
                else
                {
                    low_protein = (float)(1 * model.Weight);
                    high_protein = (float)(1 * model.Weight);
                }
                return $"{low_protein}~{high_protein} (g)";
            }
        }   
    }
}

