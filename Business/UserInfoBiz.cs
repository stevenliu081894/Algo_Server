﻿using System;
using AlgoServer.Models.UserInfo;
using Models.Dto;
using AlgoServer.Services;
using AlgoServer.Models.Dto;
using AlgoServer.Internal;
using AlgoServer.Libs;
using static Google.Protobuf.WellKnownTypes.Field.Types;

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
                note = bodyData.note,
            };

            if (bodyData.body_temperature != null)
            {
                bodyInfoDto.body_temperature = bodyData.body_temperature.value;
            }
            if (bodyData.blood_oxygen != null)
            {
                bodyInfoDto.blood_oxygen = bodyData.blood_oxygen.value;
            }
            if (bodyData.blood_pressure != null)
            {
                bodyInfoDto.blood_pressure_systolic = bodyData.blood_pressure.systolic;
                bodyInfoDto.blood_pressure_diastolic = bodyData.blood_pressure.diastolic;
            }
            if (bodyData.body_weight != null)
            {
                bodyInfoDto.body_weight = bodyData.body_weight.value;
            }
            if (bodyData.cardiopulmonary_level != null)
            {
                bodyInfoDto.cardiopulmonary_level = bodyData.cardiopulmonary_level.value;
            }
            if (bodyData.pulse_rate != null)
            {
                bodyInfoDto.pulse_rate = bodyData.pulse_rate.value;
            }
            if (bodyData.relieve_stress != null)
            {
                bodyInfoDto.relieve_stress = bodyData.relieve_stress.value;
            }
            if (bodyData.body_fat != null)
            {
                bodyInfoDto.body_fat = bodyData.body_fat.value;
            }


            int pk = UserInfoService.FindPkAfterInsert(bodyInfoDto);

            if (bodyData.activity != null)
            {
                ActivityInfoDto activityInfoDto = new ActivityInfoDto
                {
                    body_info_fk = pk,
                    calorie = bodyData.activity.calorie,
                    distance = bodyData.activity.distance,
                    step = bodyData.activity.step
                };
                UserInfoService.FindPkAfterInsertActivity(activityInfoDto);
            }


            if (bodyData.blood_sugar != null)
            {
                BloodSugarInfoDto bloodSugarInfoDto = new BloodSugarInfoDto
                {
                    body_info_fk = pk,
                    value = bodyData.blood_sugar.value,
                    testing_time = bodyData.blood_sugar.testing_time,
                    range_type = bodyData.blood_sugar.range_type
                };
                UserInfoService.FindPkAfterInsertBloodSugar(bloodSugarInfoDto);
            }


            if (bodyData.sleep != null)
            { 
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
                UserInfoService.FindPkAfterInsertSleep(sleepInfoDto);

            }

            if (bodyData.hrv != null)
            {
                HrvInfoDto hrvInfoDto = new HrvInfoDto
                {
                    body_info_fk = pk,
                    rf = bodyData.hrv.rf,
                    lf = bodyData.hrv.lf,
                    rmssd = bodyData.hrv.rmssd,
                    rr = bodyData.hrv.rr,
                    sdnn = bodyData.hrv.sdnn
                };
                UserInfoService.FindPkAfterInsertHrv(hrvInfoDto);
            }

        }

        public static void UploadExerciseInfo(UploadExerciseInfoRequest req)
        {

            MemberDto member =  MemberService.Find(req.user_id);
            if (member == null)
            {
                LogLib.Log("Member Not Existed");
                throw new AppException(1040, "Member Not Existed");
            }

            // calculate average heart beat
            if (req.average_heart_beat == null || req.average_heart_beat == 0)
            {
                decimal T = (decimal)req.period/3600;
                req.period = req.period / 60;
                decimal W = member.weight;


                if (W == 0)
                {
                    if (member.gender == "female")
                    {
                        W = 50;
                    }
                    else
                    {
                        W = 65;
                    }
                    
                }
                decimal A;

                try
                {
                    if (member.birthday == null)
                    {
                        A = 60;
                    }
                    else
                    {
                        A = DateTime.Now.Year - DateTime.Parse(member.birthday).Year;
                    }
                }
                catch
                {
                    A = 60;
                }

                

                if (member.gender == "male")
                {
                    req.average_heart_beat = (int)((req.calorie * (decimal)4.184 / (60 * T) + (decimal)55.0969 - (decimal)0.1988 * W - (decimal)0.2017 * A) / (decimal)0.6309) + 20;
                }
                else
                {
                    req.average_heart_beat = (int)((req.calorie * (decimal)4.4184 / (60 * T) + (decimal)20.4022 - (decimal)0.1263 * W - (decimal)0.074 * A) / (decimal)0.4472) + 20;
                }
                
            }
            UserExerciseInfoBackUpDto userExerciseInfoBackUpDto = new UserExerciseInfoBackUpDto
            {
                user_id = req.user_id,
                start_time = req.start_time,
                average_heart_beat = req.average_heart_beat,
                exercise_name = req.exercise_name,
                exercise_type = req.exercise_type,
                period = req.period,
                class_name = req.class_name,
                calorie = req.calorie,
                score = req.score,
                upload_time = DateTime.Now
            };
            UserInfoService.FindPkAfterUserExerciseInfoBackup(userExerciseInfoBackUpDto);
        }

        public static GetExerciseInfoResponse GetExerciseInfo(GetExerciseInfoRequest req)
        {
            List<UserExerciseInfoBackUpDto> userExerciseInfoBackUpDtos = UserInfoService.GetUserExerciseInfo(req.start_time, req.end_time, req.member_type);
            return new GetExerciseInfoResponse
            {
                userExerciseInfos = userExerciseInfoBackUpDtos
            };
        }
    }
}

