using System;
using AlgoServer.Internal;
using AlgoServer.Libs;
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
				display_name = req.display_name,
				id = req.id,
				identity_number = req.identity_number,
				gender = req.gender,
				birthday = req.birthday,
				weight = req.weight,
				height = req.height
			};
			if (MemberService.Find(memberDto.id) != null)
			{
                LogLib.Log("Member Already Existed");
                throw new AppException(1040, "Member Already Existed");
            }

			int pk = MemberService.FindPkAfterInsert(memberDto);

			return new SignUpResponse
			{
				pk = pk
			};
        }
	}
}

