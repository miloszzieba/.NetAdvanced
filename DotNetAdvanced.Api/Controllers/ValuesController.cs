using DotNetAdvanced.Api.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace DotNetAdvanced.Api.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Method, that returns values
        /// </summary>
        /// <returns></returns>
        // GET api/values
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("{id}/products")]
        [HttpPost]
        public void InsertProducts(int id, [FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Product value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
