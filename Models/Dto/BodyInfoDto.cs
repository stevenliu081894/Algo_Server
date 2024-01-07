
namespace Models.Dto
{
    public class BodyInfoDto
    {
        public int pk { get; set; }
        public int member_fk { get; set; }
        public int blood { get; set; }
        public decimal weight { get; set; }
        public decimal arm_length { get; set; }
        public decimal leg_length { get; set; }
        public DateTime measure_time { get; set; }
    }
}
