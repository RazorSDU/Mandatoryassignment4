using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Mandatory_assignment_4.Manager;
using static System.Net.WebRequestMethods;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mandatory_assignment_1._4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<FootballPlayer>> Get()
        {
            IEnumerable<FootballPlayer> FBP = _manager.GetAll();
            if (FBP == null) return NotFound("There are no football players.");
            return Ok(FBP);
        }

        // GET api/<FootballPlayersController>/[ID]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer FBP = _manager.GetById(id);
            if (FBP == null) return NotFound("No such football player: " + id);
            return Ok(FBP);
        }

        // POST api/<FootballPlayersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            try
            {
                FootballPlayer newFootballPlayer = _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + newFootballPlayer.Id;
                return Created(uri, newFootballPlayer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FootballPlayersController>/[ID]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            try
            {
                FootballPlayer updatedFootballPlayer = _manager.Update(id, value);
                if (updatedFootballPlayer == null) return NotFound("No such football player, id: " + id);
                return Ok(updatedFootballPlayer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FootballPlayersController>/[ID]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer deletedFootballPlayer = _manager.Delete(id);
            if (deletedFootballPlayer == null) return NotFound("No such football player, id: " + id);
            return Ok(deletedFootballPlayer);
        }
    }
}
