using System;
using System.Collections.Generic;

namespace BTL2.Models;

public partial class DanhMuc
{
    public string MaDanhMuc { get; set; } = null!;

    public string? TenDanhMuc { get; set; }

    public virtual ICollection<Hang> Hangs { get; set; } = new List<Hang>();
}
