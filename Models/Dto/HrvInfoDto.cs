using System;
namespace AlgoServer.Models.Dto
{
	public class HrvInfoDto
	{
        public int pk { get; set; }
        public int body_info_fk { get; set; }
        public decimal? sdnn { get; set; }
        public decimal? rmssd { get; set; }
        public decimal? lf { get; set; }
        public decimal? rf { get; set; }
        public decimal? rr { get; set; }
    }
}

