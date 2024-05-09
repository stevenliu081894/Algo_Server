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

            specialHealthSuggestion = "全穀雜糧類: 每天三餐中，至少要有1/3選用「未經精製」的全穀雜糧類 當作主食的來源，如糙米、胚芽米、紫米、全麥、蕃薯、馬 鈴薯、芋頭、南瓜、山藥、蓮藕、薏仁、藜麥、小米、紅 豆、綠豆、花豆、蠶豆、皇帝豆、栗子、蓮子、菱角等。\\n" +
                "乳品類: 乳品類包括鮮乳、低脂乳、脫脂乳、保久乳、奶粉、優酪 乳、優格、乳酪、冰淇淋等。和其他食物一起進食時喝牛奶 可以幫助減少乳糖不耐的症狀。規律由少漸增食用含乳糖的 食物（ 如：每天少量喝牛奶，持續 2 - 3 星期 ）也可幫助 身體適應乳糖而減少乳糖耐受不良的症狀。 \n 蔬菜類 : 蔬菜的維生素、礦物質、膳食纖維，以及植化素含量很豐 富。蔬菜的顏色越深綠或深黃，含有的維生素 A、C 及礦物 質鐵、鈣也越多。\n" +
                "豆魚蛋肉類: 豆魚蛋肉類食物是蛋白質的重要來源，應該盡量選擇植物性、脂肪含量較低的，並避免油炸和過度加工的食品。魚 類食物（ 包括各種魚、蝦、貝類、甲殼類、頭足類等水產 食物 ）含有豐富的動物性蛋白質，其 PUFA(polyunsaturated fatty acids)多於動物性蛋白質。可以連骨頭一起食用的魚類含有豐富的鈣質，如小魚干、吻 仔魚、櫻花蝦等。 黃豆及黃豆製品提供豐富植物性蛋白質，雖然缺乏甲硫胺 酸（ 人體的必需胺基酸之一 ），但同時與其他植物性食 物混合食用，就可以達到互補的效果，例如豆類和穀類、 豆類和堅果種子類等一起食用。 肉類食品包括家禽和家畜的肉、內臟及其製品，是飲食中 重要的蛋白質來源，但是肉類食品中也含有較多的飽和脂 肪，對心血管的健康較不利，宜適量選用較瘦的肉。肉類含有多種礦物質，顏色越紅的肉中鐵質含量越多。 蛋類主要指各種家禽的蛋，含有豐富的蛋白質，而且是所 有食物中蛋白質品質最佳的。除了蛋白質，蛋類也含有脂 肪，集中在蛋黃的部份；也含有豐富的維生素 A、維生素 B1、B2 和鐵、磷等礦物質。 食物優先順序應為豆類>魚類與海鮮>蛋類>禽肉、畜肉，且應避免加工肉品。\n"+
                "水果類: 水果含豐富的維生素、植化素及膳食纖維，其內部的水溶 性膳食纖維，可協助糞便軟化、提供益菌質幫助腸道好菌 增生。\n" +
                "油脂與堅果種子類: 日常飲食所使用的食用油應該以含單元不飽和脂肪酸為主，如橄欖油、苦茶油、芥花油、油菜籽油、花生油等植 物油，少用大豆油、玉米油、葵花油， 每天至少攝取一份堅果種子類， 例如花生、瓜子、葵瓜 子、芝麻、腰果、杏仁、核桃等，不僅含有 MUFA，亦包v含維生素Ｅ及礦物質等營養素，若長輩牙口不好，可選擇粉類製品，或購買後自行磨碎";
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

            specialHealthSuggestion = "豆魚蛋肉類選擇低脂食物，宜選用去皮的雞肉、魚肉、瘦 肉、蛋白、脫脂或低脂奶，且動物性蛋白質每日不超過 2 份，可多選擇燕麥、米糠、小麥胚芽、糙米、豆類、蘋果、洋 車前子、藍莓、大麥、豌豆、扁豆、杏仁、核桃、葵花 籽、南瓜籽高麗菜等食物，富含較多植物固醇及可溶性纖維";
        }


        public class ComplexDiseaseDietTable : DietTable
        {
            public ComplexDiseaseDietTable(string sex)
            {
                if (sex == "male")
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
                    WholeGrain = new List<string> { "10-12", "12", "12-14" };
                    Milk = new List<string> { "0.5", "0.5", "0.5" };
                    Vege = new List<string> { "3", "4", "4-5" };
                    Meat = new List<string> { "4-5", "5-6", "6-7" };
                    Fruit = new List<string> { "2", "2-3", "3" };
                    OilNuts = new List<string> { "3-4", "4-5", "5" };
                }
                else
                {
                    WholeGrain = new List<string> { "8-10", "10", "10-12" };
                    Milk = new List<string> { "0.5", "0.5", "0.5" };
                    Vege = new List<string> { "3", "3", "3" };
                    Meat = new List<string> { "3-4", "4-5", "5-6" };
                    Fruit = new List<string> { "2", "2", "2" };
                    OilNuts = new List<string> { "3-4", "4-5", "5" };
                }

                specialHealthSuggestion = "腎功能不全者，早期適當限制飲食中磷含量，可延緩腎 功能的衰退，預防腎骨病變的發生 ² 盡量避免含磷高的食物\n\nI. 乳製品：優格、乳酪、優酪乳、發酵乳\n\nII. 乾豆類：紅豆、綠豆、黑豆\n\nIII. 全穀類：蓮子、薏仁、糙米、全麥製品、小麥胚芽\n\nIV. 內臟類：豬肝、豬心、雞胗\n\nV. 堅果類：杏仁果、開心果、腰果、核桃、花生、瓜子、 栗子\n\nVI. 其他：酵母粉、可樂、汽水、可可、蛋黃、魚卵、肉 鬆、芝麻 ² 每日尿量>1000ml/day 不需限制鉀離子，若血鉀高或 尿量<1000ml/day，則限需限鉀，以下為減少鉀離子 攝取的營養建議\n\nI. 蔬菜：切小片，以滾水燙過後撈起再油炒或油拌， 避免食用精力湯或生菜\n\n58 II. 水果：避免食用高鉀水果，鉀含量>300mg/份之水 果有香瓜、哈密瓜、蜜瓜、桃子、奇異果、聖女番 茄、草莓等\n\nIII. 肉類：勿食用雞精、濃縮湯汁、肉汁等\n\nIV. 飲料：避免飲用咖啡、茶、人蔘、雞精、運動飲料 等\n\nV. 調味品：勿使用以鉀代替的低鈉鹽、健康美味鹽、 薄鹽、無鹽醬油等\n\nVI. 其他：堅果類、巧克力、梅子汁、蕃茄醬、乾燥水 果乾、藥膳湯等\n\nVII. 有合併高血壓患者，勿任意限胛 ² 鈉含量：若有水腫、高血壓、心臟病等患者，應配合限 鈉飲食，每日 2000mg~3000mg，約每日 8-10g 的 鹽，由於腎臟病患者亦須避免鉀離子過高，故應避免使 用低鈉鹽、薄鹽醬油等調味料\n\nI. 避免食用各種加工類食品：如醃製品、罐頭，並謹 慎使用醬油、烏醋、味精、味噌、沙茶醬、辣椒 醬、豆瓣醬、蕃茄醬等調味品\n\n59 II. 烹調時可用白糖、白醋、酒、蔥、薑、蒜、肉桂、\n\n五香、花椒、胡椒粉、香菜、檸檬汁等烹調";
            }
        }

        public class Type2KidneyDiseaseDietTable : DietTable
        {
            public Type2KidneyDiseaseDietTable(string sex)
            {
                if (sex == "male")
                {
                    WholeGrain = new List<string> { "9", "10", "11" };
                    Milk = new List<string> { "0.5", "0.5", "0.5" };
                    Vege = new List<string> { "3", "4", "4-5" };
                    Meat = new List<string> { "4", "4-5", "5-6" };
                    Fruit = new List<string> { "4-5", "4-5", "4-5" };
                    OilNuts = new List<string> { "2-3", "2-3", "2-3" };
                }
                else
                {
                    WholeGrain = new List<string> { "6", "8", "10" };
                    Milk = new List<string> { "0.5", "0.5", "0.5" };
                    Vege = new List<string> { "3", "3", "3" };
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
}

