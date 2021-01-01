﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Approval.Controllers
{
    public class ValuesController : ApiController
    {
        public Quix.Auth auth = new Quix.Auth(
            System.Configuration.ConfigurationManager.AppSettings["ClientId"].ToString(),
            System.Configuration.ConfigurationManager.AppSettings["TenantId"].ToString(),
            System.Configuration.ConfigurationManager.AppSettings["TenantUrl"].ToString(),
            System.Configuration.ConfigurationManager.AppSettings["AccessScopes"].ToString().Split(','),
            System.Configuration.ConfigurationManager.AppSettings["TokenFile"].ToString());

        // GET api/values
        public IEnumerable<string> Get(IEnumerable<string> ids)
        {
            string returnValue = "Values: ";
            foreach (string id in ids)
            {
                returnValue += ("{" + id + "}");
            }
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            return "value {" + id + "}";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
