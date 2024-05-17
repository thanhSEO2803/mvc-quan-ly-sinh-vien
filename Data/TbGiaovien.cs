using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbGiaovien
{
    public string Magiaovien { get; set; } = null!;

    public string Tengiaovien { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Diachi { get; set; }

    public string? Makhoa { get; set; }

    public virtual TbKhoa? MakhoaNavigation { get; set; }

    public virtual ICollection<TbLophocphan> TbLophocphans { get; set; } = new List<TbLophocphan>();

    public virtual ICollection<TbLopsinhhoat> TbLopsinhhoats { get; set; } = new List<TbLopsinhhoat>();
}
