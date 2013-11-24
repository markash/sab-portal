using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Marketing.Controllers
{
    public class CountriesController : Controller
    {
        public ActionResult Maintain()
        {
            return View(MaintenanceModelInitializer.InitializeMaintainCountriesModel());
        }

        public ActionResult Save(MaintainCountriesModel model)
        {
            var manager = new CountryDataManager();

            var form = Request.Form;
            var ids = form["Id"].Split(',').Select(id => Int32.Parse(id)).ToArray();
            var names = form["Name"].Split(',').Select(name => name).ToArray();
           
            for (var i = 0; i < ids.Count(); i++)
            {
                var name = names[i].Trim();
                if (!name.Equals(""))
                {
                    manager.Save(new country { country_id = ids[i], country_description = name });
                }
            }

            if (model.NewCountry != null && !model.NewCountry.Trim().Equals(""))
            {
                manager.Save(new country { country_description = model.NewCountry });
            }

            return RedirectToAction("Maintain");
        }

        public ActionResult Deactivate(int id)
        {
            var manager = new CountryDataManager();
            manager.Deactivate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Activate(int id)
        {
            var manager = new CountryDataManager();
            manager.Activate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Delete(int id)
        {
            var manager = new CountryDataManager();
            manager.Delete(id);
            return RedirectToAction("Maintain");
        }
    }
}
