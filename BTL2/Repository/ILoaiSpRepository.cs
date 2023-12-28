using BTL2.Models;
namespace BTL2.Repository
{
    public interface ILoaiSpRepository
    {
        DanhMuc Add(DanhMuc loaiSp);
        DanhMuc Update(DanhMuc loaiSp);
        DanhMuc Delete(String maloaiSp);
        DanhMuc GetLoaiSp(String maloaiSp);
        IEnumerable<DanhMuc> GetAllLoaiSp();
    }
}
