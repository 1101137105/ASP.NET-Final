using KuasCore.Models;
using KuasCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    class MemberServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {
        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }
        public IMemberService MemberService { get; set; }
        [TestMethod]
        public void TestMemberService_AddMember()
        {

            Member member = new Member();

            member.name = "haotest";
            member.email = "haotest@gmail.com";
            member.password = "test";
            member.account = "test";
            member.sex = "boy";
            member.age = 21;
            MemberService.AddMember(member);

            Member dbMember = MemberService.GetMemberByName(member.name);
            Assert.IsNotNull(dbMember);
            Assert.AreEqual(member.name, dbMember.name);

            Console.WriteLine("會員性別為 = " + dbMember.sex);
            Console.WriteLine("會員名稱為 = " + dbMember.name);
            Console.WriteLine("會員信箱為 = " + dbMember.email);

            MemberService.DeleteMember(dbMember);
            dbMember = MemberService.GetMemberByName(member.name);
            Assert.IsNull(dbMember);
        }
    }
}
