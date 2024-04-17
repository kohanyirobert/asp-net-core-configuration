using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpGet("env")]
        public ContentResult Env()
        {
            var html = $"""
            <ul>
                <li><pre>Environment.GetEnvironmentVariable("ConnectionStrings__Default") = {Environment.GetEnvironmentVariable("ConnectionStrings__Default")}</pre></li>
                <li><pre>_configuration["ConnectionStrings:Default"] = {_configuration["ConnectionStrings:Default"]}</pre></li>
                <li><pre>_configuration.GetConnectionString("Default") = {_configuration.GetConnectionString("Default")}</pre></li>
            </ul>
            """;
            return Content(html, "text/html");
        }        
    }
}
