using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace AspNetCoreConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbController : ControllerBase
    {
        private readonly ILogger<DbController> _logger;
        private readonly IConfiguration _configuration;

        public DbController(ILogger<DbController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet("test")]
        public ContentResult Test()
        {
            _logger.LogDebug("Request received at: api/db/test");
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            using (var command = new SqlCommand("SELECT 1", connection))
            {
                connection.Open();
                var result = command.ExecuteScalar();
                var message = "Result was: " + result;
                _logger.LogInformation(message);
                return Content(message, "text/html");
            }
        }
    }
}