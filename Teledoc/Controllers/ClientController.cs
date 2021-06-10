using BL.ItemChanges;
using BL.ItemChanges.Clients;
using DataLayer;
using DataLayer.Entityes;
using DataLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace TeledocTest.Controllers
{
    public class ClientController : Controller
    {
        private readonly IGenericRepotory<Client> _repo;
        private IChange<Client> _change;
        ApplicationDbContext _context;
        public ClientController(ApplicationDbContext context)
        {
            _context = context;
            _repo = new GenericRepository<Client>(context);
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return  View(await _repo.GetAsync());
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetClientsByIdAsync(int id)
        {
            return View(await _repo.FindByIdAsync(id));
        }


        public IActionResult CreateClient()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateClient(Client client)
        //{
        //    _change = new CreateClient();
        //    _change.Change(client);
        //    await _repo.CreateAsync(_change.GetT());
        //    await _repo.SaveAsync();
        //    //Я не до конца понимаю что должен возвращать контроллер в таких ситуациях
        //    //предпологаю, что должно быть какое оповещение, что изменения успешно завершены
        //    //return Ok();
        //    return RedirectToAction("Index");
        //    //return RedirectToAction("Success", "Home",client.Name);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            //_change = new CreateClient();
            //_change.Change(client);
            foreach (var item in client.Founders)
            {
                
                await _context.Founders.AddAsync(item);
            }
            await _repo.CreateAsync(client);
            await _repo.SaveAsync();
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult asd()
        //{
        //    //Client client = new Client();
            
        //    //var founder= new Founder();
            
           
        //    //ViewBag.Founders = client.Founders;
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult asd(Client client,ICollection<Founder> founders)
        //{
        //    _context.Clients.Add(client);
        //    foreach (var item in founders)
        //    {
        //        _context.Founders.Add(item);
        //    }
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult ChangeClientView(Client client)
        {
            return View(client);
        }

        [HttpPut]
        public IActionResult ChangeClient(Client client)
        {
            _change = new EditClient();
            _change.Change(client);
            _repo.Update(_change.GetT());
            _repo.SaveAsync();
            return RedirectToAction("Index");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteClient(Client client)
        {
            _repo.Remove(client);
            await _repo.SaveAsync();
            return RedirectToAction("Index");
        }
    }
}
