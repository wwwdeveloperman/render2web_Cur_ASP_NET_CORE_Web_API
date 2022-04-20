using CRUD_WEB_API_MVC.Data;
using CRUD_WEB_API_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_WEB_API_MVC.Controllers
{
    [Route("api/[controller]")] // => localhost:2020/api/Contactos  
    [ApiController]
    public class ContactosController : ControllerBase
    {
        // using crud_web_api_mvc.data
        private readonly ContactoContexto _context;
        public ContactosController(ContactoContexto contexto)
        {
            _context = contexto;
        }

        //              VERBOS:



        // Peticion GET:http://localhost:26149/api/contactos/
        [HttpGet]
        // using 
        public async Task<ActionResult<IEnumerable<Contacto>>>
        GetContactoItems()
        {
            // using EntityFra.
            return await _context.ContactoItems.ToListAsync();
        }




        // Peticion tipo GET "{n}" : http://localhost:26149/api/contactos/2
        [HttpGet("{id}") ]
        public async Task<ActionResult<Contacto>> GetContactoItem(int id) //<-- ojo
        {
            var contactoItem = await _context.ContactoItems.FindAsync(id);
            
            if (contactoItem==null)
            {
                return NotFound();
            }

            return contactoItem;    // <------   hasta cuando se coloca el return
                                // dara Error en GetContactoItem.

        }




        // CREAR con POST  http://localhost:26149/api/contactos/
        [HttpPost]
        //  Crear un nombre al metodo post: "PostContactoItem"
        public async Task<ActionResult<Contacto>> PostContactoItem(Contacto item)
        { 
            _context.ContactoItems.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactoItem), new { id = item.Id }, item);
        }



        // UPDATE c Patch  es p mandar un campo en vez de todo el record con Put.




        // UPDATE con PUT http://localhost:26149/api/contactos/2
        [HttpPut("{id}") ]
        public async Task<IActionResult> PunContactoItem(int id, Contacto item )
        {
            if( id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }



        //DELETE con  DELETE http://localhost:26149/api/contactos/2
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactoItem(int id)
        {

            var contactoItem = await _context.ContactoItems.FindAsync(id);

            if(contactoItem == null )
            {
                return NotFound();
            }

            _context.ContactoItems.Remove(contactoItem);
            await _context.SaveChangesAsync();

            return NoContent();

        }






    }
}
