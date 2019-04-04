using System.Reflection;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
   [ApiController]
   public class VersionController : ControllerBase
   {
       // GET api/values
       [HttpGet]
       public ActionResult<string> Get()
       {
           return Ok(Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
       }
   }
