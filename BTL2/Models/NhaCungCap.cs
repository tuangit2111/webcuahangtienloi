using System;
using System.Collections.Generic;

namespace BTL2.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string TenNcc { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public virtual ICollection<Hdnhap> Hdnhaps { get; set; } = new List<Hdnhap>();
}
