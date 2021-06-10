using DataLayer;
using DataLayer.Entityes;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teledoc.Controllers
{
    public class FounderController:Controller
    {
        IGenericRepotory<Founder> _repoFounder;
        public FounderController(ApplicationDbContext context)
        {
            _repoFounder = new GenericRepository<Founder>(context);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFounder(int founderId)
        {
            await _repoFounder.RemoveById(founderId);
            await _repoFounder.SaveAsync();
            return RedirectToAction("Index", "Client");
        }
    }
}
