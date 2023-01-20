using Microsoft.AspNetCore.Mvc;

namespace LambdaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private IHttpContextAccessor _httpContextAccessor;

        public ValuesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var response = _httpContextAccessor.HttpContext.Response;
            response.Cookies.Append("dummy", "abc");
            response.Cookies.Delete("testCookie");
            response.Cookies.Append("testCookie", "ABC");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}