using System;
using AlgoServer.Models.Dto;

namespace AlgoServer.Models.UserInfo
{
    public class GetExerciseInfoResponse
    {
        public List<UserExerciseInfoBackUpDto> userExerciseInfos { get; set; }
    }
}

