using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReactAPI.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Get()
        {
            List<itemObject> lst_obj = new List<itemObject>();
            for (int i = 0; i < 5; i++)
            {
                itemObject obj_item = new itemObject();
                obj_item.ID = i;
                obj_item.Name = "Test"+i;
                lst_obj.Add(obj_item);
            }

            return Ok(new { items = lst_obj });
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }

    
    }

    public class itemObject
    {
        public int ID { get; set; }
        public String Name { get; set; }
    }
}
