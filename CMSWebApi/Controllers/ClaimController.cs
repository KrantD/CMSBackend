using CMSWebApi.Models;
using CMSWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace CMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IRepo<int, Claim> _repo;

        public ClaimController(IRepo<int, Claim> repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public ActionResult<ICollection<Claim>> SubmitClaim(Claim claim)
        {
            var clm = _repo.Add(claim);
            if (clm != null)
            {
                return Ok("Claim Registered");
            }
            return BadRequest("Already registered");
        }
    }
}
