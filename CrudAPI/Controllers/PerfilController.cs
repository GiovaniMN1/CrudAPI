using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Agregamos las siguientes referencias
using Microsoft.EntityFrameworkCore;
using CrudAPI.Context;
using Microsoft.AspNetCore.Components;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using CrudAPI.Entities;


namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        //vamos a recibir nuestro contexto de DB
        private readonly AppDbContext _context;
        //Construiremos nuestro controlador y en el parametro recibiremos el contexto 
        public PerfilController(AppDbContext context) {
            _context = context;

        }

        //Creamos nuestras solicitudes y creamos nuestro Ruteo
        [HttpGet("lista")]
        //indicamos que nos va aregresar una lista de tipo Perfil
        public async Task<ActionResult<List<Perfil>>> Get()
        {
            //Vamos a regresar nuestra lista de Perfiles
            var listaPerfiles = await _context.Perfiles.ToListAsync();  
            return Ok(listaPerfiles);
        }
        
    }
}
