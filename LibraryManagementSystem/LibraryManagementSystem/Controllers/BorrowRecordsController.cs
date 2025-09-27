using System;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BorrowRecordsController : ControllerBase
	{
		private readonly LibraryDbContext _dbContext;

		public BorrowRecordsController(LibraryDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<BorrowRecord>>> GetBorrowRecord()
		{
			return await _dbContext.BorrowRecords.ToListAsync();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateBrorrowRecord(int id, BorrowRecord borrowRecord)
		{
			if (id != borrowRecord.Id) return BadRequest();

			_dbContext.Entry(borrowRecord).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
			return NoContent();
		}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var borrowRecord = await _dbContext.Members.FindAsync(id);
            if (borrowRecord == null) return NotFound();

            _dbContext.Members.Remove(borrowRecord);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}

