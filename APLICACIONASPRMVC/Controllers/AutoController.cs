using APLICACIONASPRMVC.Models.Db;
using Microsoft.AspNetCore.Mvc;

namespace APLICACIONASPRMVC.Controllers
{
    public class AutoController : Controller


    {
        private readonly AbcdataBaseContext _context;

        public IActionResult Index()
        {
            return View();
        }

        public AutoController(AbcdataBaseContext context)
        {

            _context = context;
        }

        [HttpPost]

        public async Task<IActionResult> Crear(Automobile Auto)
        {

            if(ModelState.IsValid)
            {

                _context.Automobiles.Add(Auto);
                await _context.SaveChangesAsync();
                TempData["Mensaje"] = "El usuario se creo correctamente";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Editar(Automobile auto)
        {

            if (ModelState.IsValid)
            {

                _context.Automobiles.Update(auto);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }


            return View();

        }


        public async Task<IActionResult> Borrar(Automobile auto)
        {

            if (ModelState.IsValid)
            {

                _context.Automobiles.Remove(auto);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }


            return View();

        }
    }
}
