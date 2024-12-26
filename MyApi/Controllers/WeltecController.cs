using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeltecController : ControllerBase
    {

        WeltecdatabaseContext weltecdatabaseContext;

        public WeltecController()
        {
            weltecdatabaseContext = new WeltecdatabaseContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = weltecdatabaseContext.CourseWeltacs.ToList();
            return Ok(data);
        }

        [HttpPost]

        public IActionResult Post(CourseWeltac course)
        {
            weltecdatabaseContext.CourseWeltacs.Add(course);
            weltecdatabaseContext.SaveChanges();
            return Ok();
        }


        [HttpDelete]

        public IActionResult Delete(int id)
        {
            var course = weltecdatabaseContext.CourseWeltacs.Find(id);
            weltecdatabaseContext.CourseWeltacs.Remove(course);
            weltecdatabaseContext.SaveChanges();
            return Ok();
        }

        //[HttpPut]

        //public IActionResult Put(CourseWeltac course)
        //{
        //    weltecdatabaseContext.CourseWeltacs.Update(course);
        //    weltecdatabaseContext.SaveChanges();
        //    return Ok();
        //}

        [HttpPut]

        public IActionResult update(CourseWeltac course)
        {
           var courses = weltecdatabaseContext.CourseWeltacs.Where(x => x.Id == course.Id).FirstOrDefault();
            courses.Id = course.Id;
            courses.Name = course.Name;

            weltecdatabaseContext.SaveChanges();
            return Ok();
        }
    }
}
