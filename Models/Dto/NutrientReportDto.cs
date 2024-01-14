namespace Models.Dto
{
    public class NutrientReportDto
    {
        public int pk { get; set; }
        public string user_id { get; set; }
        public string data { get; set; }
        public DateTime measure_time { get; set; }
    }
}
