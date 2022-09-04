using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repository;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficulty walkDifficultyRepository;
        private readonly IMapper _mapper;
        public WalkDifficultyController(IWalkDifficulty walkDifficultyRepository,IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this._mapper = mapper;
        }

        [HttpGet("/getAllWalkDifficulty")]
        public async Task<IActionResult> getAllWalkDifficulty()
        {
            var allWalkDifficulty = await walkDifficultyRepository.GetAllWalkDifficultiesAsync();
            var allWalkDifficultyDTO = _mapper.Map<List<WalkDifficultyDTO>>(allWalkDifficulty);
            return Ok(allWalkDifficultyDTO);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult>getWalkDifficultyByID(Guid id)
        {
            var walkDifficultyDTO = await walkDifficultyRepository.GetWalkDifficultyByIDAsync(id);
            if (walkDifficultyDTO == null)
            {
                return NotFound();
            }
            return Ok(walkDifficultyDTO);
        }
        [HttpPost("/addWalkDifficulty")]
        public async Task<IActionResult>addWalkDifficultyAsync(WalkDifficultyDTO walkDifficultyDTO)
        {
            var walkD1 = new WalkDifficulty()
            {
                Id = Guid.NewGuid(),
                Code=walkDifficultyDTO.Code

            };
            var walkD2 = await walkDifficultyRepository.AddWalkDifficultyAsync(walkD1);
            var walkD3 = _mapper.Map<WalkDifficultyDTO>(walkD2);
            return Ok(walkD3);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult>deleteWalkDifficulty(Guid id)
        {
            var res= await walkDifficultyRepository.RemoveWalkDifficultyAsync(id);
            return Ok(res);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult>updateWalkDifficulty(Guid id,WalkDifficultyDTO walkDifficultyDTO)
        {
            var walkDifficulty = new WalkDifficulty()
            {
                Code = walkDifficultyDTO.Code
            };
            var walkDifficulty1 = await walkDifficultyRepository.UpdateWalkDifficultyAsync(id, walkDifficulty);
            var walkDifficulty2 = _mapper.Map<WalkDifficultyDTO>(walkDifficulty1);
            return Ok(walkDifficulty2);
        }
    }
}
