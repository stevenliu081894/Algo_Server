﻿using System;
using System.Text;
using AlgoServer.Internal;
using AlgoServer.Libs;
using AlgoServer.Models.MemberOp;
using AlgoServer.Services;
using Models.Dto;
using Newtonsoft.Json;

namespace AlgoServer.Business
{
	public class MemberBiz
	{
        public static async Task<SignUpResponse> regiser(SignUpRequest req)
		{

			MemberDto memberDto = new MemberDto
			{
				display_name = req.display_name,
				id = req.id,
				identity_number = req.identity_number,
				gender = req.gender,
				birthday = req.birthday,
				weight = req.weight,
				height = req.height,
                member_type = req.member_type,
                register_time = DateTime.Now,
				email = req.email,
				phone = req.phone
            };


            if (MemberService.Find(memberDto.id) != null)
			{
                LogLib.Log("Member Already Existed");
                throw new AppException(1040, "Member Already Existed");
            }

			bool moveVRegister = true;
            if (MemberService.FindByPhone(memberDto.phone) != null)
            {
				moveVRegister = false;
            }

            int pk = MemberService.FindPkAfterInsert(memberDto);


			if (moveVRegister)
			{
                MoveVSignUpRequest moveVReq = new MoveVSignUpRequest
                {
                    login_type = 1,
                    FitGame_member_id = req.id,
                    FitGame_member_type = req.member_type,
                    name = req.display_name,
                    password = req.phone.Substring(req.phone.Length - 6),
                    account = req.phone
                };


                string moveVSignUpUrl = "https://release.hihealth.com.tw/api/users/register";
                HttpClient client = new HttpClient();
                string requestData = JsonConvert.SerializeObject(moveVReq);
                StringContent content = new StringContent(requestData, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(moveVSignUpUrl, content);
            }

			return new SignUpResponse
			{
				pk = pk
			};
        }
	}
}

