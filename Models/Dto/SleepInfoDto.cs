using System;
namespace AlgoServer.Models.Dto
{
	public class SleepInfoDto
	{
        public int pk { get; set; }
        public int body_info_fk { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }
        public decimal? awake { get; set; }
        public decimal? light_sleep { get; set; }
        public decimal? deep_sleep { get; set; }
        public decimal? rem { get; set; }
    }
}

