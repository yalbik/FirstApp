using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class EditAccountController : Controller
    {
        // GET: EditAccount
        public ActionResult Index()
        {
            return View("EditAccount");
        }
    }
}