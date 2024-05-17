using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbTruong
{
    public string Matruong { get; set; } = null!;

    public string Tentruong { get; set; } = null!;

    public string Diachi { get; set; } = null!;

    public virtual ICollection<TbKhoa> TbKhoas { get; set; } = new List<TbKhoa>();
}
