using church_project.Models;
using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrayController : ControllerBase
    {
        public SisChurchContext Context {get; set;}
      
        public DbSet<Pray> Prayers => Context.Prayers;


        public PrayController(SisChurchContext dbContext)
        {
            this.Context = dbContext;
        }
      
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await Prayers.ToArrayAsync();
            return Ok(result);
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> ListById(int id)
        {
            var result = await Prayers.FirstOrDefaultAsync(b => b.Id == id);
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Insert(Pray pray)
        {
            await Prayers.AddAsync(pray);
            await Context.SaveChangesAsync();
            return Ok();




        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pray pray)
        {
            var entity = await Prayers.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            pray.Id = entity.Id;


            Context.Entry(entity).CurrentValues.SetValues(pray);
            await Context.SaveChangesAsync();


            return Ok(entity);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await Prayers.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            Prayers.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
