using APLICACIONASPRMVC.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APLICACIONASPRMVC.Controllers
{
    public class Usuarios : Controller
    {
        private readonly AbcdataBaseContext _context;
        public async Task<IActionResult> IndexUser()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public Usuarios(AbcdataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CrearUsuario() {
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario(Employee user)
        {
            if (ModelState.IsValid)
            {
               
                _context.Employees.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("IndexUser");
            }
            

            return View();
        }


    }
}
