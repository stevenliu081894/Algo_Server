using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models;

namespace AlgoServer.Controllers
{
    public class AlgoController : BaseAPIController
    {
        [HttpPost("getmealplan")]
        public APIResponse<GetUserInfoResponse> getMealPlan(GetUserInfoRequest req)
        {

            GetUserInfoResponse rep = new GetUserInfoResponse
            {
                test = req.test + 1
            };
            return APIResponse<GetUserInfoResponse>.Ok(rep);
        }

        [HttpPost("getexerciseplan")]
        public APIResponse<GetUserInfoResponse> getExercisePlan(GetUserInfoRequest req)
        {

            GetUserInfoResponse rep = new GetUserInfoResponse
            {
                test = req.test + 1
            };
            return APIResponse<GetUserInfoResponse>.Ok(rep);
        }
    }
}

