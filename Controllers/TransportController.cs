using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Entity;
using WebApplication5.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Controllers
{
    public class TransportController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult metro()
        {
            return View();
        }
        public IActionResult taxi()
        {
            return View();
        }
        public IActionResult bus()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var Transport = context.Transport.Where(t => t.Type == 1).ToList();
                ViewBag.Transport = Transport;
            }

            return View();
        }
        public IActionResult bigBus()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var Transport = context.Transport.Where(t => t.Type == 0).ToList();
                ViewBag.Transport = Transport;
            }

            return View();
        }
        public IActionResult TransportDetails(int id)
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                var transport = context.Transport.FirstOrDefault(t => t.Id == id);
                ViewBag.Transport = transport;
            }

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transport transport)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationContext())
                {
                    context.Transport.Add(transport);
                    context.SaveChanges();
                }

                if(transport.Type == 0 )
                {
                    return RedirectToAction("bigBus");
                } else
                {
                    return RedirectToAction("bus");
                }
                
            }
            else
                return View(transport);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using(var context = new ApplicationContext())
            {
                var trans = context.Transport.Find(id);
                context.Remove(trans);
                context.SaveChanges();
                if (trans.Type == 0)
                {
                    return RedirectToAction("bigBus");
                }
                else
                {
                    return RedirectToAction("bus");
                }
            }
        }

        public IActionResult Update(int id)
        {
            using (var context = new ApplicationContext())
            {
                var transport = context.Transport.Find(id);
                return View(transport);
            }
        }

        [HttpPost]
        public IActionResult Update(Transport transport)
        {
            if (ModelState.IsValid)
            {
                using (var context = new ApplicationContext())
                {
                    context.Transport.Update(transport);
                    context.SaveChanges();
                }

                if (transport.Type == 0)
                {
                    return RedirectToAction("bigBus");
                }
                else
                {
                    return RedirectToAction("bus");
                }

            }
            else
                return View(transport);
        }
    }
}