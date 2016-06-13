using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using StudentsService.Models;

namespace StudentsService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using StudentsService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<StudentDetail>("StudentDetails");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StudentDetailsController : ODataController
    {
        private StudentsServiceContext db = new StudentsServiceContext();

        // GET: odata/StudentDetails
        [EnableQuery]
        public IQueryable<StudentDetail> GetStudentDetails()
        {
            return db.StudentDetails;
        }

        // GET: odata/StudentDetails(5)
        [EnableQuery]
        public SingleResult<StudentDetail> GetStudentDetail([FromODataUri] int key)
        {
            return SingleResult.Create(db.StudentDetails.Where(studentDetail => studentDetail.StudentRef == key));
        }

        // PUT: odata/StudentDetails(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<StudentDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentDetail studentDetail = db.StudentDetails.Find(key);
            if (studentDetail == null)
            {
                return NotFound();
            }

            patch.Put(studentDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(studentDetail);
        }

        // POST: odata/StudentDetails
        public IHttpActionResult Post(StudentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentDetails.Add(studentDetail);
            db.SaveChanges();

            return Created(studentDetail);
        }

        // PATCH: odata/StudentDetails(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<StudentDetail> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudentDetail studentDetail = db.StudentDetails.Find(key);
            if (studentDetail == null)
            {
                return NotFound();
            }

            patch.Patch(studentDetail);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(studentDetail);
        }

        // DELETE: odata/StudentDetails(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            StudentDetail studentDetail = db.StudentDetails.Find(key);
            if (studentDetail == null)
            {
                return NotFound();
            }

            db.StudentDetails.Remove(studentDetail);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentDetailExists(int key)
        {
            return db.StudentDetails.Count(e => e.StudentRef == key) > 0;
        }
    }
}
