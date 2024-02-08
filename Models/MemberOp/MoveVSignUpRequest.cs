using System;
namespace AlgoServer.Models.MemberOp
{
	public class MoveVSignUpRequest
	{
        public int login_type { set; get; }
        public string FitGame_member_id { set; get; }
        public string FitGame_member_type { set; get; }
        public string name { set; get; }
        public string password { set; get; } // YYYYMMDD
        public string account { set; get; }
    }
}

