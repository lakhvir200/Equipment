using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Equipment.Command.API
{
    [Route("api/[controller]")]
    public class EquipmentController : Controller
    {
       
        // POST api/<controller>
        [HttpPost]
        public void PostEquipment([FromBody]string value)
        {

          
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void PutEquipment(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void DeleteEquipment(int id)
        {
        }
    }
}
