using System;
namespace AlgoServer.Models.Dto
{
	public class BloodSugarInfoDto
	{
        public int pk { get; set; }
        public int body_info_fk { get; set; }
        public string testing_time { get; set; }
        public int? value { get; set; }
        public string range_type { get; set; }
    }
}

