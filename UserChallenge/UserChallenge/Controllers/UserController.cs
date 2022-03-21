using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserChallenge.Data.DAL.Interfaces;
using UserChallenge.Models;

namespace UserChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _userRepository;
        public UserController(IUser userRepository)
        {
            this._userRepository = userRepository;
        }


        public IActionResult Index(bool? redirected)
        {
            //IEnumerable<User> usuarios = _userRepository.GetUsers();
            //return View(usuarios);
            if (redirected.HasValue && redirected is true)
            {

                IEnumerable<User> usuarios = _userRepository.GetUsers();
                return View(usuarios);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
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
                    TempData["Mensaje"] = $"Ocurrió un error al intentar crear el usuario. Intente de nuevo. Mensaje: {ex.InnerException}";
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

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
                    TempData["Mensaje"] = $"Ocurrió un error al intentar borrar el usuario. Intente de nuevo. Mensaje: {ex.InnerException}";
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
