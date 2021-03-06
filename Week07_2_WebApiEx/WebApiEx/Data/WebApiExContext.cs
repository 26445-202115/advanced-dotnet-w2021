using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiEx.Models;

namespace WebApiEx.Data
{
    public class WebApiExContext : DbContext
    {
        public WebApiExContext (DbContextOptions<WebApiExContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiEx.Models.Person> Person { get; set; }
    }
}
