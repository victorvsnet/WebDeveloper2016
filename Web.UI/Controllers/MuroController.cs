using Birth.BusinessEntity;
using Birth.BusinessLogic;
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
        public ActionResult Detalle(string nomUser)
        {
            ViewBag.IdUsuario = nomUser;
            BLUsuario oBLUsuario = new BLUsuario();
            BEUsuario oBEUsuario = new BEUsuario();

            oBEUsuario = oBLUsuario.ObtenerUsuario(nomUser);

            return View();
        }
    }
}