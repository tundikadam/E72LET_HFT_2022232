using E72LET_HFT_2022232.Logic;
using E72LET_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E72LET_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MinimalSystemRequriementsController : ControllerBase
    {
        IMinimalSystemRequriementsLogic logic;

        public MinimalSystemRequriementsController(IMinimalSystemRequriementsLogic logic )
        {
            this.logic = logic;
        }

        // GET: api/<MinimalSystemRequriementsController>
        [HttpGet]
        public IEnumerable<MinimalSystemRequirements> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<MinimalSystemRequriementsController>/5
        [HttpGet("{id}")]
        public MinimalSystemRequirements Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<MinimalSystemRequriementsController>
        [HttpPost]
        public void Create([FromBody] MinimalSystemRequirements value)
        {
            this.logic.Create(value);
        }

        // PUT api/<MinimalSystemRequriementsController>/5
        [HttpPut]
        public void Update( [FromBody] MinimalSystemRequirements value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<MinimalSystemRequriementsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
