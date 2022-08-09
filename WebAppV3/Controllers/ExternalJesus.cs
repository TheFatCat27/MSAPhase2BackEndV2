using Microsoft.AspNetCore.Mvc;

namespace WebAppV3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalJesusController : ControllerBase
    {
        private readonly HttpClient _client;
        /// <summary />
        public ExternalJesusController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("bible");
        }
        /// <summary>
        /// Gets the raw JSON for the verse specified
        /// </summary>
        /// <returns>A JSON object representing Bible verse</returns>
        [HttpGet]
        [Route("JesusMyHabibi")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetJesusFanfic(string BibleBook)
        {
            var res = await _client.GetAsync(BibleBook);
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}