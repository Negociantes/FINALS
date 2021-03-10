using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negociantes.Data;
using Negociantes.Models;

namespace Negociantes.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.User.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users record)
        {
            var user = new Users();
            {
                user.FirstName = record.FirstName;
                user.LastName = record.LastName;
                user.Email = record.Email;
                user.Address = record.Address;
                user.MobileNumber = record.MobileNumber;
                user.MessengerLink = record.MessengerLink;
                user.Password = record.Password;
                user.confirmPassword = record.confirmPassword;
                user.Types = record.Types;
            };

            _context.User.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var item = _context.User.Where(i => i.UserID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(int? id, Users record)
        {
            var user = _context.User.Where(i => i.UserID == id).SingleOrDefault();

            user.FirstName = record.FirstName;
            user.LastName = record.LastName;
            user.Email = record.Email;
            user.Address = record.Address;
            user.MobileNumber = record.MobileNumber;
            user.MessengerLink = record.MessengerLink;
            user.Password = record.Password;
            user.confirmPassword = record.confirmPassword;
            user.Types = record.Types;

            _context.User.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var item = _context.User.Where(i => i.UserID == id).SingleOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            _context.User.Remove(item);
            _context.SaveChanges();
            return View(item);
        }
    }
}
