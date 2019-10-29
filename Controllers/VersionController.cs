using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using LunTi.Models;
using LunTi.Storage;




[Route("api/[controller]")]
   [ApiController]
   public class VersionController : ControllerBase
   {
       // GET api/values
       [HttpGet]
      /*  public ActionResult<string> Get()
       {
           return Ok(Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion);
       }*/
       public ActionResult<string> Get()
       {
           Log.Information("Acquiring version info");
           Log.Warning("Some warning");
           Log.Error("Here comes an error");
 
           var versionInfo = new LunTi.Models.Version
           {
               Company = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyCompanyAttribute>().Company,
               Product = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyProductAttribute>().Product,
               ProductVersion = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion
           };
 
           Log.Information($"Acquired version is {versionInfo.ProductVersion}");
           Log.Debug($"Full version info: {@versionInfo}");
 
           return Ok(versionInfo);
       }
   }
