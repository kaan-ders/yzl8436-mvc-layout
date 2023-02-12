using Microsoft.AspNetCore.Mvc;
using MvcEf;
using MvcLayout.Models;

namespace MvcLayout.Controllers
{
    public class HomeController : Controller
    {
        private OkulContext _context;

        public HomeController(OkulContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //select * from Ogrenci where SilindiMi = 0
            List<Ogrenci> ogrenciler = _context.Ogrenci.Where(o => o.SilindiMi == false).ToList();

            return View(ogrenciler);
        }

        public IActionResult Detay(int id)
        {
            Ogrenci ogrenci = _context.Ogrenci.First(item => item.Id == id && item.SilindiMi == false);
            return View(ogrenci);
        }
    }
}