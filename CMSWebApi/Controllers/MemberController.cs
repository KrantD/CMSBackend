using CMSWebApi.Models;
using CMSWebApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MyFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class MemberController : ControllerBase
    {
        private readonly ILogin _loginService;
        private readonly IRepo<int, Member> _repo;

        public MemberController(ILogin loginService,IRepo<int, Member> repo)
        {
            _loginService = loginService;
            _repo = repo;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(MemberDTO memberDTO)
        {
            var result = _loginService.Login(memberDTO);
            if (result != null)
                return Ok(result);
            return BadRequest("Invalid username or password");
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(MemberPassDTO member)
        {
            var result = _loginService.Register(member);
            if (result != null)
                return Ok(result);
            return BadRequest("Could not register user");
        }
        [HttpGet]
        [Route("GetAllPlansByMember")]
        public ActionResult<ICollection<MemberPlan>> GetAllPlansByMember(string username)
        {
            var plans = _repo.GetAllPlansByMember();
            var myPlans = plans.Where(e => e.UserName == username).ToList();
            if (myPlans.Count == 0)
                return NotFound("No plans for this member");
            return Ok(myPlans);
        }
        //[HttpPut("{id}/{pid}")]
        //public async Task<IActionResult> UpdatePlansbyMember([FromBody] Plan plan, [FromBody] Member member, [FromRoute] int pid, [FromRoute] int id)
        //{
        //    await _repo.UpdatePlans(id, plan);
        //    return Ok();
        //}

    }
}