using AsyncProcessing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace AsyncProcessing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public ProcessController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet("data")]
        public  async Task<IActionResult> GetDataAsync(CancellationToken token = default)
        {

            try
            {
                var client = httpClientFactory.CreateClient();

                var message = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (message.IsSuccessStatusCode)
                {
                    var content = await message.Content.ReadAsStringAsync();
                    return Ok(content);
                }

                return StatusCode((int)message.StatusCode);

                //var message = client.GetAsync("https://jsonplaceholder.typicode.com/posts").Result;

            }

            catch (OperationCanceledException ex)
            {
                return BadRequest(new { message = "Request Cancelled" });
            }
            catch (Exception e)
            {

                return StatusCode(500, new { message = e.Message});
            }

                   

        }

        [HttpGet("stream")]
        public async IAsyncEnumerable<int> StreamDataAsync([EnumeratorCancellation]CancellationToken token = default)
        {
            for (int i = 0; i < 100; i++)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(100);
                yield return i;
            }
        }

        //public IActionResult Sample()
        //{
        //    var sinif = new Sinif();
        //    foreach (var ogrenci in sinif)
        //    {

        //    }


        //}
    }
}
