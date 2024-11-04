namespace Demo_API.Models
{
	public class Employee
	{
		public int Id { get; set; } // Khóa chính, tự động tăng

		public string TenNhanVien { get; set; } // Tên nhân viên

		public string Email { get; set; } // Địa chỉ email của nhân viên

		public int Tuoi { get; set; } // Tuổi của nhân viên

		public string Sdt { get; set; } // Số điện thoại của nhân viên

		public string DiaChi { get; set; } // Địa chỉ của nhân viên
	}
}
