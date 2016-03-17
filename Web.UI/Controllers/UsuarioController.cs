using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.UI.Models;
using Birth.BusinessEntity;
using Birth.BusinessLogic;

namespace Web.UI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Register()
        {
            UsuarioViewModels modelUser = new UsuarioViewModels();
            modelUser.correo = User.Identity.Name;
            return View(modelUser);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UsuarioViewModels model)
        {
            if (ModelState.IsValid)
            {
                BLUsuario UsuarioLogic = new BLUsuario();
                BEUsuario UsuarioParam = new BEUsuario();



                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}