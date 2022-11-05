using CMSWebApi.Models;
using CMSWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IRepo<int, Plan> _repo;

        public PlanController(IRepo<int, Plan> repo)
        {
            _repo = repo;
        }
        //[HttpPut]
        //public ActionResult<Plan> Update(Plan plan)
        //{
        //    var pln = _repo.Update(plan);
        //    if (pln == null)
        //        return BadRequest("No such plans");
        //    return Ok(pln);
        //}
        [HttpGet]
        public ActionResult<ICollection<Plan>> GETAll()
        {
            return Ok(_repo.GetAll());
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlansbyPlanId([FromBody] Plan plan, [FromRoute] int id)
        {
            await _repo.UpdatePlans(id,plan);
            return Ok();
        }
       




    }
}
