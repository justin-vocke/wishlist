using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var allItems = _context.Items.ToList();
            
            return View(allItems);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item) 
        {
            _context.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var itemToDelete = _context.Items.Where(x => x.Id == Id).FirstOrDefault();

            _context.Items.Remove(itemToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
