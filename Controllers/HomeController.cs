using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Controllers;
using ServiceStack.Redis;

public class HomeController: Controller
{

    public ActionResult Index()
    {
          /*var manager = new RedisManagerPool("localhost:6379");
            using (var client = manager.GetClient())
            {
               var redisClient =  client.As<Contact>();
               redisClient.Store(new Contact{
                   Id = redisClient.GetNextSequence(),
                     FirstName="Dwain",
                     LastName="Richardson",
                     Age = 4,
                     PhoneNumber = "8883332312"
               });
            }*/
        return View();
    }

}