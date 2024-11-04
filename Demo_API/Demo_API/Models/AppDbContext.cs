using Microsoft.EntityFrameworkCore;

namespace Demo_API.Models
{
	// Lớp AppDbContext đại diện cho ngữ cảnh cơ sở dữ liệu của ứng dụng
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Employee> Employees { get; set; }  // DbSet đại diện cho bảng Employees trong cơ sở dữ liệu

	}
}
