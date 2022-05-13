using CinePopCorn.Domain.DTOs;
using CinePopCorn.infrastructure.Loggers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace SpotterAdm.WebAPI.Controllers.Features.Public
{

    [ApiController]
    [Route("/Public")]
    public class LoggerController : ControllerBase
    {
        LoggerDAO log;
        public LoggerController(IConfiguration configuration)
        {       
            Helpers.Configuration = configuration;
            log = new LoggerDAO(Helpers.GetConnectionString("CinePopCorn"));
        }

        [HttpPost("RegiterLogger")]
        [ProducesResponseType(200, Type = typeof(OkResult))]
        [AllowAnonymous]
        public IActionResult RegiterLogger([FromBody] LoggerDTO logger)
        {
            log.AddLog(logger);
            return Ok();
        }

    }

}
