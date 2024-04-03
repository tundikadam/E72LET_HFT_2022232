using E72LET_HFT_2022232.Endpoint.Controllers.Services;
using E72LET_HFT_2022232.Logic;
using E72LET_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E72LET_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        IGameLogic logic;
        IHubContext<SignalRHub> hub;
        public GameController(IGameLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<GameController>
        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public Game Get(int id)
        {
            try { Game result = logic.Read(id);
                
                return result; }
            catch(Exception ex)
            {
                
                return null;
                
            }
        }

        // POST api/<GameController>
        [HttpPost]
        public void Create([FromBody] Game value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("GameCreated", value);
        }

        // PUT api/<GameController>/5
        [HttpPut]
        public void Update( [FromBody] Game value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("GameUpdated", value);
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var gameToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("GameDeleted", gameToDelete);
        }
    }
}
