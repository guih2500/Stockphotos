using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;
            List<cadastro> list = context.GetAllCadastro();

            return View(list);
        }
    }
}