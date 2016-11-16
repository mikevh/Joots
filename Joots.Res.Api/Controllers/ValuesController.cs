using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Joots.Res.Api.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("Not a secret");
        }


        [Authorize]
        [HttpGet]
        [Route("secret")]
        public IHttpActionResult Secret()
        {
            return Ok("This is a secret!");
        }
    }
}
