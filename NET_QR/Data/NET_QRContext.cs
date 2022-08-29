using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET_QR.Models;

namespace NET_QR.Data
{
    public class NET_QRContext : DbContext
    {
        public NET_QRContext (DbContextOptions<NET_QRContext> options)
            : base(options)
        {
        }

        public DbSet<NET_QR.Models.User> User { get; set; } = default!;
    }
}
