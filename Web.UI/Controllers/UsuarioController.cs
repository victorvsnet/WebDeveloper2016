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


            BLCargo CargoLogic = new BLCargo();
            List<BECargo> ListaCargos = new List<BECargo>();

            ListaCargos = CargoLogic.ListarCargo();

            foreach (BECargo item in ListaCargos)
                modelUser.ListaCargos.Add(new Cargo { id = item.id, gls_Cargo = item.gls_Cargo });


            BLArea AreaLogic = new BLArea();
            List<BEArea> ListaArea = new List<BEArea>();

            ListaArea = AreaLogic.ListarArea();

            foreach (BEArea item in ListaArea)
                modelUser.ListaAreas.Add(new Area { id = item.id, gls_area = item.gls_area });


            return View(modelUser);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UsuarioViewModels model)
        {
            if (ModelState.IsValid)
            {
                BLUsuario UsuarioLogic = new BLUsuario();
                BEUsuario UsuarioParam = new BEUsuario();


                UsuarioParam.gls_nombre = model.nombre;
                UsuarioParam.gls_ape_paterno = model.ape_paterno;
                UsuarioParam.gls_ape_materno = model.ape_materno;
                UsuarioParam.anexo = model.anexo;
                UsuarioParam.gls_usuario = model.nom_usuario;
                UsuarioParam.correo = model.correo;
                UsuarioParam.idcargo = model.idcargo;
                UsuarioParam.idarea = model.idarea;

                bool result = UsuarioLogic.ActualizarUsuario(UsuarioParam);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}