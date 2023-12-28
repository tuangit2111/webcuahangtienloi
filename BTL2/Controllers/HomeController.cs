using Azure;
using BTL2.Models;
using BTL2.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace BTL2.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanHang4Context db = new QuanLyBanHang4Context();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Hangs.AsNoTracking().OrderBy(x => x.TenHang);
            PagedList<Hang> lst = new PagedList<Hang>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("sanpham")]
        public IActionResult SanPham(int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Hangs.AsNoTracking().OrderBy(x => x.TenHang);
            PagedList<Hang> lst = new PagedList<Hang>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Hangs.AsNoTracking().Where(x => x.MaDanhMuc == maloai).OrderBy(x => x.TenHang);
            PagedList<Hang> lst = new PagedList<Hang>(lstsanpham, pageNumber, pageSize);
            ViewBag.maloai = maloai;
            return View(lst);
        }
        [Route("product/{mahang}")]
        public IActionResult ProductDetail(string mahang)
        {
            var sanPham = db.Hangs.SingleOrDefault(x => x.MaHang == mahang);
            var anhSanPham = db.Anhs.Where(x => x.MaHang == mahang).ToList();
            ViewBag.lstAnh = anhSanPham;
            return View(sanPham);
        }
        [Authentication]
        [Route("cart")]
        public IActionResult GioHang()
        {
            return View();
        }
        [Route("checkout")]
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}