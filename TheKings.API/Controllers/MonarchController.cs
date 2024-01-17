using Microsoft.AspNetCore.Mvc;
using System.Net;
using TheKings.API.Entities;
using TheKings.API.Repositories;

namespace TheKings.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MonarchController : ControllerBase
    {
        private readonly IMonarchRepository _monarchRepository;


        public MonarchController(IMonarchRepository monarchRepository)
        {
            _monarchRepository = monarchRepository;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<Monarch>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Monarch>>> GetAllMonarchList()
        {
            var list  =await _monarchRepository.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("stats/total")]
        public async Task<ActionResult<int>> GetTotalMonarchs()
        {
            var list = await _monarchRepository.GetAllAsync();
            return Ok(list.Count);
        }

        [HttpGet("stats/longestRulingMonarch")]
        public async Task<ActionResult<string>> GetLongestRulingMonarch()
        {
            var list = await _monarchRepository.GetAllAsync();
            var longestRuler = list.OrderByDescending(m => m.ReignLength).FirstOrDefault();
            return Ok($"{longestRuler?.Nm} - {longestRuler?.ReignLength} years");
        }

        [HttpGet("stats/mostCommonFirstName")]
        public async Task<ActionResult<string>> GetMostCommonFirstName()
        {
            var list = await _monarchRepository.GetAllAsync();
            var firstName = list.GroupBy(m => m.Nm.Split(' ')[0])
                                .OrderByDescending(g => g.Count())
                                .Select(g => g.Key)
                                .FirstOrDefault();
            return Ok(firstName);
        }

        [HttpGet("stats/longestRulingHouse")]
        public async Task<ActionResult<string>> GetLongestRulingHouse()
        {
            var list = await _monarchRepository.GetAllAsync();
            var house = list.GroupBy(m => m.Hse)
                            .Select(group => new { House = group.Key, TotalYears = group.Sum(m => m.ReignLength) })
                            .OrderByDescending(g => g.TotalYears)
                            .FirstOrDefault();

            return Ok($"{house?.House} - {house?.TotalYears} years");
        }
    }
}
