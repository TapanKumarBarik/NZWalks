using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using NZWalk.API.Repository;
using System.Collections.Generic;

namespace NZWalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        public WalksController(
            IWalkRepository walkRepository,
            IMapper mapper
            )
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("/getAllWalks")]
        public async Task<IActionResult> getAllWalks()
        {

            var allWalk= await walkRepository.GetAllWalkAsync();
            var allWalkDTO=mapper.Map<List<WalkDTO>> (allWalk);
            return Ok(allWalkDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult>getWalkByID(Guid id)
        {
            var walk = await walkRepository.GetWalkByIDAsync(id);

            if (walk == null) return NotFound();
            return Ok(walk);
        }

        [HttpPost("/Create")]
        public async Task<IActionResult> addWalkToDB(WalkDTO walk)
        {
            var walk1 = new Walk()
            {
                Id = Guid.NewGuid(),
                Name = walk.Name,
                Length = walk.Length,
                RegionID = new Guid("b950ddf5-e9ad-47ff-9d2a-57259014fae6"),
                WalkDifficultyID = new Guid("4c2b95e0-2022-4a8f-b537-eb3a32786b06")
            };
            var walk2=await walkRepository.AddWalkAsync(walk1);
            var walk3=mapper.Map<WalkDTO>(walk2);
            return Ok(walk3);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult>updateWalk(Guid id,WalkDTO walkDTO)
        {
            var walk1 = new Walk()
            {
                Id = Guid.NewGuid(),
                Name = walkDTO.Name,
                Length = walkDTO.Length,
                RegionID = walkDTO.RegionID,
                WalkDifficultyID = walkDTO.WalkDifficultyID
            };
            var returnWalk = await walkRepository.UpdateWalkAsync(id, walk1);
            var returnWalkDTO=mapper.Map<WalkDTO>(returnWalk);
            return Ok(returnWalkDTO);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<string> deleteWalkByID(Guid id)
        {
            var res = await walkRepository.DeleteWalkByIDAsync(id);
            return res;
        }

    }
}
