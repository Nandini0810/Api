using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineExam.Models;
using System.Web.Http.Description;

namespace OnlineExam.Controllers
{
    public class ReportController : ApiController
    {
        OnlineExamEntities1 oe1 = new OnlineExamEntities1();
        // GET: api/Report
        [Route("GetAllReports")]
        public IEnumerable<Report> Get()
        {
            return oe1.Reports;
        }

        // GET: api/Report/5
        [ResponseType(typeof(Report))]
        public IHttpActionResult Get(int id)
        {
            Report report = oe1.Reports.Find(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        // POST: api/Report
        public void Post([FromBody]Report report)
        {
            oe1.Reports.Add(report);
            oe1.SaveChanges();
        }

        // PUT: api/Report/5
        public void Put(int id, [FromBody]Report r)
        {
            Report report = oe1.Reports.Find(id);
            report.Level1_Score = r.Level1_Score;
            report.Level2_Score = r.Level2_Score;
            report.Level3_Score = r.Level3_Score;
        }

        // DELETE: api/Report/5
        public void Delete(int id)
        {

        }
    }
}
