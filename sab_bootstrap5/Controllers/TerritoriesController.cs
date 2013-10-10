using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Marketing.Controllers
{
    public class TerritoriesController : Controller
    {
        public ActionResult Maintain()
        {
            return View(MaintenanceModelInitializer.InitializeMaintainTerritoriesModel());
        }

        public ActionResult Save(MaintainTerritoriesModel model)
        {
            var territoryManager = new TerritoryDataManager();

            var form = Request.Form;
            var ids = form["Id"].Split(',').Select(id => Int32.Parse(id)).ToArray();
            var names = form["Name"].Split(',').Select(name => name).ToArray();
           
            for (var i = 0; i < ids.Count(); i++)
            {
                var name = names[i].Trim();
                if (!name.Equals(""))
                {
                    territoryManager.Save(new territory { territory_id = ids[i], territory_description = name });
                }
            }

            if (model.NewTerritory != null && !model.NewTerritory.Trim().Equals(""))
            {
                territoryManager.Save(new territory { territory_description = model.NewTerritory });
            }

            return RedirectToAction("Maintain");
        }

        public ActionResult Deactivate(int id)
        {
            var manager = new TerritoryDataManager();
            manager.Deactivate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Activate(int id)
        {
            var manager = new TerritoryDataManager();
            manager.Activate(id);
            return RedirectToAction("Maintain");
        }
    }
}
