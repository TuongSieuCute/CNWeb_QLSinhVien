using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace backend.Models;

public partial class Sinhvien
{
    public string Masv { get; set; } = null!;

    public string Hotensv { get; set; } = null!;

    public string Gioitinh { get; set; } = null!;

    public DateTime Ngaysinh { get; set; }

    public string Diachi { get; set; } = null!;

    public string Sodienthoai { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mak { get; set; } = null!;

    public virtual ICollection<Ketqua> Ketquas { get; set; } = new List<Ketqua>();

    public virtual Khoa MakNavigation { get; set; } = null!;

    public virtual ICollection<Lophocphan> Malhps { get; set; } = new List<Lophocphan>();
}
