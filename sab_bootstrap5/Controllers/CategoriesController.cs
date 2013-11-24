using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Marketing.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Maintain()
        {
            return View(MaintenanceModelInitializer.InitializeMaintainCategoriesModel());
        }

        public ActionResult Save(MaintainCategoriesModel model)
        {
            var manager = new CategoryDataManager();

            var form = Request.Form;
            var ids = form["Id"].Split(',').Select(id => Int32.Parse(id)).ToArray();
            var names = form["Name"].Split(',').Select(name => name).ToArray();
           
            for (var i = 0; i < ids.Count(); i++)
            {
                var name = names[i].Trim();
                if (!name.Equals(""))
                {
                    manager.Save(new category { category_id = ids[i], category_description = name });
                }
            }

            if (model.NewCategory != null && !model.NewCategory.Trim().Equals(""))
            {
                manager.Save(new category { category_description = model.NewCategory });
            }

            return RedirectToAction("Maintain");
        }

        public ActionResult Deactivate(int id)
        {
            var manager = new CategoryDataManager();
            manager.Deactivate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Activate(int id)
        {
            var manager = new CategoryDataManager();
            manager.Activate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Delete(int id)
        {
            var manager = new CategoryDataManager();
            manager.Delete(id);
            return RedirectToAction("Maintain");
        }
    }
}
