using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tianmao.Controllers
{
    [Produces("application/json")]
    [Route("/aligenie/{value}")]
    public class AligenieController : Controller
    {
        private static FileInfo file;

        private static FileInfo key
        {
            get
            {
                if (file == null)
                {
                    file = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"aligenie")).GetFiles()[0];
                }
                return file;
            }
        }
        [HttpPost]
        public void Post(string value)
        {
            if (value == "cc3f5463bc4d26bc38eadc8bcffbc654.txt")
            {
                Response.WriteAsync(key.OpenText().ReadToEnd());
            }
        }

        [HttpGet]
        public void Get(string value)
        {
            if (value == "cc3f5463bc4d26bc38eadc8bcffbc654.txt")
            {
                Response.WriteAsync(key.OpenText().ReadToEnd());
            }
        }
    }
}