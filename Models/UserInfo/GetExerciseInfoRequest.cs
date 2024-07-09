using System;
namespace AlgoServer.Models.UserInfo
{
    public class GetExerciseInfoRequest
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public string member_type { get; set; } = "JUBO";
    }
}

