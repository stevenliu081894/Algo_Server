
namespace Models.Dto
{
    public class BodyInfoDto
    {
        public int pk { get; set; }
        public int member_fk { get; set; }
        public DateTime measure_time { get; set; }
        public decimal? body_temperature { get; set; }
        public decimal? blood_oxygen { get; set; }
        public decimal? blood_pressure_systolic { get; set; }
        public decimal? blood_pressure_diastolic { get; set; }
        public decimal? body_fat { get; set; }
        public decimal? body_weight { get; set; }
        public decimal? cardiopulmonary_level { get; set; }
        public string note { get; set; }
        public decimal? pulse_rate { get; set; }
        public decimal? relieve_stress { get; set; }
    }
}
