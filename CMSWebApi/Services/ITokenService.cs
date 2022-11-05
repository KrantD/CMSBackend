using CMSWebApi.Models;

namespace CMSWebApi.Services
{
    public interface ITokenService
    {
        public string CreateToken(MemberDTO member);
    }
}
