using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Serilog;
using System.Text.Json;
using AlgoServer.Internal;
using AlgoServer.Validates;
using AlgoServer.Models.MemberOp;
using AlgoServer.Models;
using AlgoServer.Business;

namespace AlgoServer.Controllers
{
    public class MemberOpController : BaseAPIController
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MemberOpController(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }



        [HttpPost("signup")]
        public async Task<APIResponse<SignUpResponse>> SignUp(SignUpRequest req)
        {
            try
            {
                SignUpResponse rep = await MemberBiz.regiser(req);
                return APIResponse<SignUpResponse>.Ok(rep);
            }
            catch (AppException e)
            {
                return APIResponse<SignUpResponse>.Error(e.GetStatus(), e.GetMessage());
            }
        }
    }
}
