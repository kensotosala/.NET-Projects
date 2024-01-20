using System.Diagnostics;
using AppCrud.Models;
using CRUD_ASP.NET_MVC_ADO.NET.Models;
using CRUD_ASP.NET_MVC_ADO.NET.Repositories.Contract;
using Microsoft.AspNetCore.Mvc;

namespace AppCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Departamento> _departamentoRepository;
        private readonly IGenericRepository<Empleado> _empleadoRepository;


        public HomeController(ILogger<HomeController> logger, IGenericRepository<Departamento> departamentoRepository, IGenericRepository<Empleado> empleadoRepository)
        {
            _logger = logger;
            _departamentoRepository = departamentoRepository;
            _empleadoRepository = empleadoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListaDepartamentos()
        {
            List<Departamento> _lista = await _departamentoRepository.Lista();
            return StatusCode(StatusCodes.Status200OK, _lista);
        }

        [HttpGet]
        public async Task<IActionResult> ListaEmpleados()
        {
            List<Empleado> _lista = await _empleadoRepository.Lista();
            return StatusCode(StatusCodes.Status200OK, _lista);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarEmpleado([FromBody] Empleado modelo)
        {
            bool _resultado = await _empleadoRepository.Guardar(modelo);
            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            } else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }
           
        }

        [HttpPut]
        public async Task<IActionResult> EditarEmpleado([FromBody] Empleado modelo)
        {
            bool _resultado = await _empleadoRepository.Editar(modelo);
            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }

        }

        [HttpDelete]
        public async Task<IActionResult> EliminarEmpleado(int idEmpleado)
        {
            bool _resultado = await _empleadoRepository.Delete(idEmpleado);
            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
            }

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
