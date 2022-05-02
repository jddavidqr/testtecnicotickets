using Microsoft.EntityFrameworkCore;
using TicketAtencionCliente.Entities;

namespace TicketAtencionCliente
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TicketAtencion> Tickets { get; set; }
    }
}
