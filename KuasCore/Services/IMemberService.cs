using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services
{
    public interface IMemberService
    {
        Member AddMember(Member member);

        void UpdateMember(Member member);

        void DeleteMember(Member member);

        IList<Member> GetAllMember();

        Member GetMemberByName(string name);

        Member GetMemberById(int id);
    }
}
