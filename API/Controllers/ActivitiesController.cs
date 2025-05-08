using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> GetActivities()
        {
            var activities = await context.Activities.ToListAsync();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetActivityById(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if (activity is null) return NotFound();

            return Ok(activity);
        }
    }
}
