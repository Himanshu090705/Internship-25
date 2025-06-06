using Avengers.Models;
using Avengers.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Avengers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvgController : ControllerBase
    {
        private readonly AvgServices _avgService;

        public AvgController(AvgServices avgService)
        {
            _avgService = avgService;
        }

        [HttpGet("GetAllAvengers")]
        public ActionResult<List<Avenger>> GetAvengers()
        {
            var avengers = _avgService.GetAvengers();
            return avengers.Count > 0 ? Ok(avengers) : NotFound("No Avengers found.");
        }

        [HttpGet("GetAvenger")]
        public ActionResult<Avenger> GetAvenger(int id)
        {
            var avenger = _avgService.GetAvengerById(id);
            return avenger != null ? Ok(avenger) : NotFound("Avenger not found.");
        }

        [HttpPost("AddAvenger")]
        public ActionResult AddAvenger([FromBody] Avenger avenger)
        {
            _avgService.AddAvenger(avenger);
            return Ok("Avenger added successfully.");
        }

        [HttpPut("UpdateAvenger")]
        public ActionResult UpdateAvenger([FromBody] Avenger avenger)
        {
            int status = _avgService.UpdateAvenger(avenger);
            return status == 1 ? Ok("Avenger updated successfully.") : NotFound("Avenger not found.");
        }

        [HttpDelete("DeleteAvenger")]
        public ActionResult DeleteAvenger(int id)
        {
            int status = _avgService.DeleteAvenger(id);
            return status == 1 ? Ok("Avenger deleted successfully.") : NotFound("Avenger not found.");
        }
    }
}
