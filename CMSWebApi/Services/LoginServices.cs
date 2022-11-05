using CMSWebApi.Models;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace CMSWebApi.Services
{
    public class LoginServices : ILogin
    {
        private readonly IRepo<int, Member> _repo;
        private readonly ITokenService _tokenService;

        public LoginServices(IRepo<int, Member> repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public MemberDTO Login(MemberDTO member)
        {
            var mymember = _repo.GetAll().FirstOrDefault(u => u.UserName == member.UserName);
            if (mymember != null )
            {
                var dbPass = mymember.PasswordHash;
                HMACSHA512 hmac = new HMACSHA512(mymember.Key);
                var memberPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(member.Password));
                for (int i = 0; i < dbPass.Length; i++)
                {
                    if (memberPass[i] != dbPass[i])
                        return null;
                }
                member.Password = null;
                member.Token = _tokenService.CreateToken(member);
                return member;
            }
            return null;
        }

        public MemberDTO Register(MemberPassDTO member)
        {
            HMACSHA512 hmac = new HMACSHA512();
            member.Key = hmac.Key;
            member.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(member.Password));
            var myUser = _repo.Add(member);
            if (myUser != null)
                return new MemberDTO
                {
                    UserName = member.UserName,
                    Token = _tokenService.CreateToken(new MemberDTO { UserName = member.UserName })
                };
            return null;
        }
    }
}
