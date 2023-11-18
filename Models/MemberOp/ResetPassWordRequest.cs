using System;
namespace AlgoServer.Models.MemberOp
{
	public class ResetPassWordRequest
	{
        public string old_pw { set; get; }
        public string new_pw { set; get; }
    }
}

