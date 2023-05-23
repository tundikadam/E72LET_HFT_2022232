using E72LET_HFT_2022232.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E72LET_HFT_2022232.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IGameLogic logic;

        public StatController(IGameLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public  double? ActivisionsGamePriceAverage()
        { return this.logic.ActivisionsGamePriceAverage(); }
        [HttpGet]
        public int? ContendoCount()
        { return this.logic.ContendoCount(); }
        [HttpGet]
        public int? CountOfWin98()
        { return this.logic.CountOfWin98(); }
        [HttpGet]
        public string NewestGame()
        { return this.logic.NewestGame(); }
        [HttpGet]
        public int FirstRockstar()
        { return this.logic.FirstRockstar(); }
    }
}
