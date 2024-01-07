namespace Models.Dto
{
    public class NutrientReport
    {
        public int pk { get; set; }
        public int member_fk { get; set; }
        public string data { get; set; }
        public DateTime measure_time { get; set; }
    }
}
