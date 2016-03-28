using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.UI.Models;
using Birth.BusinessEntity;
using Birth.BusinessLogic;
using Microsoft.AspNet.Identity;

namespace Web.UI.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Register()
        {
            BLUsuario UsuarioLogic = new BLUsuario();
            UsuarioViewModels modelUser = new UsuarioViewModels();
            BEUsuario Usuario = UsuarioLogic.ObtenerUsuario(User.Identity.GetUserId());

            modelUser.nom_usuario = Usuario.gls_usuario;
            modelUser.nombre = Usuario.gls_nombre;
            modelUser.ape_paterno = Usuario.gls_ape_paterno;
            modelUser.ape_materno = Usuario.gls_ape_materno;
            modelUser.correo = Usuario.correo;

            if (Usuario.anexo != null)
                modelUser.anexo = Convert.ToInt32(Usuario.anexo);

            if (Usuario.idarea != null)
                modelUser.idarea = Convert.ToInt32(Usuario.idarea);

            if (Usuario.idcargo != null)
                modelUser.idcargo = Convert.ToInt32(Usuario.idcargo);

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
                UsuarioParam.guid_user = User.Identity.GetUserId();

                bool result = UsuarioLogic.ActualizarUsuario(UsuarioParam);

                if (result)
                    return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}