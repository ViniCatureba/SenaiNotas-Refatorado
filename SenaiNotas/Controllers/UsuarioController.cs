using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SenaiNotas.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();



            //metodo
            //[HttpGet]
            //[SwaggerOperation(
            //    Summary = "Arquivda uma anotação", //titulo, descreve brevemente
            //    Description = "Esse endpoit arquiva uma anotacao com base no idfornceido"//descricao, descreve detalhadamente
            //)]
        }
    }
}
