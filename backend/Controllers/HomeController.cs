using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DatabaseContext context;

        public HomeController(DatabaseContext context)
        {
            this.context = context;
        }

        // Lấy danh sách tất cả sinh viên
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Sinhvien>> GetAll()
        {
            return await context.Sinhviens.ToListAsync();
        }

        // Lấy thông tin sinh viên theo Mã sinh viên
        [HttpGet("GetByMasv/{masv}")]
        public async Task<ActionResult<Sinhvien>> GetByMasv(string masv)
        {
            var sinhvien = await context.Sinhviens.FirstOrDefaultAsync(s => s.Masv == masv);

            if (sinhvien == null)
            {
                return NotFound(); // Trả về mã 404 nếu không tìm thấy sinh viên
            }

            return sinhvien;
        }

        // Thêm sinh viên mới
        [HttpPost("Add")]
        public async Task<ActionResult<Sinhvien>> Add(Sinhvien sinhvien)
        {
            // Kiểm tra xem có tồn tại mã khoa `Mak` trong cơ sở dữ liệu hay không
            var existingKhoa = context.Khoas.FirstOrDefault(k => k.Mak == sinhvien.Mak);

            if (existingKhoa == null)
            {
                // Nếu mã khoa không tồn tại, bạn nên xử lý lỗi hoặc trả về thông báo tùy ý.
                return BadRequest("Mã khoa không tồn tại.");
            }

            // Gán đối tượng Khoa tương ứng cho đối tượng Sinhvien
            sinhvien.MakNavigation = existingKhoa;

            // Thêm sinh viên vào cơ sở dữ liệu
            context.Sinhviens.Add(sinhvien);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByMasv), new { masv = sinhvien.Masv }, sinhvien);
        }



        // Sửa thông tin sinh viên theo Mã sinh viên
        [HttpPut("Edit/{masv}")]
        public async Task<IActionResult> Edit(string masv, Sinhvien sinhvien)
        {
            if (masv != sinhvien.Masv)
            {
                return BadRequest(); // Trả về mã 400 nếu Mã sinh viên không khớp
            }

            context.Entry(sinhvien).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinhvienExists(masv))
                {
                    return NotFound(); // Trả về mã 404 nếu không tìm thấy sinh viên
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Xóa sinh viên theo Mã sinh viên
        [HttpDelete("Delete/{masv}")]
        public async Task<IActionResult> Delete(string masv)
        {
            var sinhvien = await context.Sinhviens.FirstOrDefaultAsync(s => s.Masv == masv);

            if (sinhvien == null)
            {
                return NotFound(); // Trả về mã 404 nếu không tìm thấy sinh viên
            }

            context.Sinhviens.Remove(sinhvien);
            await context.SaveChangesAsync();

            return NoContent();
        }

        // Tìm kiếm sinh viên theo tên
        [HttpGet("Search")]
        public async Task<IEnumerable<Sinhvien>> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                return new List<Sinhvien>();
            }

            return await context.Sinhviens
                .Where(s => s.Hotensv.Contains(keyword))
                .ToListAsync();
        }

        private bool SinhvienExists(string masv)
        {
            return context.Sinhviens.Any(s => s.Masv == masv);
        }
    }
}
