using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobSearch.Models;
using JobSearch.Data;
using System;

namespace JobSearch.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobSearchController : ControllerBase
    {
        private readonly ApiContext _context;


        public JobSearchController(ApiContext context)
        {
            _context = context;
        }



        ///create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Job jobsearch)
        {

            //job id is zero to enter new record
            if (jobsearch.id == 0)
            {
                _context.JobSrch.Add(jobsearch);
                jobsearch.Jobcode = "JOB-0" + jobsearch.id.ToString();
                jobsearch.postDate = DateTime.UtcNow;
                jobsearch.departmentId = jobsearch.id;
              
            }
            else
            {
                var jobSearched = _context.JobSrch.Find(jobsearch.id);

                if (jobSearched == null)
                    return new JsonResult(NotFound());

                jobSearched = jobsearch;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(jobsearch));
        }







        // Get specific job details

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            //var result = _context.JobSrch.Find(id);

            //if (result == null)
            //    return new JsonResult(NotFound());
            //return new JsonResult(Ok(result));

            var jobs = _context.JobSrch.ToList();
            var dept = _context.dpt.ToList();
            var location = _context.location.ToList();
            //return new JsonResult(Ok(result));


            //SELECT  first_name, last_name, employee_id, job_id   FROM employeesWHERE department_id =
            //(SELECT department_id
            //FROM departments
            //WHERE location_id =
            //(SELECT location_id
            //FROM locations
            //WHERE city = 'Toronto'));


            var results = from s in jobs
                          where s.id == id
                          join d in dept on s.departmentId equals d.id
                          join l in location on s.locationId equals l.id
                          select new {s ,d,l};

          return new JsonResult(Ok(results));

        }





        //Delete
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _context.JobSrch.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _context.JobSrch.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }



        //get all
        [HttpGet()]
        public JsonResult list()
        {
            var result = _context.JobSrch.ToList();
            return new JsonResult(Ok(result));

        }
    

      


        //-------------Department

        ///create/Edit dept
        [HttpPost]
        public JsonResult CreateEditDept(Models.department dept)
        {
            //job id is zero to enter new record
            if (dept.id != 0)
            {
                _context.dpt.Add(dept);

            }
            else
            {
                var deptsearched = _context.dpt.Find(dept.id);

                if (deptsearched == null)
                    return new JsonResult(NotFound());

                deptsearched = dept;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(dept));
        }

       

        // Get dept

        [HttpGet("{id}")]
        public JsonResult Getdept(int id)
        {
            var result = _context.dpt.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));

        }

        //Delete dept
        [HttpDelete("{id}")]
        public JsonResult Deletedept(int id)
        {
            var result = _context.dpt.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _context.dpt.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //get all dept
        [HttpGet()]
        public JsonResult GetAlldept()
        {
            var result = _context.dpt.ToList();

            return new JsonResult(Ok(result));
        }




        //--------------------- location ------------------

        //edit/create location
        [HttpPost]
        public JsonResult CreateEditLoc(Models.location loc)
        {
            //job id is zero to enter new record
            if (loc.id != 0)
            {
                _context.location.Add(loc);

            }
            else
            {
                var locsearched = _context.location.Find(loc.id);

                if (locsearched == null)
                    return new JsonResult(NotFound());

                locsearched = loc;
            }
            _context.SaveChanges();
            return new JsonResult(Ok(loc));
        }

        // Get location

        [HttpGet("{id}")]
        public JsonResult Getlocation(int id)
        {
            var result = _context.location.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));

        }


        //Delete location
        [HttpDelete("{id}")]
        public JsonResult Deletelocation(int id)
        {
            var result = _context.location.Find(id);
            if (result == null)
                return new JsonResult(NotFound());
            _context.location.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

         //get all Location
        [HttpGet()]
        public JsonResult GetAllloc()
        {
            var result = _context.location.ToList();

            return new JsonResult(Ok(result));
        }


    }
}
