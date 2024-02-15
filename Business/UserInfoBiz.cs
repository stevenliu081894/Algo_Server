using System;
using AlgoServer.Models.UserInfo;
using Models.Dto;
using AlgoServer.Services;
using AlgoServer.Models.Dto;
using AlgoServer.Internal;
using AlgoServer.Libs;

namespace AlgoServer.Business
{
	public class UserInfoBiz
	{

        public static void UploadUserInfo(UploadUserInfoRequest req)
        {
            BodyData bodyData = req._data[0];

            MemberDto memberDto = MemberService.Find(bodyData.id);

            if (memberDto == null)
            {
                throw new AppException(1050, "User hasn't registered yet");
            }

            BodyInfoDto bodyInfoDto = new BodyInfoDto
            {
                member_fk = memberDto.pk,
                measure_time = bodyData.measurement_time,
                body_temperature = bodyData.body_temperature.value,
                blood_oxygen = bodyData.blood_oxygen.value,
                blood_pressure_systolic = bodyData.blood_pressure.systolic,
                blood_pressure_diastolic = bodyData.blood_pressure.diastolic,
                body_weight = bodyData.body_weight.value,
                cardiopulmonary_level = bodyData.cardiopulmonary_level.value,
                note = bodyData.note,
                pulse_rate = bodyData.pulse_rate.value,
                relieve_stress = bodyData.relieve_stress.value,
                body_fat = bodyData.body_fat.value
            };

            int pk = UserInfoService.FindPkAfterInsert(bodyInfoDto);

            ActivityInfoDto activityInfoDto = new ActivityInfoDto
            {
                body_info_fk = pk,
                calorie = bodyData.activity.calorie,
                distance = bodyData.activity.distance,
                step = bodyData.activity.step
            };

            BloodSugarInfoDto bloodSugarInfoDto = new BloodSugarInfoDto
            {
                body_info_fk = pk,
                value = bodyData.blood_sugar.value,
                testing_time = bodyData.blood_sugar.testing_time,
                range_type = bodyData.blood_sugar.range_type
            };

            SleepInfoDto sleepInfoDto = new SleepInfoDto
            {
                body_info_fk = pk,
                awake = bodyData.sleep.awake,
                start_time = bodyData.sleep.start_time,
                end_time = bodyData.sleep.end_time,
                light_sleep = bodyData.sleep.light_sleep,
                deep_sleep = bodyData.sleep.deep_sleep,
                rem = bodyData.sleep.rem
            };

            HrvInfoDto hrvInfoDto = new HrvInfoDto
            {
                body_info_fk = pk,
                rf = bodyData.hrv.rf,
                lf = bodyData.hrv.lf,
                rmssd = bodyData.hrv.rmssd,
                rr = bodyData.hrv.rr,
                sdnn = bodyData.hrv.sdnn
            };

            UserInfoService.FindPkAfterInsertActivity(activityInfoDto);
            UserInfoService.FindPkAfterInsertSleep(sleepInfoDto);
            UserInfoService.FindPkAfterInsertHrv(hrvInfoDto);
            UserInfoService.FindPkAfterInsertBloodSugar(bloodSugarInfoDto);
        }

        public static void UploadExerciseInfo(UploadExerciseInfoRequest req)
        {
            UserExerciseInfoBackUpDto userExerciseInfoBackUpDto = new UserExerciseInfoBackUpDto
            {
                user_id = req.user_id,
                start_time = req.start_time,
                average_heart_beat = req.average_heart_beat,
                exercise_name = req.exercise_name,
                exercise_type = req.exercise_type,
                period = req.period
            };
            UserInfoService.FindPkAfterUserExerciseInfoBackup(userExerciseInfoBackUpDto);
        }
    }
}

