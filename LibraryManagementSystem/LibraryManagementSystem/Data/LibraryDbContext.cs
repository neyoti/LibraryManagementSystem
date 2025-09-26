using System;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
	public class LibraryDbContext : DbContext
	{
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

		DbSet<Book> Books { get; set; }
		DbSet<Member> Members { get; set; }
		DbSet<BorrowedRecord> BorrowedRecords { get; set; }
	}
}

