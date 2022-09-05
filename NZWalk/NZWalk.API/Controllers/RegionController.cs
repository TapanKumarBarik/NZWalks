using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
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
        [Authorize(Roles ="reader")]
        public async Task<IActionResult> getAllRegions()
        {
            var allRegions= await regionRepository.GetAllRegionAsync();
            var allRegionsDTO = mapper.Map<List<Region>>(allRegions);
            return Ok(allRegionsDTO);
        }
       
        [HttpGet("/getRegionByID")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult>getRegionByID(Guid guid)
        {
            var region = await regionRepository.GetRegionByIDAsync(guid);
            var regionDTO = mapper.Map<Region>(region);
            return Ok(regionDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult>getRegionByIDAsync1(Guid id)
        {
            var region = await regionRepository.GetRegionByIDAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO=mapper.Map<Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult>addRegion(RegionDTO regionDTO)
        {


            var region = new Region
            {
                Id = Guid.NewGuid(),
                Code = regionDTO.Code,
                Name = regionDTO.Name,
                Area = regionDTO.Area,
                Lattitude = regionDTO.Lattitude,
                Longitude = regionDTO.Longitude,
                Population = regionDTO.Population
            };
            var region1=await regionRepository.AddRegionAsync(region);
            var region2 = mapper.Map<Region>(region1);
            return Ok(region2);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<string>deleteRegionByID(Guid id)
        {
            var res=await regionRepository.DeleteRegionByIDAsync(id);
            return res;
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult>updateRegionByID(Guid id,RegionDTO regionDTO)
        {
            var region = new Region
            {

                Code = regionDTO.Code,
                Name = regionDTO.Name,
                Area = regionDTO.Area,
                Lattitude = regionDTO.Lattitude,
                Longitude = regionDTO.Longitude,
                Population = regionDTO.Population
            };

            var newRegion=await regionRepository.UpdateRegionAsync(id, region);
            return Ok(newRegion);
        }
    }
}
