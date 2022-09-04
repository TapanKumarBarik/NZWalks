using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Repository;

namespace NZWalk.API.Controllers
{
    
    [ApiController]
    [Route("api/Region")]
    public class RegionController : ControllerBase
    {

        private IRegionRepository regionRepository;
        private IMapper mapper;
        public RegionController(
            IRegionRepository regionRepository,
            IMapper mapper
            )
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet("/getAllRegions")]
        public async Task<IActionResult> getAllRegions()
        {
            var allRegions= await regionRepository.GetAllRegionAsync();
            var allRegionsDTO = mapper.Map<List<Region>>(allRegions);
            return Ok(allRegionsDTO);
        }
    }
}
