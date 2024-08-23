using App_Data.InterfaceRepos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Staff_MajorController : ControllerBase
    {
        IStaff_MajorRepos _repos;
        public Staff_MajorController(IStaff_MajorRepos repos)
        {
             _repos = repos;
        }

        [HttpGet("get-all-staffmajor")]
        public async Task<IActionResult> GetAll(Guid idstaff)
        {
            var lst = await _repos.GetAll(idstaff);

            return Ok(lst);
        }

        [HttpGet("get-all-facility")]
        public async Task<IActionResult> GetAllFacility()
        {
            var lst = await _repos.GetAllFacility();
            return Ok(lst);
        }
    }
}
