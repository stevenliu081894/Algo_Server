using System;
using AlgoServer.Models.MemberOp;
using AlgoServer.Services;
using Models.Dto;

namespace AlgoServer.Business
{
	public class MemberBiz
	{
        public static SignUpResponse regiser(SignUpRequest req)
		{

			MemberDto memberDto = new MemberDto
			{
				age = req.age,
				name = req.name,
				sex = req.sex
			};
			int pk = MemberService.FindPkAfterInsert(memberDto);

			return new SignUpResponse
			{
				pk = pk
			};
        }
	}
}

