using System;
using AlgoServer.Internal;
using AlgoServer.Libs;
using Dapper;
using Models.Dto;

namespace AlgoServer.Services
{
	public class MemberService
	{
        #region Dto

        public static MemberDto Find(int pk)
        {
            string sql = @"SELECT * FROM `member` WHERE `pk` = @pk";

            try
            {
                using var conn = DapperMysql.GetReadConnection();
                var param = DapperMysql.GetParameters(new { pk });
                return conn.QueryFirstOrDefault<MemberDto>(sql, param);
            }
            catch (Exception ex)
            {
                LogLib.Log("[MemberService][Find]" + ex.Message);
                return null;
            }
        }

        public static List<MemberDto> FindAll()
        {
            string sql = @"SELECT * FROM `member`";

            try
            {
                using var conn = DapperMysql.GetReadConnection();
                return conn.Query<MemberDto>(sql).AsList();
            }
            catch (Exception ex)
            {
                LogLib.Log("[MemberService][FindAll]" + ex.Message);
                return null;
            }
        }

        public static int FindPkAfterInsert(MemberDto source)
        {
            string sql = @"INSERT INTO `member` (
				`name`, `sex`, `age`)
				VALUES (@name, @sex, @age);

                select @@IDENTITY;";
            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.ExecuteScalar<int>(sql, source);
            }
            catch (Exception ex)
            {
                LogLib.Log("[MemberService][FindPkAfterInsert]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }

        public static int UpdateFull(MemberDto model)
        {
            string sql = @"UPDATE `member` SET 
				`name` = @name,
				`sex` = @sex,
				`age` = @age,
				 WHERE `pk` = @pk";

            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                return conn.Execute(sql, model);
            }
            catch (Exception ex)
            {
                LogLib.Log("[MemberService][UpdateFull]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }

        public static int Remove(int pk)
        {
            string sql = @"DELETE FROM `member` WHERE `pk` = @pk";

            try
            {
                using var conn = DapperMysql.GetWriteConntion();
                var param = DapperMysql.GetParameters(new { pk });
                return conn.Execute(sql, param);
            }
            catch (Exception ex)
            {
                LogLib.Log("[MemberService][Remove]" + ex.Message);
                throw new AppException(1030, "write_db_exception");
            }
        }
        #endregion
    }
}

