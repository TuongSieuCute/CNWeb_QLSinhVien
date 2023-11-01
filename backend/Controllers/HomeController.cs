using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly DatabaseContext context;

    public HomeController(DatabaseContext context){
        this.context=context;
   }

    [HttpGet("GetSinhVien")]
    public async Task<IEnumerable<Sinhvien>> GetSinhVien(){
        return await context.Sinhviens.ToListAsync();
    }

    [HttpPost("AddSinhVien")]
    public async Task<Sinhvien> AddSinhVien(Sinhvien obj){
        context.Sinhviens.Add(obj);
        await context.SaveChangesAsync();
        return obj;
    }

    [HttpPatch("UpdateSinhVien/{masv}")]
    public async Task<Sinhvien> UpdateSinhVien(Sinhvien obj){
        context.Entry(obj).State=EntityState.Modified;
        await context.SaveChangesAsync();
        return obj;
    }

    [HttpDelete("DeleteSinhVien/{masv}")]
    public bool DeleteSinhVien(string masv){
        bool flag = false;
        var sv = context.Sinhviens.Find(masv);
        if(sv != null){
            flag = true;
            context.Entry(sv).State = EntityState.Deleted;
            context.SaveChanges();
        }
        else{
            flag = false;
        }
        return flag;
    }
}
