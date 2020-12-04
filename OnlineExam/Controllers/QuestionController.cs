using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineExam.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Description;

namespace OnlineExam.Controllers
{
    public class QuestionController : ApiController
    {
        OnlineExamEntities1 oe = new OnlineExamEntities1();
        static bool b;
        // GET: api/Question
        [Route("GetAllFiles")]
        public IEnumerable<Question> Get()
        {
            return oe.Questions;
        }

        // GET: api/Question/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult Get(int id)
        {
            Question question = oe.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        // POST: api/Question
        [Route("NewFile")]



        // PUT: api/Question/5
        public void Put(int id, Question question)
        {
            Question q = oe.Questions.Find(id);
            q.FileName = question.FileName;
            q.ExamID = question.ExamID;
            q.Level = question.Level;
            oe.SaveChanges();

        }

        // DELETE: api/Question/5
        [Route("RemoveFile")]
        [ResponseType(typeof(Question))]
        public IHttpActionResult Delete(int id)
        {
            Question question = oe.Questions.Where(q => q.FileID == id).FirstOrDefault();
            if (question == null)
            {
                return NotFound();
            }
            oe.Questions.Remove(question);
            oe.SaveChanges();
            return Ok(question);
        }
        /*[HttpPost]
        [Route("sendfiles")]
        public HttpResponseMessage Post(string path,string cname,string tname,string ename,int level)
        {
            Question q = new Question();
            q.FileName = path;
            int eid = Convert.ToInt32(from e in oe.Exams where e.ExamName == ename select e.ExamID);
            if (eid == )
            {

            }
        }*/
        [HttpPost]
        [Route("try")]
        public IHttpActionResult GetT(string path,string cname,string ename,int level)
        {
            Question q = new Question();
            q.FileName = path;
            q.ExamID = (from c in oe.Companies join e in oe.Exams on c.CompanyID equals e.CompanyID where c.CompanyName == cname & e.ExamName == ename select e.ExamID).Single();
            q.Level = level;
            oe.Questions.Add(q);
            oe.SaveChanges();
            return Ok(q);
            
            
        }

    }
}
