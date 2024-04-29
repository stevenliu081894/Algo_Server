using Microsoft.AspNetCore.Mvc;
using AlgoServer.Internal;
using AlgoServer.Models.UserInfo;
using AlgoServer.Business;
using AlgoServer.Models.Dto;


namespace AlgoServer.Controllers
{
    public class UserInfoController : BaseAPIController
    {
        [HttpPost("uploadUserInfo")]
        public APIResponse<UploadUserInfoResponse> UploadUserInfo(UploadUserInfoRequest req)
        {
            try
            {
                UserInfoBiz.UploadUserInfo(req);

                UploadUserInfoResponse rep = new UploadUserInfoResponse();

                return APIResponse<UploadUserInfoResponse>.Ok(rep);
            }
            catch (AppException e)
            {
                return APIResponse<UploadUserInfoResponse>.Error(e.GetStatus(), e.GetMessage());
            }
        }

        [HttpPost("uploadExerciseInfo")]
        public APIResponse<UploadExerciseInfoResponse> UploadExerciseInfo(UploadExerciseInfoRequest req)
        {
            try
            {
                UserInfoBiz.UploadExerciseInfo(req);

                UploadExerciseInfoResponse rep = new UploadExerciseInfoResponse();

                return APIResponse<UploadExerciseInfoResponse>.Ok(rep);
            }
            catch (AppException e)
            {
                return APIResponse<UploadExerciseInfoResponse>.Error(e.GetStatus(), e.GetMessage());
            }
        }

        [HttpPost("getExerciseInfo")]
        public APIResponse<List<UserExerciseInfoBackUpDto>> GetExerciseInfo(GetExerciseInfoRequest req)
        {
            try
            {
                GetExerciseInfoResponse rep = UserInfoBiz.GetExerciseInfo(req);

                return APIResponse<List<UserExerciseInfoBackUpDto>>.Ok(rep.userExerciseInfos);
            }
            catch (AppException e)
            {
                return APIResponse<List<UserExerciseInfoBackUpDto>>.Error(e.GetStatus(), e.GetMessage());
            }
        }
    }
}

