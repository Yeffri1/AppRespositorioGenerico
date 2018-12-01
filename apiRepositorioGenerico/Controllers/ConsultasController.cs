using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiRepositorioGenerico.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiRepositorioGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private readonly Contexto _context;
        public ConsultasController(Contexto contexto)
        {
            _context = contexto;
        }


        [HttpGet("GetTelefonosByUsuario/{id}")]
        [Route("GetTelefonosByUsuario")]
        public  object GetTelefonosByUsuario(int id)
        {
            var resultado = (from telefono in _context.TelefonoRepositorio
                             join repositorio in _context.Repositorio
                             on telefono.idRepositorio equals repositorio.id
                             where repositorio.usuario == id
                             select new
                             {
                                 telefono.telefono,
                                 repositorio.fechaIng,
                                 repositorio.descripcion
                             }).ToList();
            return Ok(resultado);
        }

    }
}