using System;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MembersController : ControllerBase
	{
		private readonly LibraryDbContext _dbContext;

		public MembersController(LibraryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Member>>> GetAllMembers()
		{
			return await _dbContext.Members.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult<Member>> AddMember(Member member)
		{
			_dbContext.Members.Add(member);

			await _dbContext.SaveChangesAsync();
			return CreatedAtAction(nameof(AddMember), new { id = member.Id }, member);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMember(int id, Member member)
		{
			if (id != member.Id) return BadRequest();

			_dbContext.Entry(member).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return NoContent();
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _dbContext.Members.FindAsync(id);
            if (member == null) return NotFound();

            _dbContext.Members.Remove(member);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

