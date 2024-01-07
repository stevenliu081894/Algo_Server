using System;
namespace AlgoServer.Models.Dto
{
    public class ExerciseItemDto
    {
        //名稱
        public string name { get; set; }
        //項次
        public string type { get; set; }
        //時間
        public string time { get; set; }
        //熱量消耗
        public decimal calories_per_weight { get; set; }
        //頻率
        public string frequency { get; set; }
        //強度(THR)
        public int strength { get; set; }
    }
}

