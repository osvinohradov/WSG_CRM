using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WSG.WEB.API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class HomeModuleController : ApiController
    {
        [HttpGet]
        public Book Index()
        {
            return new Book()
            {
                Id = 1,
                Name = "Vladimir",
                Surname = "Vinohradov"
            };
            //return "Hello from Home Controller Web API";
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
