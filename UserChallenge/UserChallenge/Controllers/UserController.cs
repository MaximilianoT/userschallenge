using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Data.Context;
using UserChallenge.Data.DAL.Interfaces;
using UserChallenge.Models;

namespace UserChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly UserChallengeDbContext _context;
        private readonly IUser _userRepository;
        public UserController(UserChallengeDbContext context, IUser userRepository)
        {
            this._context = context;
            this._userRepository = userRepository;
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
                try
                {
                    _userRepository.Create(user);
                    TempData["Mensaje"] = "Se creó el usuario correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Ocurrió un error al intentar crear el usuario. Intente de nuevo.";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Delete(id);
                    TempData["Mensaje"] = "Se eliminó el usuario correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Mensaje"] = "Ocurrió un error al intentar borrar el usuario. Intente de nuevo.";
                    return RedirectToAction("Index");
                }

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

            try
            {
                var editUser = _userRepository.GetUserById(id);
                return View(editUser);
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepository.Edit(user);
                    TempData["Mensaje"] = "Se editó el usuario correctamente.";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Mensaje"] = "Ocurrió un error intentando editar el usuario. Intente nuevamente.";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

    }
}
