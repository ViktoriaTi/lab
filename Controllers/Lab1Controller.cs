using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LunTi.Models;
using LunTi.Storage;

namespace LunTi.Models
{

  [Route("api/[controller]")]
   [ApiController]
   public class LabController : ControllerBase
   {
      // private static List<Lab1Data> _memCache = new List<Lab1Data>();
        private static IStorage<LabData> _memCache = new MemCache();


       [HttpGet]
       public ActionResult<IEnumerable<Lab1Data>> Get()
       {
         //  return Ok(_memCache);
           return Ok(_memCache.All);
       }

       [HttpGet("{id}")]
      // public ActionResult<Lab1Data> Get(int id)
        public ActionResult<LabData> Get(Guid id)
       {
          // if (_memCache.Count <= id) return NotFound("No such");
           if (!_memCache.Has(id)) return NotFound("No such");

           return Ok(_memCache[id]);
       }

       [HttpPost]
       public IActionResult Post([FromBody] Lab1Data value)
         
       {
           var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           _memCache.Add(value);

           return Ok($"{value.ToString()} has been added");
       }

       [HttpPut("{id}")]
       //public IActionResult Put(int id, [FromBody] Lab1Data value)
       public IActionResult Put(Guid id, [FromBody] LabData value)
       {
         //  if (_memCache.Count <= id) return NotFound("No such");
           if (!_memCache.Has(id)) return NotFound("No such");

           var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           var previousValue = _memCache[id];
           _memCache[id] = value;

           return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
       }

       [HttpDelete("{id}")]
       //public IActionResult Delete(int id)
        public IActionResult Delete(Guid id)
       {
         //  if (_memCache.Count <= id) return NotFound("No such");
            if (!_memCache.Has(id)) return NotFound("No such");

           var valueToRemove = _memCache[id];
           _memCache.RemoveAt(id);

           return Ok($"{valueToRemove.ToString()} has been removed");
       }
   }

}