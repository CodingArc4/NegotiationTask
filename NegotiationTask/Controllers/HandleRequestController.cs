using Microsoft.AspNetCore.Mvc;
using NegotiationTask.Data;

namespace NegotiationTask.Controllers
{
    public class HandleRequestController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HandleRequestController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
