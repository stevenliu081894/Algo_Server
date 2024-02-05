using System;
namespace AlgoServer.Models.Dto
{
	public class ActivityInfoDto
	{
        public int pk { get; set; }
        public int body_info_fk { get; set; }
        public decimal? calorie { get; set; }
        public decimal? distance { get; set; }
        public int? step { get; set; }
    }
}

