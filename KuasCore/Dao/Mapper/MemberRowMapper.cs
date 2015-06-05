using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class MemberRowMapper : IRowMapper<Member>
    {
        public Member MapRow(IDataReader dataReader, int rowNum)
        {
            Member target = new Member();

            target.id = dataReader.GetInt32(dataReader.GetOrdinal("id"));
            target.name = dataReader.GetString(dataReader.GetOrdinal("name"));
            target.email = dataReader.GetString(dataReader.GetOrdinal("email"));
            target.age = dataReader.GetInt32(dataReader.GetOrdinal("age"));
            target.sex = dataReader.GetString(dataReader.GetOrdinal("sex"));
            target.account = dataReader.GetString(dataReader.GetOrdinal("account"));
            target.password = dataReader.GetString(dataReader.GetOrdinal("password"));
            return target;
        }
    }
}
