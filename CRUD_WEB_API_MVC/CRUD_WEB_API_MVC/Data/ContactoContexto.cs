using CRUD_WEB_API_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_WEB_API_MVC.Data
{
    public class ContactoContexto : DbContext
    {
        // Constructor using EntityFrameworkCore, instalarlo c NuGets.
        public ContactoContexto(DbContextOptions<ContactoContexto> options ): base(options)
        {

        }

        // Dbset    using CRUD_WEB_API_MVC
        //se vuelca el modelo Contacto en ContactoItem para acceder desde el controlador.
        // se crea la tabla contactoitems en la database.

        public DbSet<Contacto> ContactoItems { get; set; }
    }
}
