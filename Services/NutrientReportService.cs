using System;
using AlgoServer.Internal;
using AlgoServer.Libs;
using AlgoServer.Models.Dto;
using Dapper;
using Models.Dto;

namespace AlgoServer.Services
{
	public class NutrientReportService
	{
        #region Dto
        public static NutrientReportDto Find(int pk)
        {
            string sql = @"SELECT * FROM `nutrient_report` WHERE `pk` = @pk";

            try
            {
                using var conn = DapperMysql.GetReadConnection();
                var param = DapperMysql.GetParameters(new { pk });
                return conn.QueryFirstOrDefault<NutrientReportDto>(sql, param);
            }
            catch (Exception ex)
            {
                LogLib.Log("[ExerciseItem][Find]" + ex.Message);
                return null;
            }
        }

        public static int FindPkAfterInsert(NutrientReportDto source)
        {
            string sql = @"INSERT INTO `nutrient_report` (`user_id`, `data`, `measure_time`)
				VALUES (@user_id, @data, @measure_time);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, source);
            }
            catch (Exception ex)
            {
                LogLib.Log("[NutrientReportService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, $"write_db_exception {ex}");
            }
        }
        #endregion
    }
}

