using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WanoControlCenter.Web.Controllers
{
    public class WanoController : Controller
    {
        //
        // GET: /Wano/

        public ActionResult ViewWano()
        {
            WanoService.WanoServiceClient obj = new WanoService.WanoServiceClient();
            return View(obj.GetCards());
        }

    }
}
