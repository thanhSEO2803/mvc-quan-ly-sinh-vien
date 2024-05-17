using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbLophocphan
{
    public string Mahocphan { get; set; } = null!;

    public string Tenhocphan { get; set; } = null!;

    public int Soluong { get; set; }

    public string? Magiaovien { get; set; }

    public virtual TbGiaovien? MagiaovienNavigation { get; set; }
}
