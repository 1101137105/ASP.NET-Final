using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class MemberDao : GenericDao<Member>, IMemberDao
    {
        override protected IRowMapper<Member> GetRowMapper()
        {
            return new MemberRowMapper();
        }

        public void AddMember(Member member)
        {
            string command = @"INSERT INTO Member ( name, email,age,sex,account,password) VALUES ( @name,@email,@age, @sex,@account,@password);";

            IDbParameters parameters = CreateDbParameters();
       
            parameters.Add("name", DbType.String).Value = member.name;
            parameters.Add("email", DbType.String).Value = member.email;
            parameters.Add("age", DbType.Int32).Value = member.age;
            parameters.Add("sex", DbType.String).Value = member.sex;
            parameters.Add("account", DbType.String).Value = member.account;
            parameters.Add("password", DbType.String).Value = member.password;

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateMember(Member member)
        {
            string command = @"UPDATE Member SET name = @name, email = @email, age = @age, sex = @sex, account = @account, password = @password WHERE id = @id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.Int32).Value = member.id;
            parameters.Add("name", DbType.String).Value = member.name;
            parameters.Add("email", DbType.String).Value = member.email;
            parameters.Add("age", DbType.Int32).Value = member.age;
            parameters.Add("sex", DbType.String).Value = member.sex;
            parameters.Add("account", DbType.String).Value = member.account;
            parameters.Add("password", DbType.String).Value = member.password;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteMember(Member member)
        {
            string command = @"DELETE FROM Member WHERE id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.Int32).Value = member.id;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Member> GetAllMember()
        {
            string command = @"SELECT * FROM Member ORDER BY id ASC";
            IList<Member> member = ExecuteQueryWithRowMapper(command);
            return member;
        }

        public Member GetMemberByName(string name)
        {
            string command = @"SELECT * FROM Member WHERE name = @name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("name", DbType.String).Value = name;

            IList<Member> member = ExecuteQueryWithRowMapper(command, parameters);
            if (member.Count > 0)
            {
                return member[0];
            }

            return null;
        }

        public Member GetMemberById(int id)
        {
            string command = @"SELECT * FROM Member WHERE id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = id;

            IList<Member> member = ExecuteQueryWithRowMapper(command, parameters);
            if (member.Count > 0)
            {
                return member[0];
            }

            return null;
        }
    }
}
