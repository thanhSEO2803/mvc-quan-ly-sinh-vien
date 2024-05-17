using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbLopsinhhoat
{
    public string Malop { get; set; } = null!;

    public string Tenlop { get; set; } = null!;

    public int Soluong { get; set; }

    public string? Magiaovien { get; set; }

    public string? Makhoa { get; set; }

    public virtual TbGiaovien? MagiaovienNavigation { get; set; }

    public virtual TbKhoa? MakhoaNavigation { get; set; }

    public virtual ICollection<TbSinhvien> TbSinhviens { get; set; } = new List<TbSinhvien>();
}
