using KuasCore.Dao;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class MemberService:IMemberService
    {
        public IMemberDao MemberDao { get; set; }

        public Member AddMember(Member member)
        {
            MemberDao.AddMember(member);
            return GetMemberByName(member.name);
        }

        public void UpdateMember(Member member)
        {
            MemberDao.UpdateMember(member);
        }

        public void DeleteMember(Member member)
        {
            member = MemberDao.GetMemberByName(member.name);

            if (member != null)
            {
                MemberDao.DeleteMember(member);
            }
        }

        public IList<Member> GetAllMember()
        {
            return MemberDao.GetAllMember();
        }

        public Member GetMemberByName(string name)
        {
            return MemberDao.GetMemberByName(name);
        }

        public Member GetMemberById(int id)
        {
            return MemberDao.GetMemberById(id);
        }
    }
}
