using church_project.Models;
using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurchController : ControllerBase
    {
        public SisChurchContext context { get; set; }


        public DbSet<Church> Churches => context.Churches;




        public ChurchController(SisChurchContext dbContext)
        {
            this.context = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await Churches.ToArrayAsync();
            return Ok(result);




        }




        [HttpPost]
        public async Task<IActionResult> Insert(Church church)
        {
            await Churches.AddAsync(church);
            await context.SaveChangesAsync();
            return Ok();




        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Church church)
        {
            var entity = await Churches.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            church.Id = entity.Id;


            context.Entry(entity).CurrentValues.SetValues(church);
            await context.SaveChangesAsync();


            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await Churches.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            Churches.Remove(entity);
            await context.SaveChangesAsync();
            return Ok();
        }


    }

}
