using System;
using System.Collections.Generic;

namespace AlgoServer.Models.UserInfo
{
    public class BloodPressure
    {
        public decimal systolic { get; set; }
        public decimal diastolic { get; set; }
    }

    public class BloodOxygen
    {
        public decimal value { get; set; }
    }

    public class BodyTemperature
    {
        public decimal value { get; set; }
    }

    public class BodyFat
    {
        public decimal value { get; set; }
    }

    public class BodyWeight
    {
        public decimal value { get; set; }
    }

    public class PulseRate
    {
        public decimal value { get; set; }
        public string unit { get; set; }
    }

    public class BloodSugar
    {
        public string testing_time { get; set; }
        public int value { get; set; }
        public string range_type { get; set; }
    }

    public class Activity
    {
        public decimal calorie { get; set; }
        public decimal distance { get; set; }
        public int step { get; set; }
    }

    public class RelieveStress
    {
        public decimal value { get; set; }
    }

    public class CardiopulmonaryLevel
    {
        public decimal value { get; set; }
    }

    public class Hrv
    {
        public decimal sdnn { get; set; }
        public decimal rmssd { get; set; }
        public decimal lf { get; set; }
        public decimal rf { get; set; }
        public decimal rr { get; set; }
    }

    public class Sleep
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public decimal awake { get; set; }
        public decimal light_sleep { get; set; }
        public decimal deep_sleep { get; set; }
        public decimal rem { get; set; }
    }

    public class BodyData
    {
        public string id { get; set; }
        public DateTime measurement_time { get; set; }
        public BodyTemperature body_temperature { get; set; }
        public PulseRate pulse_rate { get; set; }
        public BloodPressure blood_pressure { get; set; }
        public BloodOxygen blood_oxygen { get; set; }
        public BodyWeight body_weight { get; set; }
        public BodyFat body_fat { get; set; }
        public BloodSugar blood_sugar { get; set; }
        public Activity activity { get; set; }
        public RelieveStress relieve_stress { get; set; }
        public CardiopulmonaryLevel cardiopulmonary_level { get; set; }
        public Hrv hrv { get; set; }
        public Sleep sleep { get; set; }
        public string note { get; set; }
    }

    public class UploadUserInfoRequest
    {
        public List<BodyData> _data { get; set; }
    }
}