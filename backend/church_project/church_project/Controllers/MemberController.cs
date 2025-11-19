using church_project.Models;
using church_project.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace church_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public SisChurchContext Context {get; set;}


        public DbSet<Member> Members => Context.Members;




        public MemberController(SisChurchContext dbContext)
        {
            this.Context = dbContext;
        }
      
        [HttpGet]
        public async Task<IActionResult> ListAll()
        {
            var result = await Members.ToArrayAsync();
            return Ok(result);
        }
      
        [HttpGet("{id}")]
        public async Task<IActionResult> ListById(int id)
        {
            var result = await Members.FirstOrDefaultAsync(b => b.Id == id);
            return Ok(result);
        }
      
        [HttpPost]
        public async Task<IActionResult> Insert(Member member)
        {
            await Members.AddAsync(member);
            await Context.SaveChangesAsync();


            return Ok(member);
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Member member)
        {
            var entity = await Members.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            member.Id = entity.Id;


            Context.Entry(entity).CurrentValues.SetValues(member);
            await Context.SaveChangesAsync();


            return Ok(entity);
        }
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var entity = await Members.FirstOrDefaultAsync(b => b.Id == id);


            if (entity is null)
            {
                return NotFound();
            }


            Members.Remove(entity);
            await Context.SaveChangesAsync();
            return Ok();
        }

    }
}
