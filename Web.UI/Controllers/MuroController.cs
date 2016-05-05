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
    public class MuroController : Controller
    {
        // GET: Muro
        public ActionResult Detalle(string nomUser)
        {
            ViewBag.IdUsuario = nomUser;
            BLUsuario oBLUsuario = new BLUsuario();
            BEUsuario oBEUsuario = new BEUsuario();
            MuroViewModels oMuro = new MuroViewModels();

            //Cargar Datos del Perfil Seleccionado
            oBEUsuario = oBLUsuario.ObtenerUsuario(nomUser);
            
            oMuro.nombre = oBEUsuario.gls_nombre;
            oMuro.ape_paterno = oBEUsuario.gls_ape_paterno;
            oMuro.gls_Cargo = oBEUsuario.gls_Cargo;
            oMuro.total_mensajes = 10;

            if (oBEUsuario.anexo != null)
                oMuro.anexo = oBEUsuario.anexo.Value.ToString();
            else
                oMuro.anexo = "No Disponible!";

            if (oBEUsuario.fec_nacimiento != null)
                oMuro.FecNacimiento = String.Format("{0:m}", oBEUsuario.fec_nacimiento.Value);

            List<BEOrganizacion> oListaOrganizadores = new BLOrganizacion().ObtenerOrganizadores(2016, oBEUsuario.id);
            Organizador organizador;
            oMuro.Organizadores = new List<Organizador>();

            foreach (BEOrganizacion item in oListaOrganizadores)
            {
                organizador = new Organizador();
                organizador.nombre = item.gls_organizador;
                organizador.gls_Cargo = item.gls_Cargo;
                oMuro.Organizadores.Add(organizador);
            }


            return View(oMuro);
        }
    }
}