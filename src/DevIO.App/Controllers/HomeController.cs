using DevIO.App.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modalErro = new ErrorViewModel();

            if(id == 500)
            {
                modalErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modalErro.Titulo = "Ocorreu um erro!";
                modalErro.ErroCode = id;
            }
            if (id == 400)
            {
                modalErro.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvida entre em contato com nosso suporte.";
                modalErro.Titulo = "Ops! Página não encontrada.";
                modalErro.ErroCode = id;
            }
            if (id == 403)
            {
                modalErro.Mensagem = "Vpçê não tem permissão para fazer isso.";
                modalErro.Titulo = "Acesso Negado";
                modalErro.ErroCode = id;
            }
            else
            {
                return StatusCode(500);
            }
            return View("Error", modalErro);
        }
    }
}
