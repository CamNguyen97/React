using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ItemsController : ApiController
    {
        private DataReactEntities db = new DataReactEntities();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/Items
        public IHttpActionResult Get()
        {
            var json = JsonConvert.SerializeObject(db.Items.ToList());
            return Ok(json);
        }

        // GET: api/Items/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Items
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Items/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Items/5
        public void Delete(int id)
        {
        }
    }
}
