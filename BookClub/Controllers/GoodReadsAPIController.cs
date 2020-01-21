using BookClub.Models;
using Goodreads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BookClub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodReadsAPIController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get(string ISBN="9780297859383")
        {
            //var client = new RestClient("https://www.goodreads.com");
            //client.UseDotNetXmlSerializer();

            var client = GoodreadsClient.Create("hG8Baz6PR4BYmKheAD3qg", "0nyS2sEH9JKSWil0j5xOBdcB6BzLmxscoo8yAIk");

            // Now you are able to call some Goodreads endpoints that don't need the OAuth credentials. For example:
            // Get a book by specified id.
            var book = await client.Books.GetByIsbn(ISBN);


            //var serializer = new XmlSerializer(typeof(ApiResponse));

            //ApiResponse result;

            //using (TextReader reader = new StringReader(response.Content))
            //{
            //    result
            //}


            return Ok();
        }
    }
}