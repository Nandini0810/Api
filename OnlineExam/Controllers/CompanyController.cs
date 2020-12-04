using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineExam.Models;

namespace OnlineExam.Controllers
{
    public class CompanyController : ApiController
    {
        OnlineExamEntities1 db = new OnlineExamEntities1();
        [Route("GetUniqueC")]
        public IEnumerable<string> Get2()
        {
            var com1 = db.Companies.Select(c => c.CompanyName).Distinct();
            return com1;
            
        }

      
        public HttpResponseMessage Get(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }
        }
        // PUT: api/Company/2
        public void Put(int id, [FromBody] Company value)
        {
            Company c = db.Companies.Find(id);
            c.CompanyID = value.CompanyID;
            c.CompanyName = value.CompanyName;
            c.City = value.City;
            c.State = value.State;
            db.SaveChanges();
        }

        // DELETE: api/Company/2
        public HttpResponseMessage Delete(int id)
        {
            Company company = db.Companies.Where(e => e.CompanyID == id).FirstOrDefault();
            if (company == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No Data Found");
            }
            else
            {
                db.Companies.Remove(company);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, company);
            }

        }
        [Route("companysearch")]
        public HttpResponseMessage Get()
        {
            var com = db.Companies.ToList();
            if (com.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, com);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "No data found");
            }
        }
    }
}