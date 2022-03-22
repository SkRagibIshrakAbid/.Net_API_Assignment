using APIintro.Models.databsae;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace APIintro.Controllers
{
    public class DepertmentController : ApiController
    {
        [Route("api/showDept")]
        [HttpGet]
        public dynamic GetAll()
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.depts
                         select new { s.did, s.dname}).ToList();
            var data = new JavaScriptSerializer().Serialize(stnds);
            return data;
        }
        [Route("api/addDept")]
        [HttpPost]
        public dynamic Post(dept s)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            db.depts.Add(s);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "added");
        }
        [Route("api/editDept")]
        [HttpPost]
        public dynamic Edit(dept st)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.depts
                         where s.did == st.did
                         select s).FirstOrDefault();
            db.Entry(stnds).CurrentValues.SetValues(st);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Edited");
        }
        [Route("api/deleteDept")]
        [HttpPost]
        public dynamic Delete(dept st)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.depts
                         where s.did == st.did
                         select s).FirstOrDefault();
            db.depts.Remove(stnds);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }
        [Route("api/dept/details/{id}")]
        [HttpGet]
        public dynamic Details(int id)
        {
            APIassignmentEntities db = new APIassignmentEntities();
            var stnds = (from s in db.students
                         where s.sdid == id
                         select new { s.sid, s.sname, s.sdob, s.sdid, s.dept.dname }).ToList();
            var data = new JavaScriptSerializer().Serialize(stnds);
            return data;
        }
    }
}
