using Microsoft.EntityFrameworkCore;

namespace Demo_API.Models
{
	// Repository cho thực thể Employee, chịu trách nhiệm xử lý các thao tác CRUD (Create, Read, Update, Delete) cho Employee
	public class EmployeeRepository
	{
		//_appDbContext dùng để truy cập vào AppDbContext -> Đối tượng này cho thao tác và kết nối và csdl
		private readonly AppDbContext _appDbcontext;

		public EmployeeRepository(AppDbContext appDbContext) 
		{
			_appDbcontext = appDbContext;
		}


		//phương thức này dùng để thêm một Employee vào database
		// Sử dụng AddAsync để thêm Employee và SaveChangesAsync để lưu thay đổi
		public async Task AddEmployeeAsync(Employee employee)
		{
			await _appDbcontext.Set<Employee>().AddAsync(employee);
			await _appDbcontext.SaveChangesAsync();
		}

		// Phương thức lấy danh sách tất cả Employee từ cơ sở dữ liệu
		public async Task<List<Employee>> GetAllEmployeeAsync()
		{
			return await _appDbcontext.Employees.ToListAsync();
		}

		// Phương thức lấy một Employee cụ thể theo ID
		public async Task<Employee> GetEmployeeByIdAsync(int id)
		{
			return await _appDbcontext.Employees.FindAsync(id);
		}

		// Phương thức cập nhật thông tin một Employee theo ID
		// Kiểm tra nếu Employee tồn tại, sau đó cập nhật các trường và lưu thay đổi
		public async Task UpdateEmployeeAsync(int id, Employee model)
		{
			var employee = await _appDbcontext.Employees.FindAsync(id); // Tìm Employee theo ID
			if (employee == null) 
			{
				throw new Exception("Employee not found"); // Ném ngoại lệ nếu không tìm thấy Employee
			}
			// Cập nhật các thuộc tính của Employee
			employee.TenNhanVien = model.TenNhanVien;
			employee.Email = model.Email;
			employee.Tuoi = model.Tuoi;
			employee.Sdt = model.Sdt;
			employee.DiaChi = model.DiaChi;
			await _appDbcontext.SaveChangesAsync();
		}

		// Phương thức xóa một Employee khỏi cơ sở dữ liệu theo ID
		public async Task DeleteEmployeeAsync(int id)
		{
			var employee = await _appDbcontext.Employees.FindAsync(id);
			if (employee == null)
			{
				throw new Exception("Employee not found");
			}
			_appDbcontext.Employees.Remove(employee); // Xóa Employee khỏi DbSet
			await _appDbcontext.SaveChangesAsync();
		}
	}
}
