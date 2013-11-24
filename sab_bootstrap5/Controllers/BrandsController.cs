using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Marketing.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Maintain()
        {
            return View(MaintenanceModelInitializer.InitializeMaintainBrandsModel());
        }

        public ActionResult Save(MaintainBrandsModel model)
        {
            var manager = new BrandDataManager();

            var form = Request.Form;
            var ids = form["Id"].Split(',').Select(id => Int32.Parse(id)).ToArray();
            var names = form["Name"].Split(',').Select(name => name).ToArray();
           
            for (var i = 0; i < ids.Count(); i++)
            {
                var name = names[i].Trim();
                if (!name.Equals(""))
                {
                    manager.Save(new brand { brand_id = ids[i], brand_description = name });
                }
            }

            if (model.NewBrand != null && !model.NewBrand.Trim().Equals(""))
            {
                manager.Save(new brand { brand_description = model.NewBrand });
            }

            return RedirectToAction("Maintain");
        }

        public ActionResult Deactivate(int id)
        {
            var manager = new BrandDataManager();
            manager.Deactivate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Activate(int id)
        {
            var manager = new BrandDataManager();
            manager.Activate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Delete(int id)
        {
            var manager = new BrandDataManager();
            manager.Delete(id);
            return RedirectToAction("Maintain");
        }
    }
}
