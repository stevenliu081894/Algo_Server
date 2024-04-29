using System;
namespace AlgoServer.Models.Dto
{
	public class UserExerciseInfoBackUpDto
	{
        public int pk { get; set; }
        public string user_id { get; set; }
        public string class_name { get; set; }
        public string exercise_name { get; set; }
        public int exercise_type { get; set; }
        public DateTime start_time { get; set; }
        // period use minute
        public int period { get; set; }
        public int average_heart_beat { get; set; }
        public decimal calorie { get; set; }
        public decimal score { get; set; }
    }
}

