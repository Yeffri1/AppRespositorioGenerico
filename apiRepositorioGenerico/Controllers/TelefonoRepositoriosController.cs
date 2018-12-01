using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiRepositorioGenerico.Model;
using Newtonsoft.Json;

namespace apiRepositorioGenerico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoRepositoriosController : ControllerBase
    {
        private readonly Contexto _context;

        public TelefonoRepositoriosController(Contexto context)
        {
            _context = context;
        }

        // GET: api/TelefonoRepositorios
        [HttpGet]
        public IEnumerable<TelefonoRepositorio> GetTelefonoRepositorio()
        {
            return _context.TelefonoRepositorio;
        }
        [HttpGet]
        [Route("AddDataPrueba")]
        public object AddDataPrueba()
        {
            try
            {
                using (_context.Database.BeginTransaction())
                {
                    TipoRepositorio tipo = new TipoRepositorio
                    {
                        descripcion = "Telefono",
                        fechaIng = DateTime.Now
                    };
                    _context.TipoRepositorio.Add(tipo);
                    List<Repositorio> Repositorio = new List<Repositorio>()
            {
                new Repositorio
                {
                    descripcion = "Telefono Yeffri",
                    tipoID = 1,
                    fechaIng = DateTime.Now,
                    usuario = 1
                },
                new Repositorio
                {
                       descripcion = "Telefono Mama",
                    tipoID = 1,
                    fechaIng = DateTime.Now,
                    usuario = 1
                },
                new Repositorio
                {
                       descripcion = "Telefono Papa",
                    tipoID = 1,
                    fechaIng = DateTime.Now,
                    usuario = 1
                }
            };
                    _context.Repositorio.AddRange(Repositorio);

                    List<TelefonoRepositorio> telefonos = new List<TelefonoRepositorio>()
            {
                new TelefonoRepositorio
                {
                    telefono = "8296632787",
                    idRepositorio = Repositorio.ElementAt(0).id
                },
                new TelefonoRepositorio
                {
                       telefono = "8292072787",
                    idRepositorio = Repositorio.ElementAt(1).id
                },
                new TelefonoRepositorio
                {
                       telefono = "8092062787",
                    idRepositorio = Repositorio.ElementAt(2).id
                }
            };
                    _context.TelefonoRepositorio.AddRange(telefonos);

                    _context.SaveChanges();
                    _context.Database.CommitTransaction();
                }
            }
            catch (Exception e)
            {
                _context.Database.RollbackTransaction();
                return e.Message;
            }
            return _context.TelefonoRepositorio;
        }




        // GET: api/TelefonoRepositorios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTelefonoRepositorio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var telefonoRepositorio = await _context.TelefonoRepositorio.FindAsync(id);

            if (telefonoRepositorio == null)
            {
                return new StatusCodeResult(404);
            }

            return Ok(telefonoRepositorio);
        }

        // PUT: api/TelefonoRepositorios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTelefonoRepositorio([FromRoute] int id, [FromBody] TelefonoRepositorio telefonoRepositorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != telefonoRepositorio.idRepositorio)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(telefonoRepositorio).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Content(JsonConvert.SerializeObject(new Response { Error = 0, msg = "Guardado" }), "application/json");

            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!TelefonoRepositorioExists(id))
                {
                    return Content(JsonConvert.SerializeObject(new Response { Error = 1, msg = "No Encontrado" }), "application/json");
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new Response { Error = 1, msg = e.Message }), "application/json");
                }
            }

        }

        // POST: api/TelefonoRepositorios
        [HttpPost]
        public async Task<IActionResult> PostTelefonoRepositorio([FromBody] TelefonoRepositorio telefonoRepositorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TelefonoRepositorio.Add(telefonoRepositorio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (TelefonoRepositorioExists(telefonoRepositorio.idRepositorio))
                {
                    return Content(JsonConvert.SerializeObject(new Response { Error = 1, msg = "Ya existe" }), "application/json");
                }
                else
                {
                    return Content(JsonConvert.SerializeObject(new Response { Error = 1, msg = e.Message }), "application/json");

                }
            }
            return CreatedAtAction("GetTelefonoRepositorio", new { id = telefonoRepositorio.idRepositorio }, telefonoRepositorio);
        }

        // DELETE: api/TelefonoRepositorios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTelefonoRepositorio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var telefonoRepositorio = await _context.TelefonoRepositorio.FindAsync(id);
            if (telefonoRepositorio == null)
            {
                return NotFound();
            }

            _context.TelefonoRepositorio.Remove(telefonoRepositorio);
            await _context.SaveChangesAsync();

            return Ok(telefonoRepositorio);
        }

        private bool TelefonoRepositorioExists(int id)
        {
            return _context.TelefonoRepositorio.Any(e => e.idRepositorio == id);
        }
    }
}