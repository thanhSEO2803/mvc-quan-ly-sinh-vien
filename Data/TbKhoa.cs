using System;
using System.Collections.Generic;

namespace BT_QUANLYSINHVIEN.Data;

public partial class TbKhoa
{
    public string Makhoa { get; set; } = null!;

    public string Tenkhoa { get; set; } = null!;

    public string? Matruong { get; set; }

    public virtual TbTruong? MatruongNavigation { get; set; }

    public virtual ICollection<TbGiaovien> TbGiaoviens { get; set; } = new List<TbGiaovien>();

    public virtual ICollection<TbLopsinhhoat> TbLopsinhhoats { get; set; } = new List<TbLopsinhhoat>();
}
