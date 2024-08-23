using App_Data.Entities;
using App_DTO.DataTransferObject;
using App_DTO.InterfaceRepos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepos _repos;
        private readonly IMapper _mapper;
        public StaffController(IStaffRepos repos, IMapper mapper)
        {
            _repos = repos;
            _mapper = mapper;
        }

        [HttpGet("get-all-staff")]
        public async Task<IActionResult> GetAll()
        {
            var lst = await _repos.GetAll();
            return Ok(lst);
        }

        [HttpPost("create-staff")]
        public async Task<IActionResult> Create([FromBody] StaffDTO input)
        {
            try
            {
                var result = await _repos.Create(_mapper.Map<Staff>(input));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-staff")]
        public async Task<IActionResult> Update([FromBody] StaffUpdateRequest input)
        {
            try
            {
                var result = await _repos.Update(_mapper.Map<Staff>(input));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-staff")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _repos.Delete(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-staff-by-id")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _repos.Get(id);

            return Ok(result);
        }

    }
}
