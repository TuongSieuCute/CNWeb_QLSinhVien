using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public partial class Khoa
{
    [Key]
    public string Mak { get; set; } = null!;

    public string Tenk { get; set; } = null!;

    public virtual ICollection<Giangvien> Giangviens { get; set; } = new List<Giangvien>();

    public virtual ICollection<Lophocphan> Lophocphans { get; set; } = new List<Lophocphan>();

    public virtual ICollection<Monhoc> Monhocs { get; set; } = new List<Monhoc>();

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
