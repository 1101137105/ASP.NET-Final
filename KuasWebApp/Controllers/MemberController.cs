
using KuasCore.Models;
using KuasCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace KuasWebApp.Controllers
{
    public class MemberController : ApiController
    {
        public IMemberService MemberService { get; set; }

        [HttpPost]
        public Member AddMember(Member member)
        {
            CheckCourseIsNotNullThrowException(member);

            try
            {
                return MemberService.AddMember(member);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Member UpdateMember(Member member)
        {
            CheckCourseIsNullThrowException(member);

            try
            {
                MemberService.UpdateMember(member);
                return MemberService.GetMemberByName(member.name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteMember(Member member)
        {
            try
            {
                MemberService.DeleteMember(member);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Member> GetAllMember()
        {
            return MemberService.GetAllMember();
        }

        [HttpGet]
        public Member GetMemberById(int id)
        {
            var member = MemberService.GetMemberById(id);

            if (member == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return member;
        }

        [HttpGet]
        [ActionName("name")]
        public Member GetMemberByName(string input)
        {
            var member = MemberService.GetMemberByName(input);

            if (member == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return member;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckCourseIsNullThrowException(Member member)
        {
            Member dbMember = MemberService.GetMemberById(member.id);

            if (dbMember == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="course">
        ///     課程資料.
        /// </param>
        private void CheckCourseIsNotNullThrowException(Member member)
        {
            Member dbMember = MemberService.GetMemberById(member.id);

            if (dbMember != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }
    }
}
