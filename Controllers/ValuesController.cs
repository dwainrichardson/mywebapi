using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceStack.Redis;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {

          var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
                var contactClient = client.As<Contact>();
            /*  var response = new HttpResponseMessage()
              {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(contactClient.GetAll()))

              };

              response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
              return response;*/
              return Json(contactClient.GetAll());
            }
          //return Json(new Contact());
          
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]List<Contact> request)
        {
          
                  var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
                var contactClient = client.As<Contact>();
               foreach(var item in request){
                   contactClient.Store(item);
               }
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Contact{
        public long Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public int Age {get;set;}
        public string PhoneNumber {get;set;}

    }
}
