using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
   public class MemberDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IMemberDao MemberDao { get; set; }


        [TestMethod]
        public void TestMemberDao_AddMember()
        {
            Member member = new Member();

            member.name = "haotest";
            member.email = "haotest@gmail.com";
            member.password = "test";
            member.account = "test";
            member.sex = "boy";
            member.age = 21;
            MemberDao.AddMember(member);

            Member dbMember = MemberDao.GetMemberByName(member.name);
            Assert.IsNotNull(dbMember);
            Assert.AreEqual(member.name, dbMember.name);

            Console.WriteLine("會員性別為 = " + dbMember.sex);
            Console.WriteLine("會員名稱為 = " + dbMember.name);
            Console.WriteLine("會員信箱為 = " + dbMember.email);

            MemberDao.DeleteMember(dbMember);
            dbMember = MemberDao.GetMemberByName(member.name);
            Assert.IsNull(dbMember);
        }
    }
}
