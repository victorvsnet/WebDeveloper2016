using Birth.BusinessEntity;
using Birth.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BLUsuario oBLUsuario = new BLUsuario();
            List<BEUsuario> oListaUsuario;

            //Realizamos la busqueda de los cumpleaños del dia
            oListaUsuario = oBLUsuario.ListaCumpleanios(DateTime.Today);

            List<CumpleaniosViewModels> ListaCumpleanios = new List<CumpleaniosViewModels>();
            CumpleaniosViewModels cumpleanio;

            foreach (BEUsuario item in oListaUsuario)
            {
                cumpleanio = new CumpleaniosViewModels();

                //Cargamos la informacion del cumpleañero encontrado
                cumpleanio.id = item.id;
                cumpleanio.nombre = item.gls_nombre;
                cumpleanio.ape_paterno = item.gls_ape_paterno;
                cumpleanio.gls_Cargo = item.gls_Cargo;
                cumpleanio.gls_area = item.gls_area;
                cumpleanio.Username = item.gls_usuario;

                //Agregamos el cumpleaño
                ListaCumpleanios.Add(cumpleanio);
            }


            return View(ListaCumpleanios);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}