using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TicketAtencionCliente.Entities;

namespace TicketAtencionCliente.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDBContext context;

        public TicketController(ApplicationDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Tickets.ToList());
        }

        private int AsignarCola()
        {
            var cola1 = context.Set<TicketAtencion>().Where(t => t.ColaAsignada == 1 && t.Estado == 0).ToList().Count();
            var cola2 = context.Set<TicketAtencion>().Where(t => t.ColaAsignada == 2 && t.Estado == 0).ToList().Count();
            var tiempocola1 = (cola1 == 0 ? 1 : cola1) * 2; //2 minutos cola 1
            var tiempocola2 = (cola2 == 0 ? 1 : cola2) * 3; //3 minutos cola 2
            if (tiempocola1 == tiempocola2)
                return 1;
            if (tiempocola1 < tiempocola2)
                return 1;
            else
                return 2;
        }

        public IActionResult RegistrarTicket(int id, string nombre)
        {
            if (id != 0 && nombre != null)
            {
                var t = new TicketAtencion
                {
                    Id = id,
                    Nombres = nombre,
                    ColaAsignada = AsignarCola(),
                    Estado = 0
                };
                context.Add(t);
                context.SaveChanges();
                TempData["msg"] = string.Format("<script>alert('sera atendido en la cola {0}');</script>", t.ColaAsignada);
                return RedirectToAction(nameof(Index));
            }
            TempData["msg"] = string.Format("<script>alert('Error');</script>");
            return RedirectToAction(nameof(Index));
        }
    }
}
