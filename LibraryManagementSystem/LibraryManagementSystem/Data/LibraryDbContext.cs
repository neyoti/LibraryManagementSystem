using System;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
	public class LibraryDbContext : DbContext
	{
		public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

		public DbSet<Book> Books { get; set; }
		public DbSet<Member> Members { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
	}
}

