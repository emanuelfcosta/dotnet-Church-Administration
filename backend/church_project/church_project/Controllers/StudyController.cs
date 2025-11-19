using church_project.Models;
using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyController : ControllerBase
    {
        public SisChurchContext Context {get; set;}
      
        public DbSet<Study> Studies => Context.Studies;


        public StudyController(SisChurchContext dbContext)
        {
            this.Context = dbContext;
        }
      
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await Studies.ToArrayAsync();
            return Ok(result);
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> ListById(int id)
        {
            var result = await Studies.FirstOrDefaultAsync(b => b.Id == id);
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Insert(Study study)
        {
            await Studies.AddAsync(study);
            await Context.SaveChangesAsync();
            return Ok();




        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Study study)
        {
            var entity = await Studies.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            study.Id = entity.Id;


            Context.Entry(entity).CurrentValues.SetValues(study);
            await Context.SaveChangesAsync();


            return Ok(entity);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await Studies.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            Studies.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
