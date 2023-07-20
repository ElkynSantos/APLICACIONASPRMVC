using APLICACIONASPRMVC.Models;
using APLICACIONASPRMVC.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
namespace APLICACIONASPRMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AbcdataBaseContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AbcdataBaseContext context)
        {
            _logger = logger;
            _context = context;
        }

   

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
           // var automobiles = await _context.Automobiles.Where(a=>a.BranchOfficeId==1).ToArrayAsync();
            var automobiles = await _context.Automobiles.ToArrayAsync();
            return View(automobiles);
        }


        public  IActionResult Redireccionar()
        {
            return View("~/Views/Auto/crear.cshtml");
        }

        public IActionResult Editar(Guid? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            var auto = _context.Automobiles.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View("~/Views/Auto/Editar.cshtml",auto);
        }


        public  IActionResult Borrar(Guid? id)
        {

            if(id == null)
            {
                return NotFound();
            }

            var auto = _context.Automobiles.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View("~/Views/Auto/Borrar.cshtml",auto);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}