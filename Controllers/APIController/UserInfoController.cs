using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AlgoServer.Business;
using AlgoServer.Internal;
using AlgoServer.Models;


namespace AlgoServer.Controllers
{
    public class UserInfoController : BaseAPIController
    {
        [HttpPost("getUserInfo")]
        public APIResponse<GetUserInfoResponse> getUserInfo(GetUserInfoRequest req)
        {

            GetUserInfoResponse rep = new GetUserInfoResponse
            {
                test = req.test + 1
            };
            return APIResponse<GetUserInfoResponse>.Ok(rep);
        }
    }
}

