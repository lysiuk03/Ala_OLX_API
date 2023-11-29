using BusinessLogic.ApiModels.Announcements;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ala_OLX_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsServices announcementsServices;

        public AnnouncementsController(IAnnouncementsServices announcementsServices)
        {
            this.announcementsServices = announcementsServices;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(announcementsServices.Get());
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            return Ok(announcementsServices.Get(id));
        }
        [HttpPost]
        public IActionResult Create([FromBody]CreateAnnouncementModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            announcementsServices.Create(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit([FromBody]EditAnnouncementModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            announcementsServices.Edit(model);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute]int id)
        {
            
            announcementsServices.Delete(id);
           
            return Ok();
        }
    }
}
