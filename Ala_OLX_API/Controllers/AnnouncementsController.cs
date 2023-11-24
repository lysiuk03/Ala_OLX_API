using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLX_Ala.Data;

namespace Ala_OLX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly AlaOlxDbContext ctx;

        public AnnouncementsController(AlaOlxDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(ctx.Announcements.ToList());
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var item = ctx.Announcements.Find(Id);
            if (item == null) { return NotFound();}
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(Announcement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ctx.Announcements.Add(model);
            ctx.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(Announcement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ctx.Announcements.Update(model);
            ctx.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var item = ctx.Announcements.Find(Id);
            if(item == null) { return NotFound(); }
            ctx.Announcements.Remove(item);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
