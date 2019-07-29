using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBazzer.Controllers
{
    public class ChatHubController : Controller
    {
        // GET: ChatHub
        public ActionResult Chat()
        {
            return View();
        }
    }
}