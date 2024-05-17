using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbSinhvien
{
    public int Masinhvien { get; set; }

    public string Tensinhvien { get; set; } = null!;

    public DateOnly? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public string Diachi { get; set; } = null!;

    public string? Email { get; set; }

    public string? Malop { get; set; }

    public virtual TbLopsinhhoat? MalopNavigation { get; set; }
}
