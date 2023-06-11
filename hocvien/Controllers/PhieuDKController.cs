using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hocvien.Model;
using Microsoft.AspNetCore.Mvc;

namespace hocvien.Controllers
{
    public class PhieuDKController : Controller
    {
        private centerContext db = new centerContext();
        public IActionResult Index()
        {
            return View();
        }

    }
   

}