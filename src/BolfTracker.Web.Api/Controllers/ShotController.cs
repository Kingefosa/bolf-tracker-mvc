using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BolfTracker.Models;
using System.Diagnostics;
using BolfTracker.Web.Api.Models;

namespace BolfTracker.Web.Api.Controllers
{
    public class ShotController : ApiController
    {
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        public void Post([FromBody]IEnumerable<ApiShot> values)
        {
            if (values != null)
            {
                foreach (var value in values)
                {
                    
                }
            }
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}