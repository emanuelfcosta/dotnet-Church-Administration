using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using church_project.Models;

namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialController : ControllerBase
    {
        public SisChurchContext Context {get; set;}
      
        public DbSet<Financial> Financials => Context.Financials;




        public FinancialController(SisChurchContext dbContext)
        {
            this.Context = dbContext;
          
        }
      
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await Financials.ToArrayAsync();
            return Ok(result);
        }
      
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ListById(int id)
        {
            var result = await Financials.FirstOrDefaultAsync(b => b.Id == id);
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Insert(Financial financial)
        {
            await Financials.AddAsync(financial);
            await Context.SaveChangesAsync();
            return Ok();




        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Financial financial)
        {
            var entity = await Financials.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            financial.Id = entity.Id;


            Context.Entry(entity).CurrentValues.SetValues(financial);
            await Context.SaveChangesAsync();


            return Ok(entity);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await Financials.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            Financials.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
