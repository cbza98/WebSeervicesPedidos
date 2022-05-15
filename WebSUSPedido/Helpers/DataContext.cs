using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSUSPedido.Models.Login;

namespace WebSUSPedido.Helpers
{
    public class DataContext : DbContext
    {

        //public DataContext()
        //{
        //}
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DataContext(DbContextOptions<DataContext> options)
       : base(options)
        {
        }

        public DbSet<OPE_USUARIO> OPE_USUARIO { get; set; }


    }
}
