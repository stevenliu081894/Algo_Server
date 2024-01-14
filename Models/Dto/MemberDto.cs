

namespace Models.Dto
{
    public class MemberDto
    {
        public int pk { get; set; }
        public string id { get; set; }
        public string display_name { get; set; }
        public string birthday { get; set; } = "";
        public string gender { get; set; }
        public string identity_number { get; set; } = "";
        public decimal height { get; set; } = 0;
        public decimal weight { get; set; } = 0;
        public string email { get; set; } = "";
        public string phone { get; set; } = "";
    }
}
