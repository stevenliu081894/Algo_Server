using System;
using AlgoServer.Internal;
using AlgoServer.Libs;
using AlgoServer.Models.Dto;
using Dapper;
using Models.Dto;

namespace AlgoServer.Services
{
	public class UserInfoService
	{
        #region Dto

        public static int FindPkAfterInsert(BodyInfoDto bodyInfoDto)
        {
            string sql = @"INSERT INTO `body_info` (
				`member_fk`, `body_temperature`, `pulse_rate`, `blood_pressure_systolic`, `blood_pressure_diatolic`, `measure_time`, `blood_oxygen`,`body_weight`, `body_fat`,`relieve_stress`,  `cardiopulmonary_level`, `note`)
				VALUES (@member_fk, @body_temperature,  @pulse_rate,  @blood_pressure_systolic, @blood_pressure_diatolic, @measure_time, @blood_oxygen, @body_weight, @body_fat, @relieve_stress, @cardiopulmonary_level, @note);

                select @@IDENTITY;";

            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, bodyInfoDto);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }

        public static decimal FindPastOneWeekSteps(string user_id)
        {
            string sql = $"SELECT AVG(ai.step) AS average_steps FROM body_info bi INNER JOIN activity_info ai ON bi.pk = ai.body_info_fk  WHERE bi.measure_time >= DATE_SUB(CURDATE(), INTERVAL 1 WEEK) AND bi.member_fk = (SELECT member_fk FROM member WHERE id = '{ user_id}');";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, user_id);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                return 0;
            }
        }

        public static int FindPkAfterInsertBloodSugar(BloodSugarInfoDto bloodSugarInfoDto)
        {
            string sql = @"INSERT INTO `blood_sugar_info` (
				`body_info_fk`, `testing_time`, `value`, `range_type`)
				VALUES (@body_info_fk, @testing_time,  @value,  @range_type);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, bloodSugarInfoDto);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }

        public static int FindPkAfterInsertActivity(ActivityInfoDto activityInfoDTo)
        {
            string sql = @"INSERT INTO `activity_info` (
				`body_info_fk`, `calorie`, `distance`, `step`)
				VALUES (@body_info_fk, @calorie, @distance,  @step);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, activityInfoDTo);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }


        public static int FindPkAfterInsertHrv(HrvInfoDto hrvInfoDto)
        {
            string sql = @"INSERT INTO `hrv_info` (
			    `body_info_fk`, `sdnn`, `rmssd`, `lf`, `rf`, `rr`)
				VALUES (@body_info_fk, @sdnn, @rmssd,  @lf,  @rf,  @rr);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, hrvInfoDto);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }

        public static int FindPkAfterInsertSleep(SleepInfoDto sleepInfoDto)
        {
            string sql = @"INSERT INTO `sleep_info` (
				`body_info_fk`, `start_time`, `end_time`, `awake`, `light_sleep`, `deep_sleep`, `rem`)
				VALUES (@body_info_fk, @start_time,  @end_time,  @awake,  @light_sleep,  @deep_sleep, @rem);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, sleepInfoDto);
            }
            catch (Exception ex)
            {
                LogLib.Log("[UserInfoService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }
        #endregion
    }
}

