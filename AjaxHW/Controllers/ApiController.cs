using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AjaxHW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxHW.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
        public ApiController(DemoContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckName(string Name)
        {
            string rst = "1";
            if(_context.Members.Where(i => i.Name == Name).FirstOrDefault() != null)
            {
                rst = "0";
            }
            return Content(rst, "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult City()
        {
            var cities = _context.Addresses.Select(a => a.City).Distinct();
            return Json(cities);
        }

        public IActionResult Site(string city)
        {
            var sites = _context.Addresses.Where(a => a.City == city).Select(a => a.SiteId).Distinct();
            return Json(sites);
        }

        public IActionResult Road(string site)
        {
            var roads = _context.Addresses.Where(a => a.SiteId == site).Select(a => a.Road).Distinct();
            return Json(roads);
        }
    }
}
