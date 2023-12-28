using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL2.Models;

namespace BTL2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        QuanLyBanHang4Context db = new QuanLyBanHang4Context();
        [HttpGet]
        public List<Hang> GetAllProducts()
        {
            var sanPham = db.Hangs.ToList();
            return sanPham;
        }
        [HttpGet("{maloai}")]
        public List<Hang> GetProductsByCategory(string maLoai)
        {
            var lstSp = db.Hangs.Where(x => x.MaDanhMuc == maLoai).ToList();
            return lstSp;
        }
    }
}