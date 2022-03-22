using APIintro.Models.databsae;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace APIintro.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/showStudents")]
        [HttpGet]
        public dynamic GetAll()
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.students
                         select new {s.sid, s.sname, s.sdob, s.sdid }).ToList();
            var data = new JavaScriptSerializer().Serialize(stnds);
            return data;
        }
        [Route("api/addStudents")]
        [HttpPost]
        public dynamic Post(student s)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            db.students.Add(s);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "added");
        }
        [Route("api/editStudents")]
        [HttpPost]
        public dynamic Edit(student st)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.students
                         where s.sid == st.sid
                         select s).FirstOrDefault();
            db.Entry(stnds).CurrentValues.SetValues(st);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Edited");
        }
        [Route("api/deleteStudents")]
        [HttpPost]
        public dynamic Delete(student st)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.students
                         where s.sid == st.sid
                         select s).FirstOrDefault();
            db.students.Remove(stnds);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

    }
}
