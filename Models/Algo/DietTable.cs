using System;
using AlgoServer.Data.Enums;

namespace AlgoServer.Models.Algo
{
    public class DietTable
    {
        public List<string> WholeGrain { get; set; }
        public List<string> Milk { get; set; }
        public List<string> Vege { get; set; }
        public List<string> Meat { get; set; }
        public List<string> Fruit { get; set; }
        public List<string> OilNuts { get; set; }
        public int recommendIdx { get; set; }
        public string supplementSuggestion { get; set; }
        public string specialHealthSuggestion { get; set; }

        public DietTable()
        {
            // Initialize the lists here with default values
            WholeGrain = new List<string>();
            Milk = new List<string>();
            Vege = new List<string>();
            Meat = new List<string>();
            Fruit = new List<string>();
            OilNuts = new List<string>();
            supplementSuggestion = "";
            specialHealthSuggestion = "";
        }

        public void GetRecommendIdx(float suggest_calorie, string gender)
        {
            if (gender == "male") {
                if (suggest_calorie > 1500 && suggest_calorie < 1700)
                {
                    recommendIdx = 0;
                }
                else if (suggest_calorie > 1500 && suggest_calorie < 1700)
                {
                    recommendIdx = 1;
                }
                else
                {
                    recommendIdx = 2;
                }
            }
            else
            {
                if (suggest_calorie > 1300 && suggest_calorie <= 1500)
                {
                    recommendIdx = 0;
                }
                else if (suggest_calorie > 1500 && suggest_calorie <= 1700)
                {
                    recommendIdx = 1;
                }
                else
                {
                    recommendIdx = 2;
                }
            }
            
        }
    }

    public class NormalDietTable : DietTable
    {
        public NormalDietTable(string gender)
        {
            if (gender == "male")
            {
                WholeGrain = new List<string> { "10-12", "12", "12-14" };
                Milk = new List<string> { "1.5", "1.5", "1.5" };
                Vege = new List<string> { "3", "4", "4-5" };
                Meat = new List<string> { "4-5", "5-6", "6-7" };
                Fruit = new List<string> { "2", "2-3", "3" };
                OilNuts = new List<string> { "3-4", "4-5", "5" };
            }
            else
            {
                WholeGrain = new List<string> { "8-10", "10", "10-12" };
                Milk = new List<string> { "1.5", "1.5", "1.5" };
                Vege = new List<string> { "3", "3", "3" };
                Meat = new List<string> { "3-4", "4-5", "5-6" };
                Fruit = new List<string> { "2", "2", "2" };
                OilNuts = new List<string> { "3-4", "4-5", "5" };
            }
        }
    }

    public class HighBloodPressureDietTable : DietTable
    {
        public HighBloodPressureDietTable(string sex)
        {
            if (sex == "female")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class TLCDietTable : DietTable
    {
        public TLCDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class ComplexDiseaseDietTable : DietTable
    {
        public ComplexDiseaseDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class HighBloodSugarDietTable : DietTable
    {
        public HighBloodSugarDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class Type1KidneyDiseaseDietTable : DietTable
    {
        public Type1KidneyDiseaseDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class Type2KidneyDiseaseDietTable : DietTable
    {
        public Type2KidneyDiseaseDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }

    public class SarcopeniaDietTable : DietTable
    {
        public SarcopeniaDietTable(string sex)
        {
            if (sex == "male")
            {
                WholeGrain = new List<string> { "6-8", "8", "8-10" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "4", "4-5", "5-6" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
            else
            {
                WholeGrain = new List<string> { "4-6", "6", "6-8" };
                Milk = new List<string> { "2-3", "2-3", "2-3" };
                Vege = new List<string> { "4-5", "4-5", "4-5" };
                Meat = new List<string> { "3-4", "4-5", "5" };
                Fruit = new List<string> { "4-5", "4-5", "4-5" };
                OilNuts = new List<string> { "2-3", "2-3", "2-3" };
            }
        }
    }
}

