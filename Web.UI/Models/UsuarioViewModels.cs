using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.UI.Models
{
    public class UsuarioViewModels
    {
        [Required]
        [Display(Name = "Nombres")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno")]
        public string ape_paterno { get; set; }

        [Display(Name = "Apellido Materno")]
        public string ape_materno { get; set; }

        [Display(Name = "Nro. Anexo")]
        public int anexo { get; set; }

        [Required]
        [Display(Name = "Nombre de Usuario")]
        public string nom_usuario { get; set; }

        [EmailAddress]
        [Display(Name = "Direccion Email")]
        public string correo { get; set; }

        [Display(Name = "Cargo")]
        public List<Cargo> ListaCargos { get; set; }

        [Display(Name = "Area")]
        public List<Area> ListaAreas { get; set; }

        [Display(Name = "Empresa")]
        public List<Empresa> ListaEmpresas { get; set; }

        public UsuarioViewModels()
        {
            ListaCargos = new List<Cargo>();
            ListaAreas = new List<Area>();
            ListaEmpresas = new List<Empresa>();
        }
    }

    public class Cargo
    {
        public int id { get; set; }
        public string gls_Cargo { get; set; }
    }

    public class Area
    {
        public int id { get; set; }
        public string gls_area { get; set; }
    }

    public class Empresa
    {
        public int id { get; set; }
        public string gls_empresa { get; set; }
    }

}