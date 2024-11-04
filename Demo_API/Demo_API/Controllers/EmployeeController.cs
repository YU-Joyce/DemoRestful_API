using Demo_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
	// Định tuyến cho API Employee, tất cả các endpoint đều bắt đầu với "api/employee"
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		// _employeeRepository để xử lý các thao tác liên quan đến dữ liệu nhân viên
		private readonly EmployeeRepository _employeeRepository;

		public EmployeeController(EmployeeRepository employeeRepository) 
		{
			_employeeRepository = employeeRepository;
		}

		// Endpoint POST để thêm mới một nhân viên
		// Lấy dữ liệu Employee từ yêu cầu dưới dạng JSON trong body và gán vào `model`
		[HttpPost]
		public async Task<ActionResult> AddEmployee([FromBody] Employee model)
		{
			await _employeeRepository.AddEmployeeAsync(model);
			return Ok(); // Trả về HTTP 200 khi thành công
		}

		// Endpoint GET để lấy danh sách tất cả các nhân viên
		[HttpGet]
		public async Task<ActionResult> GetEmployeeList()
		{
			var employeeList = await _employeeRepository.GetAllEmployeeAsync(); // Lấy toàn bộ danh sách nhân viên
			return Ok(employeeList); // Trả về danh sách dưới dạng JSON với HTTP 200
		}

		// Endpoint GET để lấy thông tin nhân viên theo ID
		// ID được lấy từ URL
		[HttpGet("{id}")]
		public async Task<ActionResult> GetEmployeeById([FromRoute] int id)
		{
			var employee = await _employeeRepository.GetEmployeeByIdAsync(id); // Tìm nhân viên theo ID
			return Ok(employee);
		}

		// Endpoint PUT để cập nhật thông tin của một nhân viên theo ID
		// Lấy ID từ URL và thông tin mới của nhân viên từ body yêu cầu
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
		{
			await _employeeRepository.UpdateEmployeeAsync(id, model); // Gọi repository để cập nhật nhân viên
			return Ok();
		}

		// Endpoint DELETE để xóa một nhân viên theo ID
		// ID được lấy từ URL
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeteleEmployee([FromRoute] int id)
		{
			await _employeeRepository.DeleteEmployeeAsync(id); // Gọi repository để xóa nhân viên theo ID
			return Ok();
		}

	}
}
