using BTL2.Models;
using BTL2.Repository;
using Microsoft.AspNetCore.Mvc;
namespace BTL2.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaisp = _loaiSp.GetAllLoaiSp().OrderBy (x => x.TenDanhMuc);
            return View(loaisp);
        }
    }
}
