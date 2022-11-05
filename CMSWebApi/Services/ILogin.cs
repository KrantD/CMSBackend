using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using CMSWebApi.Models;

namespace CMSWebApi.Services
{
    public interface ILogin
    {
        MemberDTO Login(MemberDTO user);
        MemberDTO Register(MemberPassDTO user);

    }
}
