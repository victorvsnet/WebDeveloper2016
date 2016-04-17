using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Controllers
{
    public class MuroController : Controller
    {
        // GET: Muro
        public ActionResult Detalle(int iduser)
        {
            ViewBag.IdUsuario = iduser;
            return View();
        }
    }
}