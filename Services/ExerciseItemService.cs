using System;
using AlgoServer.Internal;
using AlgoServer.Libs;
using Models.Dto;
using AlgoServer.Models.Dto;
using Dapper;

namespace AlgoServer.Services
{
	public class ExerciseItemService
	{
        #region Dto
        public static ExerciseItemDto Find(int pk)
        {
            string sql = @"SELECT * FROM `exercise_item` WHERE `pk` = @pk";

            try
            {
                using var conn = DapperMysql.GetReadConnection();
                var param = DapperMysql.GetParameters(new { pk });
                return conn.QueryFirstOrDefault<ExerciseItemDto>(sql, param);
            }
            catch (Exception ex)
            {
                LogLib.Log("[ExerciseItem][Find]" + ex.Message);
                return null;
            }
        }

        public static List<ExerciseItemDto> FindByStength(int strength)
        {
            string sql = @"SELECT * FROM `exercise_item` WHERE `strength` = @strength";

            try
            {
                using var conn = DapperMysql.GetReadConnection();
                var param = DapperMysql.GetParameters(new { strength });
                return conn.Query<ExerciseItemDto>(sql, param).AsList();
            }
            catch (Exception ex)
            {
                LogLib.Log("[ExerciseItem][FindByStength]" + ex.Message);
                return null;
            }
        }

        #endregion
    }
}

