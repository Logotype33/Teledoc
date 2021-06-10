using BL.ItemChanges;
using BL.ItemChanges.Clients;
using DataLayer;
using DataLayer.Entityes;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Teledoc.DataLayer.Repository;

namespace TeledocTest.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientAdapterRepo _repoClient;
        private readonly IGenericRepotory<Founder> _repoFounder;
        private IChange<Client> _change;
        public ClientController(ApplicationDbContext context)
        {
            _repoClient = new ClientAdapterRepo(context);
            _repoFounder = new GenericRepository<Founder>(context);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return  View(await _repoClient.GetAsync());
        }



        public IActionResult CreateClient()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            _change = new CreateClient();
            _change.Change(client);
            if (client.Founders !=null)
            {
                foreach (var item in client.Founders)
                {
                    item.CreatingDate = DateTime.UtcNow;
                    item.ChangeDate = DateTime.UtcNow;
                    await _repoFounder.CreateAsync(item);
                }
            }
            await _repoClient.CreateAsync(_change.GetT());
            await _repoClient.SaveAsync();
            return RedirectToAction("Index");
        }



        public IActionResult ChangeClient(int id)
        {
            return View(_repoClient.ClientWithFounders().Where(x => x.Id == id).FirstOrDefault()) ;
        }

        [HttpPost]
        public async Task<IActionResult> ChangeClient(Client client)
        {
            _change = new EditClient();
            _change.Change(client);
            if (client.Founders != null)
            {
                foreach (var item in client.Founders)
                {
                    item.CreatingDate = DateTime.UtcNow;
                    item.ChangeDate = DateTime.UtcNow;
                    await _repoFounder.CreateAsync(item);
                }
            }
                client.ChangeDate = DateTime.UtcNow;
                _repoClient.Update(client);
            _repoClient.DontChangeCreatingDate(client);

            await _repoClient.SaveAsync();
            
            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> DeleteClient(int id)
        {
            _repoClient.Remove(_repoClient.ClientWithFounders().Where(x=>x.Id==id).FirstOrDefault());
            await _repoClient.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
