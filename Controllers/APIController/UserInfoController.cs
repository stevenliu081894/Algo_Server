using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models.UserInfo;
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

        [HttpPost("uploadExerciseInfo")]
        public APIResponse<UploadExerciseInfoResponse> UploadExerciseInfo(UploadExerciseInfoRequest req)
        {

            UserInfoBiz.UploadExerciseInfo(req);

            UploadExerciseInfoResponse rep = new UploadExerciseInfoResponse();

            return APIResponse<UploadExerciseInfoResponse>.Ok(rep);
        }
    }
}

