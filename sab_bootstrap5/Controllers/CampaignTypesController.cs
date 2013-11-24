using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace Marketing.Controllers
{
    public class CampaignTypesController : Controller
    {
        public ActionResult Maintain()
        {
            return View(MaintenanceModelInitializer.InitializeMaintainCampaignTypesModel());
        }

        public ActionResult Save(MaintainCampaignTypesModel model)
        {
            var manager = new CampaignTypeDataManager();

            var form = Request.Form;
            var ids = form["Id"].Split(',').Select(id => Int32.Parse(id)).ToArray();
            var names = form["Name"].Split(',').Select(name => name).ToArray();
           
            for (var i = 0; i < ids.Count(); i++)
            {
                var name = names[i].Trim();
                if (!name.Equals(""))
                {
                    manager.Save(new campaign_type { campaign_type_id = ids[i], campaign_type_description = name });
                }
            }

            if (model.NewCampaignType != null && !model.NewCampaignType.Trim().Equals(""))
            {
                manager.Save(new campaign_type { campaign_type_description = model.NewCampaignType });
            }

            return RedirectToAction("Maintain");
        }

        public ActionResult Deactivate(int id)
        {
            var manager = new CampaignTypeDataManager();
            manager.Deactivate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Activate(int id)
        {
            var manager = new CampaignTypeDataManager();
            manager.Activate(id);
            return RedirectToAction("Maintain");
        }

        public ActionResult Delete(int id)
        {
            var manager = new CampaignTypeDataManager();
            manager.Delete(id);
            return RedirectToAction("Maintain");
        }
    }
}
