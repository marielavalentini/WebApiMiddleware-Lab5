using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMiddleware.Models;

namespace WebApiMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class PersonaController : ControllerBase
    {
        private List<Persona> _listaPersonas = new List<Persona>();

        public PersonaController()
        {
            _listaPersonas.Add(new Persona() {Id = 1, Nombre = "Juan", Apellido = "Spray" });
            _listaPersonas.Add(new Persona() {Id = 2, Nombre = "José", Apellido = "Mosley" });
            _listaPersonas.Add(new Persona() {Id = 3, Nombre = "Juanita", Apellido = "Diaz" });
            _listaPersonas.Add(new Persona() {Id = 4, Nombre = "Belara", Apellido = "Dupler" });
        }

        [HttpGet]
        [Produces("application/xml")]
        //[Authorize]

        public List<Persona> ListarTodas()
        {
            return _listaPersonas;
        }
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    string[] arrRetValues = null;
        //    if (arrRetValues.Length > 0)
        //    { }
        //    return arrRetValues;
        //}

        [HttpGet("{id}")]
        public ActionResult<Persona> ObtenerPersonaPorId(int id)
        {
            var persona = _listaPersonas.FirstOrDefault(p => p.Id == id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }
    }
}