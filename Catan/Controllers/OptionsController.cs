using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Catan.Controllers
{
    public class OptionsController : Controller
    {

            // GET: Options
            public ActionResult Index()
        {
            return View();
        }



    }
    }