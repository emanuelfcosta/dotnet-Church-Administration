using church_project.Models;
using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
         public SisChurchContext Context {get; set;}
        
        
               public DbSet<Occasion> Occasions => Context.Occasions;
        
        
               public OccasionController(SisChurchContext dbContext)
               {
                   this.Context = dbContext;
               }
              
               [HttpGet]
               public async Task<IActionResult> ListAll()
               {
                   var result = await Occasions.ToArrayAsync();
                   return Ok(result);
               }
              
               [HttpGet("{id}")]
               public async Task<IActionResult> ListById(int id)
               {
                   var result = await Occasions.FirstOrDefaultAsync(b => b.Id == id);
                   return Ok(result);
               }
              
               [HttpPost]
               public async Task<IActionResult> Insert(Occasion occasion)
               {
                   await Occasions.AddAsync(occasion);
                   await Context.SaveChangesAsync();
                   return Ok();
        
        
        
        
               }
              
               [HttpPut("{id}")]
               public async Task<IActionResult> Update(int id, Occasion occasion)
               {
                   var entity = await Occasions.FirstOrDefaultAsync(b => b.Id == id);
        
        
                   if (entity is null)
                   {
                       return NotFound();
                   }
        
        
                   occasion.Id = entity.Id;
        
        
                   Context.Entry(entity).CurrentValues.SetValues(occasion);
                   await Context.SaveChangesAsync();
        
        
                   return Ok(entity);
               }
              
               [HttpDelete("{id}")]
               public async Task<IActionResult> Delete(long id)
               {
                   var entity = await Occasions.FirstOrDefaultAsync(b => b.Id == id);
        
        
                   if (entity is null)
                   {
                       return NotFound();
                   }
        
        
                   Occasions.Remove(entity);
                   await Context.SaveChangesAsync();
                   return Ok();
               }

    }
}
