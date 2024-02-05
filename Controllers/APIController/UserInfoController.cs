using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models;
using AlgoServer.Business;


namespace AlgoServer.Controllers
{
    public class UserInfoController : BaseAPIController
    {
        [HttpPost("uploadUserInfo")]
        public APIResponse<UploadUserInfoResponse> UploadUserInfo(UploadUserInfoRequest req)
        {

            UserInfoBiz.UploadUserInfo(req);

            UploadUserInfoResponse rep = new UploadUserInfoResponse();

            return APIResponse<UploadUserInfoResponse>.Ok(rep);
        }
    }
}

