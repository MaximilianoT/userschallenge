using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Data.Context;
using UserChallenge.Models;

namespace UserChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly UserChallengeDbContext _context;
        public UserController(UserChallengeDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<User> usuarios = _context.Usuarios.ToList();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                 _context.Usuarios.AddAsync(user);
                 _context.SaveChangesAsync();
                TempData["Mensaje"] = "Se creó el usuario correctamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Remove(_context.Usuarios.Where(x=> x.IdUsuario == id).First());
                _context.SaveChangesAsync();
                TempData["Mensaje"] = "Se eliminó el usuario correctamente.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var editUser = _context.Usuarios.Where(x => x.IdUsuario == id).First();
            return View(editUser);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(user);
                _context.SaveChanges();
                TempData["Mensaje"] = "Se editó el usuario correctamente.";
                return RedirectToAction("Index");
            }

            return View();
        }

    }
}
